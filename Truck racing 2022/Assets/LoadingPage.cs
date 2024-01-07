using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingPage : MonoBehaviour {

	public Text Hint_txt;


	public string[] HelpText;
	// Use this for initialization
	void OnEnable () {
		int randomNum = Random.RandomRange (0,HelpText.Length);
		Hint_txt.text = "" + HelpText [randomNum];

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
