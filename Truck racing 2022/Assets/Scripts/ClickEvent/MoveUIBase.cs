using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoveUIBase:MonoBehaviour
{
		public bool xDir, yDir, left, up, scale, popup, directPlay;
		public float distance, time, delay, revdelay, alphaVal;
		public float _val;
		public iTween.EaseType effectType;
		public iTween.LoopType loopType;
		public int addValue;
		public Vector3 _pos;
		public bool alphaFade, withReverse, moveToPos;

		[Space (15)]
		public bool IsText;
		public Color _textColor = Color.white;
		//	void OnEnable()
		//	{
		//		if(alphaFade)
		//		_temp = this.guiTexture.color;
		//	}
		void Awake ()
		{
				if (_val == 0)
						_val	= transform.localScale.x - 0.5f;

				if (addValue == 0)
						addValue = 1;

				if (alphaVal == 0)
						alphaVal	= 1f;

				if (time == 0)
						time = 1;
				if (xDir) {
						Vector3 temp = transform.position;
						_val = temp.x;
						if (left)
								temp.x -= addValue;
						else
								temp.x += addValue; 
			
			
						transform.position = temp;
				}
				if (yDir) {
						Vector3 temp = transform.position;
						_val = temp.y;
						if (up)
								temp.y += addValue;
						else
								temp.y -= addValue; 
			
						transform.position = temp;
				}
		
				if (directPlay) {
						CallStart ();
				}
		//Debug.Log("ui name "+gameObject.name);
				if (IsText && alphaFade)
						gameObject.GetComponent<Text> ().color	= new Color (_textColor.r, _textColor.g, _textColor.b, 0);
				else
						_textColor	= gameObject.GetComponent<Image> ().color;

//		if(alphaFade)
//			this.guiTexture.color		= new Color(0.5f,0.5f,0.5f,0);
		
		}
		public void CallStart ()
		{
		
				if (popup) {
						iTween.ScaleFrom (this.gameObject, iTween.Hash ("x", _val, "y", _val, "time", time, "delay", delay, "looptype", loopType, "easetype", effectType));
				}
		
				if (scale) {
						iTween.ScaleAdd (this.gameObject, iTween.Hash ("x", -0.5f, "y", -0.5f, "time", time, "delay", delay, "looptype", loopType, "easetype", effectType));
				}
				if (alphaFade) {
						if (IsText) {
								_textColor	= _textColor;
//				gameObject.GetComponent<GUIText>().color	= _textColor;
//				iTween.ColorTo(this.gameObject,iTween.Hash("color",_textColor,"time",time,"delay",delay));

								iTween.ValueTo (this.gameObject, iTween.Hash ("from", this.gameObject.GetComponent<Text> ().color.a, "to", alphaVal, "time", (time - 0.1f), "delay", delay, "easetype", effectType, "onupdate", "TextFade", "oncomplete", "OnTextFadeComplete", "oncompletetarget", this.gameObject));
						} else {

								iTween.ValueTo (this.gameObject, iTween.Hash ("from", this.gameObject.GetComponent<Image> ().color.a, "to", alphaVal, "time", (time - 0.1f), "delay", delay, "easetype", effectType, "onupdate", "SpriteFade", "oncomplete", "OnSpriteFadeComplete", "oncompletetarget", this.gameObject));
						}
//				iTween.FadeTo(this.gameObject,iTween.Hash("alpha",alphaVal,"time",time,"delay",delay));
			
				}
				if (moveToPos) {
						iTween.MoveTo (this.gameObject, iTween.Hash ("position", _pos, "looptype", loopType, "time", time, "easeType", effectType, "delay", delay));
				}
				if (alphaFade == false)
						Call ();
		
		}

		public void TextFade (float value)
		{
				this.gameObject.GetComponent<Text> ().color = new Color (this.gameObject.GetComponent<Text> ().color.r, this.gameObject.GetComponent<Text> ().color.g, this.gameObject.GetComponent<Text> ().color.b, value);
		}

		public void OnTextFadeComplete ()
		{
				this.gameObject.GetComponent<Text> ().color = new Color (this.gameObject.GetComponent<Text> ().color.r, this.gameObject.GetComponent<Text> ().color.g, this.gameObject.GetComponent<Text> ().color.b, alphaVal);
		}

		public void SpriteFade (float value)
		{
				this.gameObject.GetComponent<Image> ().color = new Color (this.gameObject.GetComponent<Image> ().color.r, this.gameObject.GetComponent<Image> ().color.g, this.gameObject.GetComponent<Image> ().color.b, value);
		}

		public void OnSpriteFadeComplete ()
		{
				this.gameObject.GetComponent<Image> ().color = new Color (this.gameObject.GetComponent<Image> ().color.r, this.gameObject.GetComponent<Image> ().color.g, this.gameObject.GetComponent<Image> ().color.b, alphaVal);
		}

		public void OnSpriteFadeReverseComplete ()
		{
				this.gameObject.GetComponent<Image> ().color = new Color (this.gameObject.GetComponent<Image> ().color.r, this.gameObject.GetComponent<Image> ().color.g, this.gameObject.GetComponent<Image> ().color.b, 0);
		}

		public void OnTextFadeReverseComplete ()
		{
				this.gameObject.GetComponent<Text> ().color = new Color (this.gameObject.GetComponent<Text> ().color.r, this.gameObject.GetComponent<Text> ().color.g, this.gameObject.GetComponent<Text> ().color.b, 0);
		}

		void Call ()
		{
		
				if (xDir) {
			
						iTween.MoveTo (this.gameObject, iTween.Hash ("x", _val, "looptype", loopType, "time", time, "easeType", effectType, "delay", delay));
				} 
				if (yDir) {
						iTween.MoveTo (this.gameObject, iTween.Hash ("y", _val, "looptype", loopType, "time", time, "easeType", effectType, "delay", delay));
				}
		
		}

		public	void Reverse ()
		{
				if (xDir) {
						//				_val = transform.position.x;
						if (left)
								iTween.MoveTo (this.gameObject, iTween.Hash ("x", _val - 1, "looptype", loopType, "time", time, "delay", revdelay, "easeType", effectType));
						else
								iTween.MoveTo (this.gameObject, iTween.Hash ("x", _val + 1, "looptype", loopType, "time", time, "delay", revdelay, "easeType", effectType));		
				} 
				if (yDir) {
						//				_val = transform.position.y;
						if (up)
								iTween.MoveTo (this.gameObject, iTween.Hash ("y", _val + 1, "looptype", loopType, "time", time, "delay", revdelay, "easeType", effectType));
						else
								iTween.MoveTo (this.gameObject, iTween.Hash ("y", _val - 1, "looptype", loopType, "time", time, "delay", revdelay, "easeType", effectType));		
				}
				if (alphaFade) {
			
						// 			this.guiTexture.color = _temp;
						if (IsText) {
								iTween.ValueTo (this.gameObject, iTween.Hash ("from", this.gameObject.GetComponent<Text> ().color.a, "to", 0, "time", time, "delay", revdelay, "easetype", effectType, "onupdate", "TextFade", "oncomplete", "OnTextFadeReverseComplete", "oncompletetarget", gameObject));
//					gameObject.GetComponent<GUIText>().color	= new Color(_textColor.r,_textColor.g,_textColor.b,0);;
								//				iTween.ColorTo(this.gameObject,iTween.Hash("color",_textColor,"time",time,"delay",delay));
						} else
								iTween.ValueTo (this.gameObject, iTween.Hash ("from", this.gameObject.GetComponent<Image> ().color.a, "to", _textColor.a, "time", time, "delay", revdelay, "easetype", effectType, "onupdate", "SpriteFade", "oncomplete", "OnSpriteFadeReverseComplete", "oncompletetarget", gameObject));
//				iTween.FadeTo(this.gameObject,iTween.Hash("alpha",0,"time",0.5,"delay",revdelay ));
			
				}
		
		}

		public void CallWithReverse ()
		{
		
				if (xDir) {
			
						iTween.MoveTo (this.gameObject, iTween.Hash ("x", _val, "delay", delay, "looptype", loopType, "time", time, "easeType", effectType));
				} 
				if (yDir) {
						iTween.MoveTo (this.gameObject, iTween.Hash ("y", _val, "delay", delay, "looptype", loopType, "time", time, "easeType", effectType));
				}
				Invoke ("Reverse", time + 1);
		}
}
