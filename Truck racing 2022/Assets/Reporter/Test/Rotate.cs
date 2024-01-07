using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{

	Vector3 angle;
	// Use this for initialization
	void Start ()
	{
		angle = transform.localEulerAngles;
		//Debug.Log (_myAxis);
	}
	
	// Update is called once per frame
	public myEnum _myAxis;
	public float speed = 100;

	void Update ()
	{
		//angle.y += Time.deltaTime * 100 ;
		//transform.localEulerAngles = angle ;
		if (_myAxis == myEnum.x) {
			transform.Rotate (Vector3.right * speed * Time.deltaTime);
		} else if (_myAxis == myEnum.y) {
			transform.Rotate (Vector3.up * speed * Time.deltaTime);
		} else if (_myAxis == myEnum.z) {
			transform.Rotate (Vector3.forward * speed * Time.deltaTime);
		}else if(_myAxis ==myEnum.b){
			transform.Rotate (Vector3.back * speed * Time.deltaTime);

		}else if(_myAxis ==myEnum.d){
			transform.Rotate (Vector3.down * speed * Time.deltaTime);

		}else if(_myAxis ==myEnum.l){
			transform.Rotate (Vector3.left * speed * Time.deltaTime);

		}

		//transform.Rotate(new Vector3(aa,))
	}

	public enum myEnum
	{
		x,
y,
z,
b,
		d,l
	}
}
