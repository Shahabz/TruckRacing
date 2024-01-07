using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObj : MonoBehaviour {
	public float _xx = 0.9f;
	public float _yy=0.9f;
	public float _time = 1;
	public float _delay = 0;
	public iTween.EaseType _easetype=iTween.EaseType.linear;
	public iTween.LoopType _looptype=iTween.LoopType.pingPong;
	// Use this for initialization
	void Start () {

		iTween.ScaleFrom (this.gameObject,iTween.Hash("x",_xx,"y",_yy,"time",_time,"delay",_delay,"easetype",_easetype,"looptype",_looptype));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
