using UnityEngine;
using System.Collections;

public class BallistaProjectile : MonoBehaviour
{
	private double timeSpawned;
	private double selfDestructTime;
	private double currentTime;
	//Use this for initialization
	void Start () 
	{
		selfDestructTime = 10.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		currentTime += Time.deltaTime;
		if (currentTime + timeSpawned >= timeSpawned + selfDestructTime)
		{
			currentTime = 0;
			RemoveArrow();
		}
	}
	public void RemoveArrow()
	{
		this.gameObject.tag = "";
		ObjectPool.instance.PoolObject(this.gameObject);
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag.Equals ("Obstacle")) 
		{
			////added this for arrow sticking
			this.gameObject.tag = "StuckArrow";
			this.rigidbody2D.velocity = new Vector3 (0, 0, 0);
		}
		if (other.gameObject.name.Equals("BasicProjectile"))
		{
			other.gameObject.tag = "";
			ObjectPool.instance.PoolObject(other.gameObject);
		}
	}

}
