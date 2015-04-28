using UnityEngine;
using System.Collections;

public class TempEnding : MonoBehaviour {

	public GameObject cutscene;
	public int speed = -18;
	public string level;
	public float runTime;
	public float scrollEnd;
	// Use this for initialization
	void Start () 
	{
		InvokeRepeating("cutsceneTime", 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
		if (runTime > scrollEnd) 
		{
			cutscene.gameObject.transform.Translate (Vector3.down * Time.deltaTime * speed);
		}
		if (runTime <= 0) 
		{
			Application.LoadLevel (level);
		}


		//Application.LoadLevel ("Credits");
	}
	void cutsceneTime()
	{
		runTime -= 1;
	}
}
