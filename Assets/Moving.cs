using UnityEngine;

public abstract class Moving : MonoBehaviour {

	protected bool Move(int X, int Y) {
		
		X += Mathf.RoundToInt (transform.position.x);
		Y += Mathf.RoundToInt (transform.position.y);
		
		if (X < 0) {
			return false;
		}
		
		if (Y < 0) {
			return false;
		}
		
		if (X >= Map.Width) {
			return false;
		}
		
		if (Y >= Map.Height) {
			return false;
		}
		
		if (Map.Walls [X, Y] != null) {
			return false;
		}
		
		transform.position = new Vector2 (X, Y);

		return true;
	}
}