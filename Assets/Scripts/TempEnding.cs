using UnityEngine;
using System.Collections;

public class TempEnding : MonoBehaviour {

	public GameObject cutscene;
	public int speed = -18;
	public string level;
	public float runTime;
	public float scrollEnd;
	public AudioSource audioSource;

	// Use this for initialization
	void Start () 
	{
		Invoke("FadeOutMusic", 26.0f);
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

	public void FadeOutMusic()
	{
		StartCoroutine(FadeMusic());
	}
	IEnumerator FadeMusic()
	{
		while(audioSource.volume > .1F)
		{
			audioSource.volume = Mathf.Lerp(audioSource.volume,0F,0.2f*Time.deltaTime);
			yield return 0;
		}
		audioSource.volume = 0;

	}
}
