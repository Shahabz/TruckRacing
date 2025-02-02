﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class profileTweener : MonoBehaviour {

	public GameObject[] movefrom_obj;
	public GameObject[] fromLeft_obj;

	public GameObject[] scalefrom_obj;
	public GameObject[] fromRight_obj;

	public GameObject[] fromDown_obj;




	private int val = 500;
	// Use this for initialization
	void Start () {

		float delayVal = 1f;
		foreach (GameObject gob in movefrom_obj) {
			if(gob!=null)
				iTween.MoveFrom (gob, iTween.Hash ("y", gob.transform.position.y + val, "time", 0.5f, "delay", delayVal));
			delayVal += 0.1f;
		}

		//  delayVal = 0.8f;
		foreach (GameObject gob in fromLeft_obj) {
			if(gob!=null)
				iTween.MoveFrom (gob, iTween.Hash ("x", gob.transform.position.x - val, "time", 0.5f, "delay", delayVal));
			delayVal += 0.1f;
		}


		delayVal = 0.5f;
		foreach (GameObject gob in scalefrom_obj) {
			iTween.ScaleFrom (gob, iTween.Hash ("Scale", Vector3.zero, "time", 0.5f, "delay", delayVal,"easetype",iTween.EaseType.easeOutBack));
			delayVal += 0.1f;
		}



		delayVal = 1.2f;
		foreach (GameObject gob in fromDown_obj) {
			print (gob.name+" :a: "+gob.transform.localPosition);	
			if(gob!=null)
				iTween.MoveFrom (gob, iTween.Hash ("y", gob.transform.position.y - val, "time", 0.5f, "delay", delayVal));
			delayVal += 0.1f;
		}

		delayVal = 0.6f;

		foreach (GameObject gob in fromRight_obj) {
			if(gob!=null)
				iTween.MoveFrom (gob, iTween.Hash ("x", gob.transform.position.x + 1000, "time", 0.5f, "delay", delayVal));
			delayVal += 0.2f;
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
