using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonAnims : MonoBehaviour
{

		public  MoveUIBase[] _buttons;
		bool firstTime;
		public bool blackScreen, mb_IsOnStart;
		public GameObject _blackTexture;


		void OnEnable ()
		{


				if (firstTime == false) {
						firstTime = true;
						return;
				}

	

		}

	 

		void Start ()
		{
				
				_buttons = gameObject.GetComponentsInChildren<MoveUIBase> ();//new MoveUIBase[transform.childCount];
//				for (int i = 0; i < _buttons.Length; i++) {
//						_buttons [i] = _buttons [i].GetComponent<MoveUIBase> ();
//			
//				}
				if (mb_IsOnStart)
						CallAllAnims (); 
		}

		public void CallAllAnims ()
		{

		Debug.Log("showanims");
				if (blackScreen)
						//_blackTexture.GetComponent<Texture> ().enabled = true;
				for (int i = 0; i < _buttons.Length; i++) {
			if (_buttons [i] != null){
								_buttons [i].CallStart ();
			}
				}


		}

		public void ReverseAll ()
		{
				if (blackScreen)
						//_blackTexture.GetComponent<GUITexture> ().enabled = false;
				for (int i = 0; i < _buttons.Length; i++) {
						if (_buttons [i] != null)
								_buttons [i].Reverse ();
				}
		}
}
