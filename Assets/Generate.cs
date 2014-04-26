using UnityEngine;
using System.Collections;

public class Generate : MonoBehaviour {

	// Use this for initialization
	void Start () {

		int count = Random.Range (20, 30);

		for (int i = 0; i < count; i++) {

			int x = Random.Range (-10, 10);
			int y = Random.Range (-10, 10);

			GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
			quad.transform.position = new Vector2(x, y);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}