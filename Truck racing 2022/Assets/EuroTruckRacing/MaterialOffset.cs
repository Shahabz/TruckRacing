using UnityEngine;
using System.Collections;

public class MaterialOffset : MonoBehaviour {
	public float scrollSpeed = 0.5F;
	public Renderer rend;
	public bool _XOffset, _yOffset;
	void Start() {
		rend = GetComponent<Renderer>();
	}
	void Update() {
		float offset = Time.time * scrollSpeed;
		if (_XOffset) {
			rend.material.SetTextureOffset ("_MainTex", new Vector2 (offset, 0));
						
		} 
		else
		{
			rend.material.SetTextureOffset ("_MainTex", new Vector2 (0,offset));

		}
	}
}
