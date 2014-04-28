using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {
	
	void Start () {
		renderer.material.color = Color.yellow;
	}
	
	void Update () {
		
		if(!Input.GetKey(KeyCode.Space))
		{
			return;
		}
		
		if(Map.Player == null)
		{
			return;
		}
		
		int playerX = Mathf.RoundToInt(Map.Player.transform.position.x);
		int playerY = Mathf.RoundToInt(Map.Player.transform.position.y);
		
		int x = Mathf.RoundToInt(transform.position.x);
		int y = Mathf.RoundToInt(transform.position.y);
		
		if(x != playerX)
		{
			return;
		}
		
		if(y != playerY)
		{
			return;
		}

		Map.Generate ();
	}
}