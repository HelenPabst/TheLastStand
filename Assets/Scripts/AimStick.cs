using UnityEngine;
using System.Collections;

public class AimStick : MonoBehaviour {
	
	public GameObject aimBase;
	Vector3 aimStandardPosition;
	public float angle;
	Vector3 dir;
	public float fireAimOffset;
	//Vector3 cameraPos;
	Controls controlScript;
	Player playerScript;
	//private bool firstTap = false;
	private float doubleTapTimer = 0;


	private float maxStickDist = 8;
	// Use this for initialization
	void Start () 
	{
		playerScript = (Player)GameObject.Find("Player").GetComponent("Player");
		//cameraPos = Camera.main.transform.position;
		//cameraHeight = Camera.main.orthographicSize;
		//cameraWidth = Camera.main.orthographicSize* Screen.width / Screen.height;
		aimStandardPosition = new Vector3 (aimBase.transform.position.x, aimBase.transform.position.y,this.transform.position.z);
		controlScript = (Controls)GameObject.Find("Controls").GetComponent("Controls");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(doubleTapTimer > 0)
		{
			doubleTapTimer-=Time.deltaTime;
		}
		else if (doubleTapTimer < 0)
		{
			doubleTapTimer = 0;
		}
		//cameraPos = Camera.main.transform.position;

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
		
				if(maxStickDist > (Mathf.Sqrt(Mathf.Pow((worldPos.y-aimStandardPosition.y),2)+Mathf.Pow((worldPos.x-aimStandardPosition.x),2))))//(worldPos.x > ((cameraPos.x)+5)&&(worldPos.y < cameraPos.y))//maxStickDist < (Mathf.Sqrt(Mathf.Pow((worldPos.y-aimStandardPosition.y),2)+Mathf.Pow((worldPos.x-aimStandardPosition.x),2))))//
				{
					if (touch.phase == TouchPhase.Began)
					{
						if(doubleTapTimer == 0)
						{
							//set how long player has to tap again
							doubleTapTimer = 0.5f;
						}
						else
						{
							playerScript.Fire();
						}
						/*if(firstTap == true)
						{
							playerScript.Fire();
						}
						else
						{
							firstTap = true;
						}*/
					}
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
	public void EndCatch()
	{
		controlScript.grab = false;
	}
	public Vector3 getTransform() {
		//removed center neutral zone
		/*if (Vector2.Distance(transform.position, aimStandardPosition) < 1) {
			return new Vector3 (0, 0, 0);
		} else { */
			return new Vector3(Mathf.Cos(angle * Mathf.PI/180) * -1, Mathf.Sin(angle * Mathf.PI/180) * -1);
		//}
	}
}