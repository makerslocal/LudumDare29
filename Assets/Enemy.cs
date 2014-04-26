using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private Transform player;

	// Use this for initialization
	void Start () {
		renderer.material.color = Color.green;
	}

	void OnEnable () {
		GameTick.TickEvent += Move;
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void OnDisable () {
		GameTick.TickEvent -= Move;
	}

	void Move () {
		if (player.position.y < transform.position.y) {
			transform.Translate (new Vector2 (0, 1));
		}
		if (player.position.y > transform.position.y) {
			transform.Translate (new Vector2 (0, -1));
		}
		if (player.position.x < transform.position.x) {
			transform.Translate (new Vector2 (1, 0));
		}
		if (player.position.x > transform.position.x) {
			transform.Translate (new Vector2 (-1, 0));
		}
	}

	// Update is called once per frame
	void Update () {

  		//transform.Translate(new Vector2(0, 1));
		//transform.Translate(new Vector2(0, -1));
		//transform.Translate(new Vector2(-1, 0));
		//transform.Translate(new Vector2(1, 0));
	}
}
