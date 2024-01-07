using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArrowPanelAnimation : MonoBehaviour
{

    public bool StartAnimation = true;
    public float AnimationSpeed=1f;
    public bool ToLeft = false;
	public bool backward=false;
	public bool front=false;

    public float offset = 0;
	public int indexValue=0;

    void Update()
    {
        
            offset = Time.time * AnimationSpeed;

			if(front)
			{
				if (backward) offset *= -1;
			
				GetComponent<Renderer>().materials[indexValue].mainTextureOffset = new Vector2(GetComponent<Renderer>().material.mainTextureOffset.x, offset);
				
				//renderer.materials[1].mainTextureOffset = new Vector2(offset, renderer.material.mainTextureOffset.y);
				if (offset >= 10 || offset <= -10) offset = 0;
			}
			else{
				if (ToLeft) offset *= -1;

				//renderer.materials[1].mainTextureOffset = new Vector2(renderer.material.mainTextureOffset.x, offset);
				
				GetComponent<Renderer>().materials[indexValue].mainTextureOffset = new Vector2(offset, GetComponent<Renderer>().material.mainTextureOffset.y);
				if (offset >= 10 || offset <= -10) offset = 0;
			}
           
       

    }
}
