using UnityEngine;
using System.Collections;

public class InkSplatter : MonoBehaviour {

	public void removeInk()
	{
		ObjectPool.instance.PoolObject(transform.root.gameObject);
	}
}
