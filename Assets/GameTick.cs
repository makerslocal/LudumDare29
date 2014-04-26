using UnityEngine;
using System.Collections;

public class GameTick : MonoBehaviour {

	public delegate void Tick();
	public static event Tick TickEvent;

	float tickLength = 1; // one second
	float elapsed = 0; // elapsed time

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		elapsed += Time.deltaTime;
		if (elapsed > tickLength) {
			elapsed = 0;
			// fire event... I hope all enemies get it
			TickEvent();
		}
	}
}