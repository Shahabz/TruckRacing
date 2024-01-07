using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FailPage : MonoBehaviour {

	// Use this for initialization

	public  Text BestlapTime,pos,TotalTime,drivername,mainpos,posTag;

	public GameObject failImg;
	void Start () {

		iTween.ScaleTo (failImg, iTween.Hash ("x", 1.0, "y", 1.0, "time", 0.5, "easetype", iTween.EaseType.easeOutSine, "islocal", true));

		
	}
	
	// Update is called once per frame
	void Update () {

//		if (Statistics._statistics.racingUI.bestLapTime)
		BestlapTime.text=RGSK.RaceUI.instance.GetBestLapTime();
		pos.text =RGSK.RaceUI.instance.player.rank.ToString();
		TotalTime.text=RGSK.RaceUI.instance.player.totalRaceTime.ToString();
		drivername.text =RGSK.RaceUI.instance.player.racerDetails.racerName;

		mainpos.text =RGSK.RaceUI.instance.player.rank.ToString();

//		posTag.text =RGSK.RaceUI.instance.player.rank.ToString();


		if (RGSK.RaceUI.instance.player.rank == 1 || RGSK.RaceUI.instance.player.rank == 21) {
			posTag.text = "st";
			}
		else if (RGSK.RaceUI.instance.player.rank == 2 || RGSK.RaceUI.instance.player.rank == 22) {
			posTag.text = "nd";
			}

		else if (RGSK.RaceUI.instance.player.rank== 3 ||RGSK.RaceUI.instance.player.rank == 23) {
			posTag.text = "rd";
			}
			else {
			posTag.text = "th";
			}

	}
}
