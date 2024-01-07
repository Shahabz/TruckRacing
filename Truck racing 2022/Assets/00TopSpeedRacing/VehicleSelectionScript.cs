using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RGSK;
public class VehicleSelectionScript : MonoBehaviour {

	public int CarsCount;
	bool isShowingDirectLevelsInApp_UPG_lvl3=false;
	bool isShowingDirectLevelsInApp_UPG_lvl5=false;


	void OnEnable()
	{
		//Display buying unlock all levels InApp here after completing 3rd level.
		Debug.LogWarning("Levels Unlocked for checking::"+PlayerPrefs.GetInt("UnlockedLevels"));
		if (PlayerPrefs.GetInt ("UnlockedLevels") == 3 || PlayerPrefs.GetInt ("UnlockedLevels") == 6) 
		{
			Debug.LogWarning ("Init Inapp payment page after second level.");
			isShowingDirectLevelsInApp_UPG_lvl3 = true;
			Invoke ("ShowInAppPaymentsPage_InLvl3",1.5f);
		}


		if (PlayerPrefs.GetInt ("UnlockedLevels") == 6)
		{
			Debug.LogWarning ("Init Inapp payment page after fifth level.");
			isShowingDirectLevelsInApp_UPG_lvl5 = true;
			Invoke ("ShowInAppPaymentsPage_InLvl5",1.5f);
		}
		Debug.Log ("boooooooooooooooooooooooooooooooooooooooooooooooool::"+isShowingDirectLevelsInApp_UPG_lvl3 );
		if (isShowingDirectLevelsInApp_UPG_lvl3==false || isShowingDirectLevelsInApp_UPG_lvl5==false) 
		{
			
			Invoke ("UnlockCarsPopupActive",1.0f);

		}

//		for (int i = 1; i < MenuManager.mee.menuVehicles.Length; i++) {
//			
//			if (MenuManager.mee.menuVehicles [i].unlocked == true)
//			{
//				Debug.Log ("$$$$$$"+MenuManager.mee.menuVehicles [i].unlocked);
//				MenuManager.mee.UnlockAllCarsBtn.SetActive (false);
//								
//			}
//
//		
//
//		}
	}


	void ShowInAppPaymentsPage_InLvl3()
	{
		Debug.LogWarning ("display inapp payment page...???"+PlayerPrefs.GetInt (MenuManager.OnlyOneTime_UpgPrefs_lvl3));
		Debug.LogWarning ("Show it or not::"+isShowingDirectLevelsInApp_UPG_lvl3);
		if (PlayerPrefs.GetInt (MenuManager.OnlyOneTime_UpgPrefs_lvl3) == 1)
		{
//			Debug.LogWarning ();
//			Btm_IABManager.mee.BUY (1);
			isShowingDirectLevelsInApp_UPG_lvl3 = false;
			Debug.Log ("Showing Unlock All Levels In App Payment page only one time.");
			PlayerPrefs.SetInt (MenuManager.OnlyOneTime_UpgPrefs_lvl3, 2);
		}

	}

	void ShowInAppPaymentsPage_InLvl5()
	{
		Debug.LogWarning ("display inapp payment page...???"+PlayerPrefs.GetInt (MenuManager.OnlyOneTime_UpgPrefs_lvl5));
		if (PlayerPrefs.GetInt (MenuManager.OnlyOneTime_UpgPrefs_lvl5) == 1)
		{
			//			Debug.LogWarning ();
//			Btm_IABManager.mee.BUY (1);
			isShowingDirectLevelsInApp_UPG_lvl5 = false;
			Debug.Log ("Showing Unlock All Levels In App Payment page only one time.");
			PlayerPrefs.SetInt (MenuManager.OnlyOneTime_UpgPrefs_lvl5, 2);
		}

	}
    void Start()
    {
        
    }

	void CallAds()
	{
//		GameConfigs2018.mee.showRotationAds (MenuManager.CurrentLevel,AdsPageType.upgradeOrLevelSelection);
	}
	void UnlockCarsPopupActive()
	{

//		CarsCount = PlayerPrefs.GetInt (MenuManager.UnlockAllCarsCount) + 1;
//		PlayerPrefs.SetInt (MenuManager.UnlockAllCarsCount, CarsCount);
//		Debug.Log ("Unlock Cars count::"+CarsCount);
//		if (CarsCount % 3==0) 
//		{
//			if (PlayerPrefs.GetInt (MenuManager.UnlockAllCarsPopupPrefs) != 1) {
//				MenuManager.mee.UnlockAllCarsPopup.SetActive (true);
//			}
//			//			LevelSelectionHandler.mee.UnlockedLevelCount = 0;
//		}
//
	}

}
