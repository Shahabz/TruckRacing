using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{

	void Start () 
	{
		
	}
	
	void Update () 
	{
		transform.Rotate(0,10*5*Time.deltaTime,0);
	}
}
