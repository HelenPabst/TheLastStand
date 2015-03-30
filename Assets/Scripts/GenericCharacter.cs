using UnityEngine;
using System.Collections;

public class GenericCharacter : MonoBehaviour
{
    public double health, standardHealth, fireRate;
    public float arrowVelocity;
    protected Vector3 theta, arrowDir, arrowDirLeft, arrowDirRight;
	protected double currentTime;
	protected GameObject arrow, leftArrow, rightArrow;
    // Shared projectile object pool for all generic characters

	void Start() {
		health = standardHealth;
	}

	protected void RePool(GameObject obj) {
		//added to fix issues with projectiles being repooled
		if (obj.name.Equals("BasicProjectile")) 
		{
			obj.tag = "";
		}
		ObjectPool.instance.PoolObject(obj);
	}

	protected void fireArrow(string tag) {
		arrow = ObjectPool.instance.GetObjectForType("BasicProjectile", true);
		arrow.transform.position = transform.position;
		arrow.transform.rotation = transform.rotation;
		arrowDir = new Vector3(Mathf.Cos(transform.eulerAngles.z * Mathf.PI/180), Mathf.Sin(transform.eulerAngles.z * Mathf.PI/180));
		arrow.rigidbody2D.velocity = arrowDir * arrowVelocity;
		arrow.tag = tag;
	}

	protected void fire3Arrows(string tag) {
		fireArrow("EnemyArrow");

		leftArrow = ObjectPool.instance.getObjectForType ("BasicProjectile", true);
		leftArrow.transform.position = transform.position;
		leftArrow.transform.rotation = transform.rotation;
		arrowDirLeft = new Vector3 (Mathf.Cos (transform.eulerAngles.z * Mathf.PI / 180) - (Mathf.PI / 4), Mathf.Sin (transform.eulerAngles.z * Mathf.PI / 180) - (Mathf.PI / 4));
		leftArrow.rigidbody2D.velocity = arrowDirLeft * arrowVelocity;
		leftArrow.tag = tag;

		rightArrow = ObjectPool.instance.getObjectForType ("BasicProjectile", true);
		rightArrow.transform.position = transform.position;
		rightArrow.transform.rotation = transform.rotation;
		arrowDirRight = new Vector3 (Mathf.Cos (transform.eulerAngles.z * Mathf.PI / 180) + (Mathf.PI / 4), Mathf.Sin (transform.eulerAngles.z * Mathf.PI / 180) + (Mathf.PI / 4));
		rightArrow.rigidbody2D.velocity = arrowDirRight * arrowVelocity;
		rightArrow.tag = tag;
	}

	void OnEnable() {
		health = standardHealth;
	}
}