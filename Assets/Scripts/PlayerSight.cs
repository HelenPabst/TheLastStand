using UnityEngine;
using System.Collections;

public class PlayerSight : MonoBehaviour {
	Player playerScript;
	LineRenderer lineRenderer;
	public Color defaultColor = Color.white;
	public Color fullAmmo = Color.green;
	public Color emptyAmmo = Color.red;

	// Use this for initialization
	void Start () {
		playerScript = transform.parent.GetComponent<Player>();
		lineRenderer = this.GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(playerScript.ammo >= playerScript.ammoLimit )
		{
			lineRenderer.SetColors(fullAmmo, fullAmmo);
		}
		else if(playerScript.ammo <= 0)
		{
			lineRenderer.SetColors(emptyAmmo, emptyAmmo);
		}
		else{
			lineRenderer.SetColors(defaultColor, defaultColor);
		}
	}
}
