using UnityEngine;
using System.Collections;

public class Enemy : Moving {

	private Transform player;

	protected uint Frame
	{
		get;
		private set;
	}

	public bool IsGhost {
		get;
		protected set;
	}

	void Flee()
	{
		if (player == null) {
			player = Map.Player.transform;
		}
		
		if (player == null) {
			return;
		}
		
		if (player.position.y <= transform.position.y) {
			Move (0, 1);
		}			
		if (player.position.y >= transform.position.y) {
			Move (0, -1);
		}
		if (player.position.x <= transform.position.x) {
			Move (1, 0);
		}
		if (player.position.x >= transform.position.x) {
			Move (-1, 0);
		}
	}

	void Start () {
		renderer.material.color = Color.green;
	}

	void Update () {

		if (++Frame % 10 > 0) {
			return;
		}

		Flee ();
	}
}