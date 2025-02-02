﻿using UnityEngine;
using System;
using System.Collections.Generic;
using UnityStandardAssets.ImageEffects;

namespace RGSK
{
    /// <summary>
    /// The PlayerCamera handles all player camera related activity. 
    /// </summary>
    public class PlayerCamera : MonoBehaviour
    {
        public enum CameraMode { Chase, Fixed, FirstPerson }
        public CameraMode cameraMode = CameraMode.Chase;

        private Rigidbody rigid;
        public Transform target;

        [Header("Chase Camera Settings")]
        public float distance = 5.0f;
        public float height = 1.5f;
        public float lookAtHeight = 0.5f;
        public float heightDamping = 5.0f;
        public float rotationDamping = 2.5f;
        [Range(1, 10f)]
        public float distanceZoomSpeed = 5.0f; //Speed at which zoom occurs
        [Range(0.01f, 0.1f)]
        public float distanceMultiplier = 0.05f; //Amount of zoom applied
        public bool distanceBasedOnVelocity = true;
        private float currentDistance;
        private float wantedRotationAngle;
        private float wantedHeight;
        private float currentRotationAngle = 45.0f;
        private float currentHeight;
        private Quaternion currentRotation;
        private Vector3 lookAtVector;
        private Vector3 wantedPosition;
        [HideInInspector]
        public Vector3 velocityDir;
        [HideInInspector]
        public bool lookLeft, lookRight, lookBack;

        [Header("First Person Camera Settings")]
        public float xSpeed = 100.0f;
        public float ySpeed = 100.0f;
        public float yMinLimit = -20.0f;
        public float yMaxLimit = 30.0f;
        public float xMinLimit = -60.0f;
        public float xMaxLimit = 60.0f;
        private float x;
        private float y;
        private bool canOrbit;
        public bool allowOrbit = true;
        public bool autoSnapRotation = true;
        [HideInInspector]
        public float orbitX, orbitY;
        private float autoSnapTimer;

        //FIXED CAMERA
        private List<Transform> fixedCamPosition = new List<Transform>();
        private int index = -1;

		public Car_Controller carControl;
		public bool IsNitroStarted;
		public static PlayerCamera mee;

		void Awake()
		{
			mee=this;
		}

        void Start()
        {
            index = -1;

            //reduce the depth(this allows the the minimap camera to draw on top)
            GetComponent<Camera>().depth = -1;
        }

        void Update()
        {
            if (!target && GameObject.FindGameObjectWithTag("Player"))
            {
                target = GameObject.FindGameObjectWithTag("Player").transform;
                rigid = target.GetComponent<Rigidbody>();
                GetFixedCameraPositions();
            }

            GetCameraInput();


        }    

        void LateUpdate()
        {
            if (!target) return;

            switch (cameraMode)
            {
                case CameraMode.Chase:
                    ChaseCamera();
                    break;

                case CameraMode.Fixed:
                    FixedCamera();
                    break;

                case CameraMode.FirstPerson:
                    FirstPersonCamera();
                    break;
            }
        }

        //CHASE CAMERA
        void ChaseCamera()
        {
            wantedHeight = target.position.y + height;
            currentHeight = transform.position.y;
            currentRotationAngle = transform.eulerAngles.y;
            if (!lookLeft && !lookRight && !lookBack) wantedRotationAngle = target.eulerAngles.y;

            currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, Time.deltaTime * rotationDamping);
            currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
            currentDistance = (distanceBasedOnVelocity) ? Mathf.Lerp(currentDistance, distance + (rigid.velocity.magnitude * distanceMultiplier), distanceZoomSpeed * Time.deltaTime) : Mathf.Lerp(currentDistance, distance, distanceZoomSpeed * Time.deltaTime);

            currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

            velocityDir = target.InverseTransformDirection(rigid.velocity);

            if (lookLeft) wantedRotationAngle = target.eulerAngles.y - 90;
            if (lookRight) wantedRotationAngle = target.eulerAngles.y + 90;
            if (lookBack) wantedRotationAngle = target.eulerAngles.y + 180;

            wantedPosition = target.position;
            wantedPosition.y = currentHeight;

            transform.position = wantedPosition;
            transform.position -= currentRotation * Vector3.forward * currentDistance;
            transform.LookAt(target.position + new Vector3(0, lookAtHeight, 0));

			gameObject.GetComponent<Camera> ().fieldOfView = 50;

        }


        //FIRST PERSON CAMERA
        void FirstPersonCamera()
        {
//            if (allowOrbit)
//            {
//                x += (orbitX * xSpeed * Time.deltaTime);
//                y -= (orbitY * ySpeed * Time.deltaTime);
//            }
//
//            if (orbitX == 0 && orbitY == 0)
//            {
//                autoSnapTimer += Time.deltaTime;
//
//                if (autoSnapTimer >= 1 && autoSnapRotation)
//                {
//                    x = Mathf.Lerp(x, 0, Time.deltaTime * 2.5f);
//                    y = Mathf.Lerp(y, 0, Time.deltaTime * 2.5f);
//                }
//            }
//            else
//            {
//                autoSnapTimer = 0.0f;
//            }

            y = ClampAngle(y, yMinLimit, yMaxLimit);
            x = ClampAngle(x, xMinLimit, xMaxLimit);

            Quaternion rotation = Quaternion.Euler(y, x, 0);

            transform.position = fixedCamPosition[index].position;
            transform.rotation = fixedCamPosition[index].rotation * rotation;
			gameObject.GetComponent<Camera> ().fieldOfView = 60;
        }

