using UnityEngine;
using System.Collections;

public class StartMenu: MonoBehaviour {
	public GUISkin gooey = null;

	bool WindowMain = true;
	bool WindowMechanics = false;
	bool WindowCredits = false;

	void OnGUI () {
		GUI.skin = gooey;

		Rect windowRect = new Rect(Screen.width*0.45f, Screen.height*0.45f, 120, 50);
		Rect windowRect1 = new Rect (Screen.width * 0.45f, Screen.height * 0.45f, 500, 500);

		if(WindowMain)
		{
			windowRect = GUILayout.Window(0, windowRect, DoWindowMain, "");
		}

		if(WindowMechanics)
		{
			windowRect = GUI.Window(1, windowRect1, DoWindowMechanics, "Game Mechanics");
		}

		if (WindowCredits) 
		{
			windowRect = GUILayout.Window (2, windowRect, DoWindowCredits, "Credits");
		}
	}

	void DoWindowMain(int windowID) {
		GUILayout.Label("This is an sized label");
		if (GUILayout.Button("Start"))
		{
			WindowMain = false;
			Application.LoadLevel(0);
			// Load character generation (random at this time)
			// Automatically load a random level after
		}
		if (GUILayout.Button ("How to Play"))
		{
			WindowMain = false;
			WindowMechanics = true;
		}
		if (GUILayout.Button ("Credits")) 
		{
			WindowMain = false;
			WindowCredits = true;
		}
	}
	
	void DoWindowMechanics(int windowID) {
		if (GUILayout.Button("Back"))
		{
			WindowMain = true;
			WindowMechanics = false;
		}
	}

	void DoWindowCredits(int WindowID) {
		if (GUILayout.Button ("Back")) 
		{
			WindowMain = true;
			WindowCredits = false;
		}
	}
}