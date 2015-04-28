using UnityEngine;
using System.Collections;

public class CreditsText : MonoBehaviour {
	

	public int speed = -18;
	public string level;
	public float runTime;
	
	void Start()
	{
		InvokeRepeating("creditTime", 0, 1);
	}
	void Update () {
		
		this.transform.Translate (Vector3.up * Time.deltaTime * speed);
		if (runTime <= 0) 
		{
			Application.LoadLevel (level);
		}
		
	}
	
	void creditTime()
	{
		runTime -= 1;

		
	}
	
	
}