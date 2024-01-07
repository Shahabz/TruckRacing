using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ContentPosition : MonoBehaviour {

	// Use this for initialization
	public ScrollRect scroll;
	void Awake () {
//		print (PlayerPrefs.GetInt ("UnlockedLevels")+" ++ll");
//		gameObject.transform.localPosition = new Vector3 (3562-((GameData.GetSelectedLevel())*354), transform.localPosition.y, transform.localPosition.z);	
		//gameObject.transform.localPosition = new Vector3(((PlayerPrefs.GetInt ("UnlockedLevels")-1) * -380),transform.localPosition.y, transform.localPosition.z);.

		float y = scroll.normalizedPosition.y;
//		scroll.normalizedPosition=new Vector2(((PlayerPrefs.GetInt ("UnlockedLevels")-1)-(0.001*(PlayerPrefs.GetInt ("UnlockedLevels"))/20.0f),0);
		scroll.normalizedPosition=new Vector2(((PlayerPrefs.GetInt ("UnlockedLevels")-1)/20.0f),0);

	}
	
	// Update is called once per frame
			void Update () {
		
	}
}
