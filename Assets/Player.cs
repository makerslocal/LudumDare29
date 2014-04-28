using UnityEngine;
using System.Collections;

public class Player : Moving {
	
	void Start () {

		Map.Player = this;

		while(!Move (0,0))
		{
			transform.position = new Vector2 (Random.Range (0, Map.Width), Random.Range (0, Map.Height));
		}

		renderer.material.color = Color.red;
	}
	
	void Update () {

		if(Input.GetKeyDown(KeyCode.UpArrow)) {
			Move (0,1);
		}
		if(Input.GetKeyDown(KeyCode.DownArrow)) {
			Move (0,-1);
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow)) {
			Move (-1,0);
		}
		if(Input.GetKeyDown(KeyCode.RightArrow)) {
			Move (1,0);
		}

		if(Camera.main == null)
		{
			return;
		}

		Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
	}
}
