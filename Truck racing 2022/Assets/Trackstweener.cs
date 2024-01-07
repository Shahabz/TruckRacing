using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Trackstweener : MonoBehaviour {

	public GameObject[] movefrom_obj;
	public GameObject[] fromLeft_obj;

	public GameObject[] scalefrom_obj;
	public GameObject[] fromRight_obj;

	public GameObject[] fromDown_obj;

//	public GameObject[] Rotatefrom;

//	public float waittime=1000;

//	public GameObject Speed,needle;

	private int val = 500;
	// Use this for initialization
	void Awake()
	{
		
//		Speed.GetComponent<Animator>().enabled=false;
//		needle.GetComponent<Animator>().enabled=false;


	}

	void OnEnable () {


//		iTween.ValueTo(gameObject,iTween.Hash("from",5f,"to",100,"time",0f,"delay",3,"onupdate","LightTween","onupdatetarget",gameObject));
//		if(Speed.GetComponent<Animator>()||needle.GetComponent<Animator>())
//		Speed.GetComponent<Animator>().enabled=true;
//		needle.GetComponent<Animator>().enabled=true; 


		float delayVal = 0.2f;
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


		delayVal = 0.2f;
		foreach (GameObject gob in scalefrom_obj) {
			iTween.ScaleFrom (gob, iTween.Hash ("Scale", Vector3.zero, "time", 0.5f, "delay", delayVal,"easetype",iTween.EaseType.easeOutBack));
			delayVal += 0.3f;
		}



		delayVal = 0.3f;
		foreach (GameObject gob in fromDown_obj) {
			print (gob.name+" :a: "+gob.transform.localPosition);	
			if(gob!=null)
				iTween.MoveFrom (gob, iTween.Hash ("y", gob.transform.position.y - val, "time", 0.5f, "delay", delayVal));
			delayVal += 0.05f;
		}

		delayVal = 0.6f;

		foreach (GameObject gob in fromRight_obj) {
			if(gob!=null)
				iTween.MoveFrom (gob, iTween.Hash ("x", gob.transform.position.x + 1000, "time", 0.5f, "delay", delayVal));
			delayVal += 0.2f;
		}
	}

	void LightTween()
	{

//		Speed.gameObject.GetComponent<Image> ().fillAmount = 1;



	}
	
	// Update is called once per frame
	void Update () {
	}
}
