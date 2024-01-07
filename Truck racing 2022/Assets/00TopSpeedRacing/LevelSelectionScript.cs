using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RGSK;

public class LevelSelectionScript : MonoBehaviour
{

	public int LevelsCount;
	bool isShowingDirectLevelsInApp=false;
    void Start()
    {
    
    }
	void OnEnable()
	{
		
		//Display buying unlock all levels InApp here after completing 3rd level.
		if (PlayerPrefs.GetInt ("UnlockedLevels") == 4) 
		{
			Debug.Log ("Show direct in appp..............................................");
			isShowingDirectLevelsInApp = true;
			Invoke ("ShowInAppPaymentsPage",1.5f);
							

		}
		//if(AdManager.instance){
		//	AdManager.instance.RunActions (AdManager.PageType.LvlSelection,CurrentTrackDetails.instance.currentLevel);//uday
		//}


		Invoke ("CallAds",2.0f);

		if (isShowingDirectLevelsInApp==false)
		{
			Invoke ("UnlockLevelsPopupActive",1.0f);
						
		}


		Debug.LogWarning ("llllllllllllllllllllllllllllllllllllllllllll"+ PlayerPrefs.GetInt ("UnlockedLevels"));
		if (PlayerPrefs.GetInt ("UnlockedLevels") == 30) 
		{
			MenuManager.mee.UnlockAllLevelsBtn	.SetActive (false);
		}

	}

	void ShowInAppPaymentsPage()
	{
		Debug.Log ("onlyone time prefs is???????????????????????????"+PlayerPrefs.GetInt (MenuManager.OnlyOneTime_LSPrefs));
		if (PlayerPrefs.GetInt (MenuManager.OnlyOneTime_LSPrefs) == 1)
		{
//			Btm_IABManager.mee.BUY (2);
			isShowingDirectLevelsInApp = false;
			Debug.Log ("Showing Unlock All Levels In App Payment page only one time.");
			PlayerPrefs.SetInt (MenuManager.OnlyOneTime_LSPrefs, 2);
		}

	}

	void CallAds()
	{

//		Btm_AdmobManager.needAutoInterstitial=AdsPageType.upgradeOrLevelSelection;
//		GameConfigs2018.mee.showRotationAds (MenuManager.CurrentLevel,AdsPageType.upgradeOrLevelSelection);
	}
	void UnlockLevelsPopupActive()
	{

//		LevelsCount = PlayerPrefs.GetInt (MenuManager.UnlockAllLevelsCount) + 1;
//		PlayerPrefs.SetInt (MenuManager.UnlockAllLevelsCount, LevelsCount);
//		Debug.Log ("Unlock levels count::"+LevelsCount);
//		if (LevelsCount % 5==0) 
//		{
//			if (PlayerPrefs.GetInt (MenuManager.UnlockAllLevelsPopupPrefs) != 1) {
//				MenuManager.mee.UnlockAllLevelsPopup.SetActive (true);
//			}
//			//			LevelSelectionHandler.mee.UnlockedLevelCount = 0;
//		}

	}
}
