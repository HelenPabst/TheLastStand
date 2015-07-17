using UnityEngine;
using System.Collections;

public class LevelMap : MonoBehaviour {
	private Animator animator;
	// Use this for initialization
	void Start () 
	{
		animator = this.GetComponent<Animator>();
		//animator.SetBool("Select1", false);
		//animator.SetBool("Select2", false);
		//animator.SetBool("Select3", false);
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	public void SelectLvl1()
	{
		animator.SetBool("Select1", true);
		animator.SetBool("Select2", false);
		animator.SetBool("Select3", false);
	}
	public void SelectLvl2()
	{
		animator.SetBool("Select1", false);
		animator.SetBool("Select2", true);
		animator.SetBool("Select3", false);
	}
	public void SelectLvl3()
	{
		animator.SetBool("Select1", false);
		animator.SetBool("Select2", false);
		animator.SetBool("Select3", true);
	}
	public void NoSelection()
	{
		animator.SetBool("Select1", false);
		animator.SetBool("Select2", false);
		animator.SetBool("Select3", false);
	}
}
