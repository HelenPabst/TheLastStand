using UnityEngine;
using System.Collections;

public class BossSpawnPoint : MonoBehaviour {
	public Transform boss;
	//Time until the secret boss appear
	public float TimeAppear;
	public int id;
	private Vector2 sPosition;


	void Awake() {
		switch (id) {
		case 1:
			TimeAppear = 40;
			break;
		case 2:
			TimeAppear = 80;
			break;
		case 3:
			TimeAppear = 120;
			break;
		case 4:
			TimeAppear = 160;
			break;
			
		}
		
	}

	// Use this for initialization
	void Start () {    
		//makes spawnpoints invisible during gameplay
		renderer.enabled = false;
		sPosition = new Vector2(transform.position.x, transform.position.y);
		InvokeRepeating("bossAppear", TimeAppear,40);
	}
	
	void bossAppear() {
		boss.name = "Boss" + id;
		if (!GameObject.Find ("Boss" + id + "(Clone)")) {
			Instantiate (boss);
			boss.transform.position = sPosition;
			} 
		}
}
