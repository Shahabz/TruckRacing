using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class S_CameraShake : MonoBehaviour
{
//	 This class is static, you can call it from anywhere. Put it on the camera or a parent to the camera.
	private Vector3 _originalPos;
	public static S_CameraShake _instance;

	void Awake()
	{
		_originalPos = transform.localPosition;
		Debug.Log ("Original poisition::"+_originalPos);

		_instance = this;
//			Shake (1000000000000,0.04f);
	}

	public static void Shake (float duration, float amount) {
		_instance.StopAllCoroutines();
		_instance.StartCoroutine(_instance.cShake(duration, amount));
	}

	public IEnumerator cShake (float duration, float amount) {
		float endTime = Time.time + duration;

		while (Time.time < endTime) {
			transform.localPosition = _originalPos + Random.insideUnitSphere * amount;
//			transform.localPosition=new Vector3(Random.insideUnitSphere*amount,_originalPos.y,_originalPos.z);

			duration -= Time.deltaTime;

			yield return null;
		}

		transform.localPosition = _originalPos;
	}

}