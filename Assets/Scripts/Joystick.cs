using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Joystick : MonoBehaviour {
	
	public GameObject joyBase;
	public Text debugger;
	Vector3 standardPosition;
	public float angle;
	Vector3 dir;
	public GameObject catchButton,fireButton;
	SpriteRenderer catchRender, fireRender;
	//Color fadedButton, pressedButton;
	public float fireAimOffset;

	Player playerScript;
	Controls controlScript;
	float cameraHeight;
	float cameraWidth;
	Vector3 cameraPos;

	// Use this for initialization
	void Start () {
		//catchButton.SetActive (false);
		//fireButton.SetActive (false);
		//fadedButton = new Color (255,255,255,34);
		//pressedButton = new Color (255,255,255,180);
		//catchRender = catchButton.GetComponent<SpriteRenderer> ();
		//fireRender = fireButton.GetComponent<SpriteRenderer> ();
		//catchRender.color = fadedButton;
		//fireRender.color = fadedButton;
		cameraPos = Camera.main.transform.position;
		//cameraHeight = Camera.main.orthographicSize;
		//cameraWidth = Camera.main.orthographicSize* Screen.width / Screen.height;
		standardPosition = new Vector3 (joyBase.transform.position.x, joyBase.transform.position.y, this.transform.position.z);
		playerScript = (Player)GameObject.Find("Player").GetComponent("Player");
		controlScript = (Controls)GameObject.Find("Controls").GetComponent("Controls");
	}
	
	// Update is called once per frame
	void Update () {
		//catchButton.SetActive (false);
		//fireButton.SetActive (false);
		//update camera position and standard every frame
		cameraPos = Camera.main.transform.position;
		standardPosition = new Vector3 (joyBase.transform.position.x, joyBase.transform.position.y, this.transform.position.z);
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
					//for each touch, if the touch is moved...
			
					///and if it is on the left side of the screen...
				/// offset 5 units to left of center
					if(worldPos.x < ((cameraPos.x)-5))//(Camera.main.transform.position.x))
					{
							if(touch.phase == TouchPhase.Moved)
							{
							//set the position of the pad to the touch position
							transform.position = padPos;//Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
							//keep control pad visible
							//transform.position = new Vector3(transform.position.x,transform.position.y, -2);
							}
							else if (touch.phase == TouchPhase.Ended)
							{
							standardPosition = new Vector3 (joyBase.transform.position.x, joyBase.transform.position.y, this.transform.position.z);
							transform.position = standardPosition;
							}
					Vector3 dir = standardPosition - transform.position;
					angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
					} 

					//code for fire and catch

					///if it is on the upper right side of the screen...
					if((worldPos.x > (cameraPos.x+fireAimOffset))&&(worldPos.y < cameraPos.y))//-buttonOffset)))
					{
							//Catch
						if (touch.phase == TouchPhase.Began)
						{
							//catchButton.SetActive(true);
							controlScript.Catch();
							//catchRender.color = pressedButton;
							Invoke("EndCatch", 0.2f);
						}
						if (touch.phase == TouchPhase.Moved)
						{
							//catchRender.color = fadedButton;
                        	//catchButton.SetActive(false);
						}
						if (touch.phase == TouchPhase.Ended)
						{
							//catchRender.color = fadedButton;
                        	//catchButton.SetActive(false);
						}
					} 
					//fire button triggers up to 6 units to right of center
					if((worldPos.x>= cameraPos.x)&&(worldPos.y >= cameraPos.y))//-buttonOffset)))
					{
							//fire
						if (touch.phase == TouchPhase.Began)
						{
							//fireButton.SetActive(true);
							playerScript.Fire();
							//fireRender.color = pressedButton;
							//fireButton.SetActive(true);
						}
						if (touch.phase == TouchPhase.Moved)
						{
							//fireRender.color = fadedButton;
                        	//fireButton.SetActive(false);
						}
						if (touch.phase == TouchPhase.Ended)
						{
							//fireRender.color = fadedButton;
							//fireButton.SetActive(false);
						}
							
					} 
////////////////moved from here
					
					
				}
			}
		//if there are no touches, reset the pad
		else 
		{
			standardPosition = new Vector3 (joyBase.transform.position.x, joyBase.transform.position.y, this.transform.position.z);
			transform.position = standardPosition;
		}
	}

	public void EndCatch()
	{
		controlScript.grab = false;
	}

	public Vector3 getTransform() {
		if (Vector2.Distance(transform.position, standardPosition) < 1) {
			return new Vector3 (0, 0, 0);
		} else {
			return new Vector3(Mathf.Cos(angle * Mathf.PI/180) * -1, Mathf.Sin(angle * Mathf.PI/180) * -1);
		}
	}
}