using UnityEngine;
using System.Collections;

public class WebViewExit : MonoBehaviour
{
	[HideInInspector]
	public bool IsMoreGamesShowing;
	[HideInInspector]
	public bool IsExitShowing;

	public static string ExitPageURL = "";
	// Use this for initialization
	public static WebViewExit instance;

	void Awake ()
	{
		instance = this;
	}




	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			ShowExit ();
		}

	}

	public void ShowExit()
	{
//		ExitPageURL = gameConfigs.mee.ExitPageURL;

			using (AndroidJavaClass javaClass = new AndroidJavaClass ("com.timuz.moregames.webViewClass")) {

				if (IsMoreGamesShowing) {
					javaClass.CallStatic ("hideWebView");
					IsMoreGamesShowing = false;

				} else {
					if (IsExitShowing) {
						javaClass.CallStatic ("hideWebView");
						IsExitShowing = false;
					} else {
						if (ExitPageURL != "") {
//							javaClass.CallStatic ("showWebView", ExitPageURL, ImageLoader.mee.gamePackageName);
							IsExitShowing = true;
						} else {
							if (Application.loadedLevelName.Contains ("Level") == true && Application.loadedLevelName != "Levelcomplete") {
								if (GameObject.Find ("UIcontrols(Clone)") != null) {
									GameObject.Find ("UIcontrols(Clone)").SendMessage ("Quitpagefunc");
								} else {
									Application.Quit ();
								}

							} else {
								Application.Quit ();
							}
						}
					}
				}

		}
	}
}
