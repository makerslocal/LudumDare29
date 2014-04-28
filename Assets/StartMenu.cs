using UnityEngine;
using System.Collections;

public class StartMenu: MonoBehaviour {
	public GUISkin gooey = null;
	public Texture2D placeholder;

	bool WindowMain = true;
	bool WindowMechanics = false;
	bool WindowCredits = false;

	void OnGUI () {
		GUI.skin = gooey;

		Rect windowRect = new Rect(Screen.width*0.45f, Screen.height*0.45f, 0, 0);
		Rect windowRect1 = new Rect ((Screen.width/2)-250, (Screen.height/2)-250, 500, 500);

		if(WindowMain)
		{
			windowRect = GUILayout.Window(0, windowRect, DoWindowMain, placeholder, GUILayout.MinWidth(200), GUILayout.MaxWidth(1000));
		}

		if(WindowMechanics)
		{
			windowRect = GUILayout.Window(1, windowRect, DoWindowMechanics, "Game Mechanics", GUILayout.MinWidth(200), GUILayout.MaxWidth(1000));
		}

		if (WindowCredits) 
		{
			windowRect = GUILayout.Window (2, windowRect, DoWindowCredits, "Credits", GUILayout.MinWidth(200), GUILayout.MaxWidth(1000));
		}
	}

	void DoWindowMain(int windowID) {
		GUILayout.Label("Main Menu");
		if (GUILayout.Button("Start"))
		{
			WindowMain = false;
			//Application.LoadLevel(0);
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