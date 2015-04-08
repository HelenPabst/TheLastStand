using UnityEngine;
using System.Collections;

public class BossSpawnPoint : MonoBehaviour {
	public Transform boss;
	//Time until the secret boss appear
	public float TimeAppear;
	private Vector2 sPosition;
	// Use this for initialization
	void Start () {
		
		//makes spawnpoints invisible during gameplay
		renderer.enabled = false;
		sPosition = new Vector2(transform.position.x, transform.position.y);
		Invoke("bossAppear", TimeAppear);
		
	}
	
	void bossAppear() {
		Instantiate (boss);
		boss.transform.position = sPosition;
	}
}
