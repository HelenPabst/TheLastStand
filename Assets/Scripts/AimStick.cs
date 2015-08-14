using UnityEngine;
using System.Collections;

public class AimStick : MonoBehaviour {
	
	public GameObject aimBase;
	Vector3 aimStandardPosition;
	public float angle;
	Vector3 dir;
	public float fireAimOffset;
	Vector3 cameraPos;
	// Use this for initialization
	void Start () 
	{
		cameraPos = Camera.main.transform.position;
		//cameraHeight = Camera.main.orthographicSize;
		//cameraWidth = Camera.main.orthographicSize* Screen.width / Screen.height;
		aimStandardPosition = new Vector3 (aimBase.transform.position.x, aimBase.transform.position.y,this.transform.position.z);

	}
	
	// Update is called once per frame
	void Update () 
	{
		cameraPos = Camera.main.transform.position;

		aimStandardPosition = new Vector3 (aimBase.transform.position.x, aimBase.transform.position.y, this.transform.position.z);
		//transform.position = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
		
		//check if there are touches
		if (Input.touchCount > 0 ) 
		{
			//if so, cycle through the touches
			for (int i = 0; i < Input.touchCount;++i)
			{
				Touch touch; 
				touch = Input.GetTouch(i);
				Vector3 touchPos = touch.position;
				//added this for position of touch in world space
				Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(touchPos.x,touchPos.y,this.transform.position.z));
				Vector3 padPos = new Vector3(worldPos.x,worldPos.y,this.transform.position.z);
		//code for second stick
		
				if((worldPos.x>= cameraPos.x)&&(worldPos.x < (cameraPos.x+fireAimOffset))&&(worldPos.y < cameraPos.y))//-buttonOffset)))
				{
					if(touch.phase == TouchPhase.Moved)
					{
						//set the position of the pad to the touch position
						transform.position = padPos;//Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
						//keep control pad visible
						//transform.position = new Vector3(transform.position.x,transform.position.y, -2);

					}

					/*
					else if (touch.phase == TouchPhase.Ended)
					{
						aimStandardPosition = new Vector3 (aimBase.transform.position.x, aimBase.transform.position.y, this.transform.position.z);
						transform.position = aimStandardPosition;
					}
					*/
					Vector3 dir = aimStandardPosition - transform.position;
					angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);

				} 
			}
		}
		/*else ///removed to prevent return to center
		{
			aimStandardPosition = new Vector3 (aimBase.transform.position.x, aimBase.transform.position.y, this.transform.position.z);
			transform.position = aimStandardPosition;
		}*/
	}
	public Vector3 getTransform() {
		if (Vector2.Distance(transform.position, aimStandardPosition) < 1) {
			return new Vector3 (0, 0, 0);
		} else {
			return new Vector3(Mathf.Cos(angle * Mathf.PI/180) * -1, Mathf.Sin(angle * Mathf.PI/180) * -1);
		}
	}
}