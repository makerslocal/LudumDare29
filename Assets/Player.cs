using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		renderer.material.color = Color.red;
	}

	// Update is called once per frame
	void Update () {

		CharacterController controller = GetComponent<CharacterController>();

		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			controller.Move (new Vector2(0, 1));
		}
		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			controller.Move (new Vector2(0, -1));
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			controller.Move (new Vector2(-1, 0));
		}
		if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			controller.Move (new Vector2(1, 0));
		}
	}
}
