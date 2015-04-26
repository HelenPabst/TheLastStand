using UnityEngine;
using System.Collections;


public class SpawnPoint : MonoBehaviour {
	//We can make this is a list later if multiple types of ememies need to spawn from the same point.
	public GameObject spawnEnemy;
	//The initial spawn
	public float initialSpawnDelay;
	//the time spawn after killed
	public float spawnDelay;
	//How many times the object will spawn
	public int totalSpawns;
	private bool EnemyCheck = true;
	//keep track of the time after the enemy is killed
	private float Timer;
	//Time to keep track of enemy respawning
	private float Counter;
	private GameObject spawnedObject;
	private Vector2 sPosition; // Spawn position

	void  Start (){
		//makes spawnpoints invisible during gameplay
		renderer.enabled = false;
		Timer = 0f;
		sPosition = new Vector2(transform.position.x, transform.position.y);
		Invoke ("SpawnEnemy", initialSpawnDelay);
		Counter = 0f;
	}
	//call once per frame
	void Update() {
		Collider2D[] hitCollidersEnemy = Physics2D.OverlapCircleAll (sPosition, 1);
		Timer += Time.deltaTime;
    	if (!EnemyCheck && totalSpawns > 0) {
			spawnedObject = ObjectPool.instance.GetObjectForType (spawnEnemy.name, true); // Spawns enemy in game
	    	Timer = initialSpawnDelay;
	    	totalSpawns--;
			spawnedObject.transform.position = transform.position;
			spawnedObject.transform.rotation = transform.rotation;
			EnemyCheck = true;
			Debug.Log(spawnDelay + initialSpawnDelay);
		} 
		else if (hitCollidersEnemy.Length == 0) {
			Counter += Time.deltaTime;
			if (Counter > (spawnDelay+initialSpawnDelay)) {
			    EnemyCheck = false;
				Counter = initialSpawnDelay;
			}
		}
	}
	//For initial spawn
	void SpawnEnemy() {
		if (Timer > initialSpawnDelay && totalSpawns > 0) {
			spawnedObject = ObjectPool.instance.GetObjectForType (spawnEnemy.name, true); // Spawns enemy in game
			totalSpawns--;
			spawnedObject.transform.position = transform.position;
			spawnedObject.transform.rotation = transform.rotation;
			EnemyCheck = true;
		}
	}

}
