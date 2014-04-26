using UnityEngine;
using System.Collections;

public class AStar : MonoBehaviour {

	private Transform player; // just for now, we can add waypoints later
	private int[] path;

	// Use this for initialization
	void Start () {
	}

	void OnEnable () {
		player = GameObject.FindGameObjectWithTag("Player").transform; // our target for now
	}
	
	// UpdateAStar is called once per 'tick'
	void UpdateAStar () {
		path = FindPath (player);
	}

	int FindPath (Transform target) {
		int[] open;
		int[] closed;
		bool found = false;
		while (!found) {

		}
		return ret;
	}
}
