using UnityEngine;
using System.Collections;

public class CatchParticle : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		Invoke("DestroyParticle", 0.5f);
	}
	
	void DestroyParticle()
	{
		ObjectPool.instance.PoolObject(this.gameObject);
	}
}
