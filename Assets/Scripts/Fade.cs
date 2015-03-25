using UnityEngine;
using System.Collections;
public class Fade: MonoBehaviour{
	private float timeUntilFade = 10.0F;
	private float fadeLerpConstant = 0.1F;
	private float clearThreshold = 10.0F;
	
	int state = 0;
	float counter = 0F;
	
	void Awake()
	{
		counter = timeUntilFade;
	}	
	
	void Update()
	{
		switch (state)
		{
		case 0:
			counter -= Time.deltaTime;
			if (counter < 0F){
				state++;
				Debug.Log ("FADING");
			}
			break;
		case 1:
			renderer.material.color = Color.Lerp(renderer.material.color, Color.clear, fadeLerpConstant);
			Debug.Log ("HELLO");
			if(this.renderer.material.color.a < clearThreshold){
				RemoveArrow ();
			}
			break;
		}
	}
	public void RemoveArrow()
	{
		Debug.Log("Elvis has left the building");
		this.gameObject.tag = "";
		ObjectPool.instance.PoolObject(this.gameObject);

	}
}