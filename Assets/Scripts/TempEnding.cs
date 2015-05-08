using UnityEngine;
using System.Collections;

public class TempEnding : MonoBehaviour {

	public GameObject cutscene;
	public int speed = -18;
	public string level;
	public float runTime;
	public float scrollEnd;
	public AudioSource endMusic;
	public float audio1Volume  = 1.0f;
	// Use this for initialization
	void Start () 
	{
		Invoke("fadeOut", 35.0f);
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
	void fadeOut() {
		while(audio1Volume > 0.1)
		{
			audio1Volume -= 0.1f * Time.deltaTime;
			endMusic.volume = audio1Volume;
		}
	}
}
