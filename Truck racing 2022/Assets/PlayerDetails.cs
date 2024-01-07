//using UnityEngine;
//using System.Collections;
//using UnityEngine.UI;
//
//public class PlayerDetails : MonoBehaviour
//{
//	public Text PlayerName;
//	public GameObject[] ProfilePics;
//	public static string ProfileName = "";
//	public static int ProfilePicNo = 0;
//	public GameObject ContinueBTn, InputFiled;
//	public Text SelectProfilePicTxt;
//	// Use this for initialization
//	void Start ()
//	{
//		ContinueBTn.SetActive (false);
//		ProfilePicNo = 0;
////		if (HR_HighwayRacerProperties.Instance.mainMenuClips != null && HR_HighwayRacerProperties.Instance.mainMenuClips.Length > 0)
////			RCC_CreateAudioSource.NewAudioSource (gameObject, "Main Menu Soundtrack", 0f, 0f, 1f, HR_HighwayRacerProperties.Instance.mainMenuClips [5], true, true, false);
//		
//	}
//
//
//	void OnKeyDown ()
//	{
//		
//	
//	}
//
//	void OnEnable ()
//	{
//
////		for (int i = 0; i < ProfilePics.Length; i++) {
////			iTween.ScaleFrom (ProfilePics [i], iTween.Hash ("x", 0, "y", 0, "time", 0.3, "delay", 0.1 * i));
////		}
//		iTween.ScaleFrom (InputFiled, iTween.Hash ("x", 0, "y", 0, "time", 0.3, "delay", 0.5));
//		Debug.Log (">>>>>>");
//
//	}
//
//	public void SelectProfilePic (int PicNo)
//	{
//		Debug.Log ("picNo:=" + PicNo);
//		for (int i = 0; i < ProfilePics.Length; i++) {
//			iTween.ScaleTo (ProfilePics [i], iTween.Hash ("x", 1, "y", 1, "time", 0.5, "islocal", true, "easetype", iTween.EaseType.easeInSine));
//		}
//		iTween.ScaleTo (ProfilePics [PicNo - 1], iTween.Hash ("x", 1.2, "y", 1.2, "time", 0.3, "easetype", iTween.EaseType.easeOutSine, "islocal", true));
//		ProfilePicNo = PicNo;
//	}
//
//	public void Continue ()
//	{
//		if (ProfilePicNo != 0) {
////			UIHandler.Instance.RequestToEnableObject (2);
//		} else {
//			SelectProfilePicTxt.text = "Please select profile pic...";
//		}
//	}
//	// Update is called once per frame
//	void Update ()
//	{
//		
//		if (PlayerName != null && PlayerName.text != "" && PlayerName.text.Length > 2) {
//			ContinueBTn.SetActive (true);
//			ProfileName = PlayerName.text;
//		} else {
//			ContinueBTn.SetActive (false);
//		}
//	}
//}
