using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class mute : MonoBehaviour
{
	
	public static bool mute1;
	private string CheckSound = "false";
	// Use this for initialization
	void Start ()
	{
		if (PlayerPrefs.HasKey ("sound") == false) {
			PlayerPrefs.SetString ("sound", CheckSound);

		} else {
			CheckSound = PlayerPrefs.GetString (CheckSound);
		}
		if (CheckSound == "true") {
			mute1 = true;
		} else {
			mute1 = false;
		}
	
	}
	public Sprite muteTex;
	public Sprite unMuteTex;
	// Update is called once per frame
//	void OnMouseDown ()
//	{
//
//		if (mute1 != true) {
//			mute1 = true;			
//			AudioListener.volume = 0;	
//			CheckSound = "true";
//			PlayerPrefs.SetString ("sound", CheckSound);
//		} else {
//			mute1 = false;
//			CheckSound = "false";
//			PlayerPrefs.SetString ("sound", CheckSound);
//			AudioListener.volume = 1;
//					
//		}
//
//	}

	public void SOund ()
	{

		if (mute1 != true) {
			mute1 = true;			
			AudioListener.volume = 0;	
			this.transform.GetComponent<Image> ().sprite = muteTex;
			CheckSound = "true";
			PlayerPrefs.SetString ("sound", CheckSound);
		} else {
			mute1 = false;
			CheckSound = "false";
			PlayerPrefs.SetString ("sound", CheckSound);
			AudioListener.volume = 1;
			this.transform.GetComponent<Image>  ().sprite = unMuteTex;

		}

	}
	
	void Update ()
	{
//		if (mute1) {
//			transform.GetComponent<SpriteRenderer> ().sprite = muteTex;
//			AudioListener.volume = 0;
//		} else {
//			transform.GetComponent<SpriteRenderer> ().sprite = unMuteTex;
//			AudioListener.volume = 1;
//		}
	}
	
	
}
