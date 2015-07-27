using UnityEngine;
using System.Collections;

public class CreditsText : MonoBehaviour {
	

	public int speed = -18;
	public string level;
	public float runTime;
	public AudioSource audioSource;
	
	void Start()
	{
		//audioSource = Camera.main.transform.Find("Main Camera").GetComponent<AudioSource>();
		if(Application.isMobilePlatform)
		{
			//on mobile, reposition credit text
			this.transform.position = this.transform.position + new Vector3(-100,0,0);
			//double its size
			this.transform.localScale = this.transform.localScale *2;
			//speed it up to accomodate size change
			speed = speed * 2;
		}
		InvokeRepeating("creditTime", 0, 1);
		Invoke("creditMusic", 1.0f);
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
	void creditMusic()
	{
		audioSource.Play();
	}
	
	
}