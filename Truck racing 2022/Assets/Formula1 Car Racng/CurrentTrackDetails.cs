using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace RGSK
{
	public class CurrentTrackDetails : MonoBehaviour {

		public static CurrentTrackDetails instance;
		public Text lapCount, bestLapTime, opponentCount;//, raceReward;
		public int currentLevel;
		public GameObject lockImg, playImg;
		public Text levelNumTxt;
		// Use this for initialization
		void OnEnable () {
			SetDetails (currentLevel);
			levelNumTxt.text = "Level: " + (currentLevel+1);
			if (MenuManager.mee.menuTracks [currentLevel].unlocked) {
				lockImg.SetActive (false);
				playImg.SetActive (true);
			} else {
				lockImg.SetActive (true);
				playImg.SetActive (false);
			}
		}

		void Start()
		{
			instance = this;
		}
		public void SetDetails(int levelNum){
			lapCount.text = MenuManager.mee.menuTracks[currentLevel].laps.ToString ();
			bestLapTime.text = (PlayerPrefs.HasKey ("BestTime" + MenuManager.mee.menuTracks [currentLevel].sceneName)) ? PlayerPrefs.GetString ("BestTime" + MenuManager.mee.menuTracks [levelNum].sceneName) : "--:--:--";
		
		
			opponentCount.text = MenuManager.mee.menuTracks [currentLevel].aiCount.ToString ();

//			raceReward.text = "" + MenuManager.mee.menuTracks [currentLevel].price.ToString ();
			
		}


		public void Play(){
			MenuManager.CurrentLevel = currentLevel + 1;
			MenuManager.mee.trackIndex = currentLevel;

			if (MenuManager.mee.menuTracks [currentLevel].unlocked) {
				print ("playThisLevel");
				MenuManager.mee.Play ();
			} else {
				
				Debug.Log ("Locked Level");
				//AdManager.instance.BuyItem (1, true);
			}
		}
		

	}
}
