using UnityEngine;
using System.Collections;

public class StartMenu: MonoBehaviour {
	public GUISkin gooey = null;
	public Texture2D logo;
	public Vector2 scrollPosition = Vector2.zero;

	bool WindowMain = true;
	bool WindowMechanics, WindowCredits, WindowBackground = false;

	void OnGUI () {
		logo = Resources.Load <Texture2D> ("logo");
		GUI.skin = gooey; 

		Rect windowRect = new Rect((Screen.width-200)/2, (Screen.height-100)/1.4f, 200, 100);
		Rect windowRect1 = new Rect ((Screen.width-500)/2, (Screen.height-500)/2, 500, 500);

		if(WindowMain)
		{
			GUI.Box(new Rect((Screen.width-1024)/2, (Screen.height-512)/7, Screen.width, Screen.height), logo, GUIStyle.none);
			GUILayout.Window(1, windowRect, DoWindowMain, "", GUIStyle.none, GUILayout.MinWidth (200), GUILayout.MinHeight (100));
		}

		if(WindowMechanics)
		{
			GUILayout.Window(2, windowRect, DoWindowMechanics, "Game Mechanics", GUILayout.MinWidth(200), GUILayout.MaxWidth(600));
		}

		if (WindowBackground) 
		{
			GUILayout.Window (3, windowRect, DoWindowBackground, "In the year 2076...", GUILayout.MinWidth(200), GUILayout.MaxWidth(600));
		}

		if (WindowCredits) 
		{
			GUI.Window (4, new Rect((Screen.width-300)/2, 100, 300, 600), DoWindowCredits, "");
		}
	}

	void DoWindowMain(int windowID) {
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
		if(GUILayout.Button ("Background"))
		{
			WindowMain = false;
			WindowBackground = true;
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

	void DoWindowBackground(int WindowID) {
		if(GUILayout.Button("Back"))
		{
			WindowMain = true;
			WindowBackground = false;
		}
	}

	void DoWindowCredits(int WindowID) {
		GUILayout.BeginScrollView(scrollPosition, GUILayout.Width (280), GUILayout.Height (550));
		GUILayout.Label("Credits" +
		                "\n\nArt:" +
		                "\nBen Diefenbach" +
		                "\nLeon \"Noel\" Kennedy" +
		                "Ashley \"Ultimae\" West" +
		                "\n\nMechanics:" +
		                "\nCharlotte \"Charlaxy\" Ellett" +
		                "\nPatrick \"King\" Phillips" +
		                "\nJesse \"Wolfenhex\" Schirmer" +
		                "\n\nMusic & Sounds: Attributed:" +
		                "\nKevin Macleod: Tempting Secrets, Black Vortex, Day of Chaos" +
		                "\nMike Koenig: knife sharpening, stab, groan, suction, pain, swoosh" +
		                "\n\nMusic & Sounds: Original:" +
		                "\nHunter \"hfuller\" Fuller" +
		                "\nWilliam \"Mr. Tuttle\" LeBlanc" +
		          		"\n\nProgramming:" +
		          		"\nDavid \"Nyk O'Demus\" Brooks" +
		          		"\nCharlotte \"Charlaxy\" Ellett" +
		          		"\nJesse \"Wolfenhex\" Schirmer" +
		          		"\n\nStory:" +
		          		"\nChris \"ctag\" Bero" +
		          		"\nCharlotte \"Charlaxy\" Ellett" +
		          		"\nRaymond \"strages\" Nordin, III" +
		          		"\nPatrick \"King\" Phillips" +
		          		"\nDaniel \"Sunshine Dan\" Rhodes" +
		          		"\nJesse \"Wolfenhex\" Schirmer");
		GUILayout.EndScrollView ();
		if (GUILayout.Button ("Back")) 
		{
			WindowMain = true;
			WindowCredits = false;
		}
	}
}