        //FIXED CAMERA
        void FixedCamera()
        {
            transform.position = fixedCamPosition[index].position;
            transform.rotation = fixedCamPosition[index].rotation;
        }

        void GetCameraInput()
        {
            if (!InputManager.instance) return;

            switch (InputManager.instance.inputDevice)
            {
                case InputManager.InputDevice.Keyboard:

                    //Change Camera Views
                    if (Input.GetKeyDown(InputManager.instance.keyboardInput.switchCamera))
                    {
                        SwitchCameras();
                    }

                    //Camera Look Left
                    lookLeft = Input.GetKey(InputManager.instance.keyboardInput.cameraLookLEFT);


                    //Camera Look Right
                    lookRight = Input.GetKey(InputManager.instance.keyboardInput.cameraLookRIGHT);


                    //Camera Look Back
                    lookBack = lookRight && lookLeft || Input.GetKey(InputManager.instance.keyboardInput.cameraLookBACK) || velocityDir.z <= -2.0f;

                    //Camera orbit values
                    orbitX = Input.GetAxis(InputManager.instance.keyboardInput.orbitXaxis);
                    orbitY = Input.GetAxis(InputManager.instance.keyboardInput.orbitYaxis);

                    break;

                case InputManager.InputDevice.XboxController:

                    //Change Camera Views
                    if (Input.GetButtonDown(InputManager.instance.xboxControllerInput.switchCamera))
                    {
                        SwitchCameras();
                    }

                    //Camera Look Left
                    lookLeft = Input.GetButton(InputManager.instance.xboxControllerInput.cameraLookLEFT);


                    //Camera Look Right
                    lookRight = Input.GetButton(InputManager.instance.xboxControllerInput.cameraLookRIGHT);


                    //Camera Look Back
                    lookBack = lookRight && lookLeft || Input.GetButton(InputManager.instance.xboxControllerInput.cameraLookBACK) || velocityDir.z <= -2.0f;

                    //Camera orbit values
                    orbitX = Input.GetAxis(InputManager.instance.xboxControllerInput.orbitXaxis);
                    orbitY = Input.GetAxis(InputManager.instance.xboxControllerInput.orbitYaxis);
                    break;

            }
        }

        public void SwitchCameras()
        {
            index++;
            CycleCameraPositions();
        }

        void CycleCameraPositions()
        {

            //Revert back to Chase camera after all fixed positions have been cycled
			Debug.Log ("CamMode" + index);

            if (index >= fixedCamPosition.Count)
            {
                currentRotationAngle = target.eulerAngles.y;
                cameraMode = CameraMode.Chase;
                index = -1;
                //This makes things easier when switching between replay cams
                if (ReplayManager.instance)
                {
                    if (ReplayManager.instance.replayState == ReplayManager.ReplayState.Playing)
                        CameraManager.instance.ActivateCinematicCamera();
                }
                return;
            }
//			if(cam
            if (fixedCamPosition.Count <= 0) return;
			if (index == 1)
				index = 2;
            if (fixedCamPosition[index].GetComponent<ChildCameraPosition>().mode == CameraMode.FirstPerson)
            {
//                cameraMode = CameraMode.FirstPerson;
				cameraMode = CameraMode.Fixed;
            }
            else
            {
                cameraMode = CameraMode.Fixed;
            }
        }

        void GetFixedCameraPositions()
        {
            Transform[] fixedCams = target.GetComponentsInChildren<Transform>();

            foreach (Transform cp in fixedCams)
            {
                if (cp.GetComponent<ChildCameraPosition>())
                    fixedCamPosition.Add(cp.transform);
            }
        }

        float ClampAngle(float angle, float min, float max)
        {
            if (angle < -360)
            {
                angle += 360;
            }
            if (angle > 360)
            {
                angle -= 360;
            }
            return Mathf.Clamp(angle, min, max);
        }

		public void ChangeCameraToGreyScaleEnable()
		{
//			Camera.main.GetComponent<Grayscale> ().enabled = true;//uday
		}
		public void ChangeCameraToGreyScaleDisable()
		{
//			Camera.main.GetComponent<Grayscale> ().enabled = false;//uday
		}
		public void EnableNitroBlurEffect()
		{
//			Debug.Log ("nitro activated");
//			Camera.main.GetComponent<MotionBlur> ().blurAmount = 0.8f;
//			RaceUI.instance.MotionObject.blurAmount=0.8f;
//			Camera.main.GetComponent<Bloom>().bloomThresholdColor=new Vector4(73,255,247,255);
		}
		public void DisableNitroBlurEffect()
		{
//			Camera.main.GetComponent<MotionBlur> ().blurAmount = 0.25f;
//			Camera.main.GetComponent<Bloom>().bloomThresholdColor=new Vector4(255,73,73,255);


		}

    }


}