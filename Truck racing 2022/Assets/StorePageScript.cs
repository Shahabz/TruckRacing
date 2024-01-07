using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RGSK;
public class StorePageScript : MonoBehaviour {

	public GameObject Store_NoAdsBtn,Store_UnlockAllCarsBtn,Store_UnlockAllLevelsBtn,UnlockAllBtn;
	bool allevelsunlocked,allcarsunlocked;
	void OnEnable ()
	{
		if (PlayerPrefs.GetInt ("UnlockedLevels") == 30) 
		{
			
//			allevelsunlocked = true;
		}

//		for (int i = 1; i < MenuManager.mee.menuVehicles.Length; i++) {
//
//			if (MenuManager.mee.menuVehicles [i].unlocked == true)
//			{
//				
//				allcarsunlocked = true;
//			}
//		}

	

		
	}
	
	void Update()
	{
		if (allevelsunlocked == true)
		{
			Store_NoAdsBtn.SetActive (false);
			Store_UnlockAllLevelsBtn.SetActive (false);

		}
		if (allcarsunlocked == true)
		{
			Store_NoAdsBtn.SetActive (false);
			Store_UnlockAllCarsBtn.SetActive (false);
		}
		if (allcarsunlocked == true && allcarsunlocked == true)
		{
			Store_NoAdsBtn.SetActive (false);
			Store_UnlockAllCarsBtn.SetActive (false);
			Store_UnlockAllLevelsBtn.SetActive (false);
			UnlockAllBtn.SetActive (false);
		}

	}
}
