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
	//value brings the division between catch and fire buttons down
	//by the offset amount
	float buttonOffset = 100;

	Player playerScript;
	Controls controlScript;
	float cameraHeight;
	float cameraWidth;
	Vector3 cameraPos;

	// Use this for initialization
	void Start () {
		catchButton.SetActive (false);
		fireButton.SetActive (false);
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
					//for each touch, if the touch is moved...
			
					///and if it is on the left side of the screen...
					if(worldPos.x < (cameraPos.x))//(Camera.main.transform.position.x))
					{
							if(touch.phase == TouchPhase.Moved)
							{
							//set the position of the pad to the touch position
							transform.position = worldPos;//Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
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

				//	else if (touch.phase == TouchPhase.Began)
				//	{
					///if it is on the upper right side of the screen...
					if((worldPos.x >= cameraPos.x)&&(worldPos.y >= cameraPos.y))//-buttonOffset)))
					{
							//Catch
						if (touch.phase == TouchPhase.Began)
						{
							//catchButton.SetActive(true);
							controlScript.Catch();
							catchButton.SetActive(true);
							Invoke("EndCatch", 0.2f);
						}
						if (touch.phase == TouchPhase.Ended)
						{
							catchButton.SetActive(false);
						}
					} 

					if((worldPos.x>= cameraPos.x)&&(worldPos.y < cameraPos.y))//-buttonOffset)))
					{
							//fire
						if (touch.phase == TouchPhase.Began)
						{
							//fireButton.SetActive(true);
							playerScript.Fire();
							fireButton.SetActive(true);
						}
						if (touch.phase == TouchPhase.Ended)
						{
							fireButton.SetActive(false);
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