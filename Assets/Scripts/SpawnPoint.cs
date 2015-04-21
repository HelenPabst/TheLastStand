using UnityEngine;
using System.Collections;


public class SpawnPoint : MonoBehaviour {
	//We can make this is a list later if multiple types of ememies need to spawn from the same point.
	public GameObject spawnEnemy;
	public float initialSpawnDelay;
	public float mainSpawnDelay;
	public int totalSpawns;
	private bool EnemyCheck = false;
	private float Timer;
	private GameObject spawnedObject;
	private Vector2 sPosition; // Spawn position
	void  Start (){
		//makes spawnpoints invisible during gameplay
		renderer.enabled = false;
		Timer = Time.time + mainSpawnDelay;
		sPosition = new Vector2(transform.position.x, transform.position.y);
		//Runs SpawnEnemy after initialSpawnDelay seconds and repeats every mainSpawnDelay seconds
		InvokeRepeating ("SpawnEnemy", initialSpawnDelay, mainSpawnDelay);
	}
	
	void  SpawnEnemy() {
		Collider2D[] hitCollidersEnemy = Physics2D.OverlapCircleAll (sPosition, 1);
		if (Timer < Time.time && !EnemyCheck) { // check if real time has caught up with timer
			if(totalSpawns != 0) { // Section of code will execute totalSpawns number of times. If totalSpawns is -1, then it will always execute
				spawnedObject = ObjectPool.instance.GetObjectForType (spawnEnemy.name, true); // Spawns enemy in game
				if (spawnedObject == null) {
					Timer += 2;
				} else {
					spawnedObject.transform.position = transform.position;
					spawnedObject.transform.rotation = transform.rotation;
					EnemyCheck = true;
					sPosition = new Vector2 (spawnedObject.transform.position.x, spawnedObject.
					                         transform.position.y);
				}
				totalSpawns--;
			}
		} else if (hitCollidersEnemy.Length == 0) {
			EnemyCheck = false;
		}
	}
}
