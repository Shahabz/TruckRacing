using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RGSK
{
public class Levelmanager : MonoBehaviour {
		public GameObject MainContainer;
		public RaceManager RaceMObj;
		public Camera MiniCamera;
		public TrackManager[] AllMyTracks;

		public static Levelmanager mee;
		public static int RetryLevelNum;


		public GameObject Circuit_HelpText;
		public GameObject SpeedTrap_HelpText;
		public GameObject Checkpoint_HelpText;
		public GameObject Elimination_HelpText;
		public GameObject LapKnockOut_Helptext;

	// Use this for initialization
	void Start () {
			mee = this;
			Debug.Log (MenuManager.CurrentLevel +" race type  : "+PlayerPrefs.GetString("RaceType"));
			AllMyTracks [MenuManager.CurrentLevel - 1].gameObject.SetActive (true);
			int tempVal;
			tempVal = MenuManager.CurrentLevel;
			RetryLevelNum = tempVal;
			Debug.Log ("Ttrack index before clicking on retry btn::"+RetryLevelNum);
			Debug.Log ("Level No::"+MenuManager.CurrentLevel);

			RaceMObj.pathContainer = AllMyTracks [MenuManager.CurrentLevel - 1].mPathContainer.transform;
			RaceMObj.spawnpointContainer = AllMyTracks [MenuManager.CurrentLevel - 1].SpawnPointObj.transform;
			RaceMObj.checkpointContainer = AllMyTracks [MenuManager.CurrentLevel - 1].MainChecpointkParent.transform;
			MiniCamera.orthographicSize = AllMyTracks [MenuManager.CurrentLevel - 1].MiniMapCameraSize;
			MiniCamera.transform.localPosition=AllMyTracks [MenuManager.CurrentLevel - 1].MiniCamPos;

			if (PlayerPrefs.GetString ("RaceType") == "SpeedTrap") {
				AllMyTracks [MenuManager.CurrentLevel - 1].SpeedTrapObj.SetActive (true);
				AllMyTracks [MenuManager.CurrentLevel - 1].CheckPointObj.SetActive (false);
			} else {
				AllMyTracks [MenuManager.CurrentLevel - 1].SpeedTrapObj.SetActive (false);
				AllMyTracks [MenuManager.CurrentLevel - 1].CheckPointObj.SetActive (true);
			}


			//Invoke ("Enablelevelengine",0.5f);
			Enablelevelengine ();
//			Btm_Utils2018.jarToast("settings "+SystemInfo.graphicsMemorySize);
			//EnableHelpPopups();


	}
	
	
		void Enablelevelengine () {
			Debug.Log ("-----------------------> spwn point.....");

			MainContainer.SetActive (true);	
	}


	public 	void EnableHelpPopups()
		{
//			AudioListener.volume = 1;
			if (MenuManager.CurrentLevel == 1) 
			{
				Time.timeScale = 0;

				RaceUI.instance.HelpPopups.SetActive(true);
				Circuit_HelpText.SetActive (true);
			}
//			if (MenuManager.CurrentLevel == 2)
//			{
//				RaceUI.instance.HelpPopups.SetActive(true);
//				SpeedTrap_HelpText.SetActive (true);
//			}
//			if (MenuManager.CurrentLevel == 3) 
//			{
//				RaceUI.instance.HelpPopups.SetActive(true);
//				Checkpoint_HelpText.SetActive (true);
//			}
//			if (MenuManager.CurrentLevel == 4) 
//			{
//				RaceUI.instance.HelpPopups.SetActive(true);
//				Elimination_HelpText.SetActive (true);
//			}
//			if (MenuManager.CurrentLevel == 5) {
//				RaceUI.instance.HelpPopups.SetActive(true);
//				LapKnockOut_Helptext.SetActive (true); 
//			} 

			if (MenuManager.CurrentLevel >= 2)
			{
				AudioListener.volume = 1;
				Time.timeScale = 1;
				print ("++++++++calling if no");
//				RaceUI.instance.StartCountDown (1);

			}
		}
}
}
