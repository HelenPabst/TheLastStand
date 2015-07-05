using UnityEngine;
using System.Collections;

public class TempEnding : MonoBehaviour {

	public GameObject cutscene;
	public GameObject[] fires = new GameObject[3];
	public int fireIndex = 0;
	public float speed = -18;
	public string level;
	public float runTime;
	public float scrollEnd;
	public AudioSource audioSource;

	// Use this for initialization
	void Start () 
	{
		Invoke("FadeOutMusic", 26.0f);
		Invoke("Ignite", 9.0f);
		Invoke("Ignite", 14.0f);
		Invoke("Ignite", 21.0f);
		InvokeRepeating("cutsceneTime", 0, 1);

	}
	
	// Update is called once per frame
	void Update () {
		///runtime decrements, when it reaches the scrollend value the image stops moving
		/// when it reaches 0, the level jumps to credits
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
	void Ignite()
	{
		GameObject currentFire = fires[fireIndex];
		currentFire.SetActive (true);
		fireIndex++;
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
