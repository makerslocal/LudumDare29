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

				var vertical = Input.GetAxis ("Vertical");
				var horizontal = Input.GetAxis ("Horizontal");
				var Click1 =Input.GetMouseButtonDown(1);


		 
		if (Input.GetMouseButtonDown(1)==(true))
	    	{
			animator.Play("ATTACK_NORTH");
			//should input else play default walking anitmation? idk if the second module will override this
			}

		else if (Input.GetMouseButtonDown(1)==(true))
	        {
			animator.Play("ATTACK_EAST");
			}
			
		else if (Input.GetMouseButtonDown(1)==(true))

	        {
			animator.Play("default_foward_attack");
			}
			
		else if (Input.GetMouseButtonDown(1)==(true))
	        {
				animator.Play("ATTACK_WEST");
			}
	

	if (vertical > 0)
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