using UnityEngine;
using System.Collections;

public class StartMenu: MonoBehaviour {

	bool Window1 = true;
	bool Window2 = false;

	void OnGUI () {

		Rect windowRect = new Rect(20, 20, 120, 50);

		if(Window1)
		{
			windowRect = GUI.Window(1, windowRect, DoWindow1, "My Window 1");
		}

		if(Window2)
		{
			windowRect = GUI.Window(2, windowRect, DoWindow2, "My Window 2");
		}
	}
	
	void DoWindow1(int windowID) {
		if (GUI.Button(new Rect(10, 20, 100, 20), "Open Window 2"))
		{
			Window1 = false;
			Window2 = true;
		}
	}
	
	void DoWindow2(int windowID) {
		if (GUI.Button(new Rect(10, 20, 100, 20), "Open Window 1"))
		{
			Window1 = true;
			Window2 = false;
		}
	}
}