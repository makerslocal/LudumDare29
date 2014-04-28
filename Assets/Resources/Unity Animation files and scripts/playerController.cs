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
		bool Click1 = Input.GetMouseButton(0);	
		var vertical = Input.GetAxis("vertical");
		var horizontal = Input.GetAxis("horizontal");
		
		if (vertical > 0)
		{
			animator.SetInteger("Direction", 2);
			if (Click1==true) 
			{
				animator.Play("ATTACK_NORTH");
			}

		}
			
		else if (vertical < 0)
		{
			animator.SetInteger("Direction", 0);

			if (Click1==true)
				{
			
				animator.Play("ATTACK_SOUTH");
			
			}

		}


		else if (horizontal > 0)
		{
			animator.SetInteger("Direction", 1);

		if (Click1==true)
			{
			
			animator.Play("ATTACK_EAST");
			}
		}


		else if (horizontal < 0)
		{
			animator.SetInteger("Direction", 3);
		 if (Click1==true) 
			{
				animator.Play("default_foward_attack");
			}
		}

		
		}

}
