using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace RGSK {

    /// <summary>
    /// //UI_button handles UGUI button presses for car movement on mobile devices
    /// </summary>
    public class UIButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public enum ButtonAction { Accelerate, Brake, Handbrake, SteerLeft, SteerRight, Nitro, SwitchCamera, Respawn, Pause,SteeringWheel }
        public ButtonAction buttonAction;
        public float inputValue;
        public float inputSensitivity = 1.5f;
        public bool buttonPressed;

		public static UIButton mee;

		void Awake()
		{
			mee = this;
		}
        public void OnPointerDown(PointerEventData eventData)
        {
//			if(buttonAction!=ButtonAction.Nitro)
            buttonPressed = true;

        }




        public void OnPointerUp(PointerEventData eventData)
        {
//			if(buttonAction!=ButtonAction.Nitro)
            buttonPressed = false;
        }
	public	float SteeringRotation;
        void Update()
        {
            if (buttonPressed)
            {
                inputValue += Time.deltaTime * inputSensitivity;
//				if (Car_Controller.mee.nitroCapacity == 0) 
//				{
//					buttonPressed = false;
//				}

            }
            else
            {
                inputValue -= Time.deltaTime * inputSensitivity;
            }

            inputValue = Mathf.Clamp(inputValue, 0, 1);



			//Mohith
//			if (buttonAction == ButtonAction.SteeringWheel) 
//			{
//				SteeringRotation = gameObject.transform.rotation.z;
//
//			}
//			if (SteeringRotation > 0) {
//				//Steer left side
//				buttonAction = ButtonAction.SteerLeft; 
//			} if (SteeringRotation < 0) {
//				//Steer Right Side
//				buttonAction = ButtonAction.SteerRight; 
//			}
			//Mohith

        }


//		public void NitroClicked()
//		{
//			buttonPressed = true;
//		}
    }



}