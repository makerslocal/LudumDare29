using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour
{
	
	private Animator animator;
	
	// Use this for initialization
	void Start()
	{
		animator = this.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		
		var vertical = Input.GetAxis("Vertical");
		var horizontal = Input.GetAxis("Horizontal");

		{
			if (Input.GetMouseButtonDown((1))//the input is supposed to be a leftmouse click and "click" should correspond to a boolean value
			    {

				animation.Play("ATTACK_NORTH");//ATTACK_NORTH is the name of the attack animation and direction
			}
			
			else if (Input.GetMouseButtonDown(1)) {
				animation.Play("ATTACK_EAST");
			}
			
			else if (Input.GetMouseButtonDown(1)) {
				animation.Play("default_foward_attack");
			}
			
			else if (Input.GetMouseButtonDown(1)) {
				animation.Play("ATTACK_WEST");
			}
		}//if the code does run, clicking doesnt affect the sprite
	
	if (vertical > 0)//everything here down is good to go
	{
		animator.SetInteger("Direction", 2);

	}
	else if (vertical < 0)
	{
		animator.SetInteger("Direction", 0);

	}
	else if (horizontal > 0)
	{
		animator.SetInteger("Direction", 1);

	}
	else if (horizontal < 0)
	{
		animator.SetInteger("Direction", 3);

	}
	}
}