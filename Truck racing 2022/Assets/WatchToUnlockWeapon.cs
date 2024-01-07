using UnityEngine;
using System.Collections;
//using UnityEngine.Advertisements;
using UnityEngine.UI;
using RGSK;
public class WatchToUnlockWeapon : MonoBehaviour {
//	public int TotalViews, GunNum;
//	public Text WatchText;
	void Start () 
	{
//		WatchText.text = "Watch " + TotalViews + " videos"+"\nto unlock";
	}
	
	void Update () 
	{
	
	}
	void CheckCount()
	{
//		TotalViews--;
//		WatchText.text = "Watch " + TotalViews + " videos"+"\nto unlock";
//
//		if (TotalViews <= 0) {
////			Gun2UnLocked
////			PlayerPrefs.SetInt ("Gun" + GunNum + "UnLocked", 1);
////			GameManager.Instance.RequestToUnlockTrain (GlobalVariables.i_CurrentTrainSelected, GAME_STATE.TRAIN_SELECTION);
////			gameObject.SetActive (false);
////			GunSelectionCs._instance.CheckGunIndx ();
//			PlayerPrefs.SetString ("unlockTest", "true");
//			if (gameConfigs.mee) {
//				gameConfigs.mee.jarToast ("Succefully Unlocked Train");
//			}
//
//		} else if (gameConfigs.mee) {
//				
//			gameConfigs.mee.jarToast ("Watch " + TotalViews + " more videos" + "to unlock");
//		}
//		
	}
	public void WatchVideo()
	{
		Debug.Log ("before" + PlayerData.currency.ToString ("N0"));
//		MenuManager.UpdateCoins(500);
		Debug.Log ("Added" + PlayerData.currency.ToString ("N0"));
//		if (Advertisement.IsReady ("rewardedVideo")) {
//
//
//			Advertisement.Show ("rewardedVideo", new ShowOptions {
//				resultCallback = result => {
//					//Failed, Skipped, Finished
//					Debug.Log ("UnityAdsss=" + result.ToString ());
//					if (result.ToString () == "Finished") 
//					{
//						MenuManager.UpdateCoins(500);
//						gameConfigs.mee.jarToast ("500 coins added succesfully!");
//						MenuManager.mee.UpdateUI();
//					}
//				}
//			});
//		} else 
//		{
//			if(gameConfigs.mee)
//				gameConfigs.mee.jarToast ("Video is getting ready, please wait");
//
//		}

	}
}
