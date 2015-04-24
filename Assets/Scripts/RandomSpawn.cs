using UnityEngine;
using System.Collections;

public class RandomSpawn : MonoBehaviour {
	
	private Vector2 sPosition;
	//private Animator animator;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnBoss",4, Random.Range (2,6));	
	}

	void SpawnBoss () {		
		sPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(200,Screen.width-200), 
		                                                       Random.Range(200,Screen.height-200), 
		                                                       Camera.main.farClipPlane/2));
		//Get he size of a collider at a position
		Collider2D[] hitColliders = Physics2D.OverlapCircleAll(sPosition,
		                                                       Mathf.Abs(collider2D.renderer.bounds.size.x - collider2D.renderer.bounds.size.x) + 2);
		while (hitColliders.Length != 0) {
			sPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(200,Screen.width-200), 
			                                                       Random.Range(200,Screen.height-200), 
			                                                       Camera.main.farClipPlane/2));
		}

		if (hitColliders.Length == 0) {
			//animator.SetBool ("Despawning", true);
			this.transform.position = sPosition;
			//animator.SetBool ("Spawning", true);
		}

	}
}