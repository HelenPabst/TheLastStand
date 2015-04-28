using UnityEngine;
using System.Collections;

public class CreditsText : MonoBehaviour {
	
	public GameObject camera;
	public int speed = -18;
	public string level;
	
	
	void Update () {
		
		this.transform.Translate (Vector3.down * Time.deltaTime * speed);
		
	}
	
	IEnumerator waitFor(){
		yield return new WaitForSeconds (20);
		Application.LoadLevel (level);
		
	}
	
	
}