using UnityEngine;
using System.Collections;

public class BallistaProjectile : MonoBehaviour
{
	private double timeSpawned;
	private double selfDestructTime;
	private double currentTime;
	//added to fix rotation issue, but there could be a better way
	private Quaternion arrowRotation;
	//
	//Use this for initialization
	void Start () 
	{
		selfDestructTime = 10.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//added to fix rotation issue, but there could be a better way
		transform.rotation = arrowRotation;
		//
		currentTime += Time.deltaTime;
		if (currentTime + timeSpawned >= timeSpawned + selfDestructTime)
		{
			currentTime = 0;
			RemoveArrow();
		}
	}
	public void RemoveArrow()
	{
		this.gameObject.tag = "Untagged";
		ObjectPool.instance.PoolObject(this.gameObject);
	}
	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.tag.Equals ("Obstacle")) 
		{
			RemoveArrow();
			////added this for arrow sticking
			//this.gameObject.tag = "StuckArrow";
			//this.rigidbody2D.velocity = new Vector3 (0, 0, 0);
		}
		if (other.gameObject.name.Equals("BasicProjectile"))
		{
			other.gameObject.tag = "Untagged";
			ObjectPool.instance.PoolObject(other.gameObject);
		}
	}

}
