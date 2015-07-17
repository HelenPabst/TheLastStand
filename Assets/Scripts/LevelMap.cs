using UnityEngine;
using System.Collections;

public class LevelMap : MonoBehaviour {
	private Animator animator;
	// Use this for initialization
	void Start () 
	{
		animator = this.GetComponent<Animator>();
		animator.SetInteger("Selection", 0);
		//animator.SetBool("Select2", false);
		//animator.SetBool("Select3", false);
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	public void SelectLvl1()
	{
		animator.SetInteger("Selection", 1);
	}
	public void SelectLvl2()
	{
		animator.SetInteger("Selection", 2);
	}
	public void SelectLvl3()
	{
		animator.SetInteger("Selection", 3);

	}
	public void NoSelection()
	{
		animator.SetInteger("Selection", 0);
	}
}
