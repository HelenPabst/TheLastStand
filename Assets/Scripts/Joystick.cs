using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Joystick : MonoBehaviour {
	
	public GameObject joyBase;
	public Text debugger;
	Vector3 standardPosition;
	public float angle;
	Vector3 dir;

	// Use this for initialization
	void Start () {
		standardPosition = new Vector3 (joyBase.transform.position.x, joyBase.transform.position.y, -1);
	}
	
	// Update is called once per frame
	void Update () {

			//check if there are touches
			if (Input.touchCount > 0 ) 
			{
				//if so, cycle through the touches
				for (int i = 0; i < Input.touchCount;++i)
				{
					Touch touch; 
					touch = Input.GetTouch(i);
					//if (Input.touchCount > 0 ) {
					//for each touch, if the touch is moved...
					if(touch.phase == TouchPhase.Moved)
					{
						///and if it is on the left side of the screen...
						if(touch.position.x < (Screen.width/2))
						{
							//set the position of the pad to the touch position
							transform.position = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
							transform.position = new Vector3(transform.position.x,transform.position.y, -1);
						} 
					}


					Vector3 dir = standardPosition - transform.position;
					angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
				}
			}
			//if there are no touches, reset the pad
			else 
			{
				transform.position = standardPosition;
			}



	}

	public Vector3 getTransform() {
		if (Vector2.Distance(transform.position, standardPosition) < 1) {
			return new Vector3 (0, 0, 0);
		} else {
			return new Vector3(Mathf.Cos(angle * Mathf.PI/180) * -1, Mathf.Sin(angle * Mathf.PI/180) * -1);
		}
	}
}