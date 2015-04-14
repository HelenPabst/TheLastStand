using UnityEngine;
using System.Collections;

public class KillCount : MonoBehaviour {
	private Animator animator;
	Player playerScript;
	int kills, killsOnes, killsTens, killsHundreds;
	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
		playerScript = GameObject.Find("Player").GetComponent<Player>();
		//playerScript = transform.parent.GetComponent<Player>();
		kills = (int)playerScript.kills;
		Debug.Log (kills);
	}
	
	// Update is called once per frame
	void Update () {
		kills = (int)playerScript.kills;
		killsOnes = kills % 10;
		kills = kills /10;
		killsTens = kills % 10;
		kills = kills /10;
		killsHundreds = kills % 10;


		if (this.gameObject.name.Equals ("KillCountOnes")) 
		{
			animator.SetInteger ("KillCountOnes", killsOnes);
		}
		if (this.gameObject.name.Equals ("KillCountTens")) 
		{

			animator.SetInteger ("KillCountTens", killsTens);
		}
		if (this.gameObject.name.Equals ("KillCountHundreds")) 
		{
			animator.SetInteger ("KillCountHundreds", killsHundreds);
		}
	}
}
