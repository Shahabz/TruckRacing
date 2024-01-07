using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheels : MonoBehaviour 
{

	void Start ()
	{
		
	}
	
	void Update ()
	{
//		gameObject.transform.rotation = new Quaternion (30 * Time.deltaTime, 0, 0);
		transform.Rotate(Vector3.right, 1300 * Time.deltaTime);
	}
}
