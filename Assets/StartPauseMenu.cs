using UnityEngine;
using System.Collections;

//test

public class StartMenu: MonoBehaviour {
	public GUISkin gooey = null;
	public Texture2D logo;
	public Vector2 scrollPosition = Vector2.zero;

	bool WindowMain = true;
	bool WindowMechanics, WindowCredits, WindowBackground, WindowPause = false;

	public bool Paused = false;
	public bool IsPauseMenu
	{
		get;
		set;
	}

	void OnGUI () {
		logo = Resources.Load <Texture2D> ("Game_Logo_Ideas_v2");
		GUI.skin = gooey;
		IsPauseMenu = false;

		Rect windowRect = new Rect((Screen.width-200)/2, (Screen.height-100)/1.4f, 200, 100);

		if(WindowMain)
		{
			GUI.Box(new Rect((Screen.width-1024)/2, (Screen.height-512)/7, Screen.width, Screen.height), logo, GUIStyle.none);
		}
		if(WindowMain || WindowPause)
		{
			GUILayout.Window(1, windowRect, DoWindowMain, "", GUIStyle.none, GUILayout.MinWidth (200), GUILayout.MinHeight (100));
		}

		if(WindowMechanics)
		{
			GUILayout.Window(2, windowRect, DoWindowMechanics, "Game Mechanics", GUILayout.MinWidth(200), GUILayout.MaxWidth(600));
		}

		if (WindowBackground) 
		{
			GUILayout.Window (3, new Rect((Screen.width-700)/2, 200, 700, 400), DoWindowBackground, "");
		}

		if (WindowCredits) 
		{
			GUI.Window (4, new Rect((Screen.width-300)/2, 100, 300, 530), DoWindowCredits, "");
		}
		if (IsPauseMenu && Paused)
		{
			GUILayout.Window (0, new Rect((Screen.width-100)/2, 200, 150, 165), DoWindowMain, "Pause");
		}
	}

	void DoWindowMain(int windowID) {
		if(!IsPauseMenu){
			if (GUILayout.Button("Start"))
			{
				WindowMain = false;
				Application.LoadLevel("Scene");
				Map.Generate ();
				// To do: Load character generation (random or choose)
				// Automatically load a random level after
				//IsPauseMenu = true;
			}
		}
		else
		{
			if(GUILayout.Button ("Resume"))
			{
				Paused = false;
				WindowPause = false;
			}
		}
		if (GUILayout.Button ("How to Play"))
		{
			WindowMain = false;
			WindowMechanics = true;
		}
		if(GUILayout.Button ("Our Story So Far"))
		{
			WindowMain = false;
			WindowBackground = true;
		}
		if (GUILayout.Button ("Credits")) 
		{
			WindowMain = false;
			WindowCredits = true;
		}
		if(GUILayout.Button ("Quit"))
		{
			Application.Quit();
		}
	}
	
	void DoWindowMechanics(int windowID) {
		bool one = true, two, three = false;
		if(one)
		{
			GUILayout.Label ("<b>Welcome to I.C.E.: Beneath the Cloud!</b>" +
							"\n\nI.C.E. is a thrilling corporate espionage game set " +
							"in the dystopian future.  This is a guide to walk you " +
							"through the basic control interface and some of the " +
							"interactions the player can make." +
							"\n\nThe goal of I.C.E. is to lead our hero, the Catalyst, " +
							"through a maze of tunnels, corridors, and passages below " +
							"Heat Sink City and throughout the Happy Corp infrastructure, " +
							"and leave down the maintanance elevators." +
							"\n\nTo move our hero in one of four directions, simply use " +
							"the arrow keys.  Each press of a direction key will move " +
							"Catalyst one space in the direction desired." +
							"\n\nTo interact with the environment of the game, simply " +
							"press the space bar." +
							"\n\nThe escape key pauses the game and brings up the menu " +
							"system.  You can resume or quit the game here.");
			if(GUILayout.Button("Back"))
			{
				one = false;
				WindowMain = true;
				WindowMechanics = false;
			}
			if(GUILayout.Button ("Next"))
			{
				one = false;
				two = true;
			}
		}
		if(two)
		{
			GUILayout.Label ("Because I.C.E. is an espionage game, an element of " +
							"stealth is needed.  The guards of Happy Corp patrol " +
							"the halls, ensuring that no one unauthorized gets past " +
							"them.  You may notice that some guards are positioned " +
							"in such a way that there is no possibility of sneaking " +
							"past them, but that's where your hacker abilities come " +
							"into play!  By utilizing a security bug in the Cloud(TM) " +
							"technology, you can steal the appearance and credentials " +
							"of guards.  Simply sneak up behind the Security(TM) drone " +
							"and press the space bar.  The drone will vaporize and you " +
							"will assume its identity." +
							"\n\nYou may think that things are easy from here, however " +
							"these guards aren't dumb!  They are trained to recognize " +
							"alterations in typical guard behavior and gain suspicion " +
							"when there is anything wrong.  You must take their " +
							"appearance and copy their behavior in near perfect sync, " +
							"or else the Security(TM) drones will pour onto you and " +
			                 "shred you to bits.");
			if(GUILayout.Button("Back"))
			{
				two = false;
				one = true;
			}
			if(GUILayout.Button ("Next"))
			{
				two = false;
				three = true;
			}
		}
		if(three)
		{
			GUILayout.Label ("So, you've been found out as a fake?  Run.  Run and don't " +
							"stop.  The guards will not let up on their pursuit of the " +
							"Catalyst.  As more and more guards notice that something is " +
							"amiss, the number of guards in pursuit will increase.  If " +
							"all of the guards in a region are alerted, the game ends as " +
							"the base locks down." +
							"\n\nThere are special pickups known as Data Pads that " +
							"contain information about Happy Corp, its employees, and the " +
							"recorded data on the Catalyst.  To pick up these data pads, " +
							"simply walk over the pad and press the space bar.  " +
							"To exit the data pad, press the space bar again." +
							"\n\nTo exit a level, enter the elevator and press the " +
			                 "space bar.  Prepare to be taken to the next level.");
			if(GUILayout.Button ("Back"))
			{
				three = false;
				two = true;
			}
			if(GUILayout.Button ("Finish"))
			{
				three = false;
				WindowMain = true;
				WindowMechanics = false;
			}
		if (GUILayout.Button("Back"))
		{
			WindowMain = true;
			WindowMechanics = false;
		}
	}

	void DoWindowBackground(int WindowID) {
		GUILayout.Label("<b>In the year 2076...</b>" +
		                "\n\nCatalyst, a daring activist, was framed for bombing a " +
		                "Cloud(TM) clinic by the malicious oligarchy of Happy Corp. " +
		                "Catalyst was thrown in a high security prison known as " +
		                "\"The Pit,\" a facility located on the ocean floor." +
		                "\n\nThe Pit contains some of the worst villains against humanity, " +
		                "as well as the political prisoners that Happy Corp needs to " +
		                "silence but not outright kill. Down in the Pit, the Catalyst meets" +
		                "Scamall, the original developer of Cloud(TM). Scamall reveals a" +
		                "security flaw: Cloud(TM)'s visual identity could be compromised " +
		                "and the image projection could be manipulated by a conscious " +
		                "hacker." +
		                "\n\nUsing this information, Catalyst stages a breakout and " +
		                "escapes the Pit. After meeting with the most loyal members of " +
		                "Activist Group, the Catalyst pieces together a plan to destroy " +
		                "Happy Corp from the inside out and destroy the oppressive " +
		                "Cloud(TM) technology: destroy the Master Controller. With the " +
		                "main objective in mind, the Catalyst moves to surmount this " +
		                "monumental task.\n");
						// "Scamall" means "Cloud" in Irish, according to Google.
						// I thought this name was too good to pass up.
		if(GUILayout.Button("Back"))
		{
			WindowMain = true;
			WindowBackground = false;
		}
	}

	void DoWindowCredits(int WindowID) {
		GUILayout.Label("<b>I.C.E was created by</b>" +
		                "\n\nChris \"ctag\" Bero" +
		                "\nDavid \"Nyk O'Demus\" Brooks" +
		                "\nBen Diefenbach" +
		                "\nCharlotte \"Charlaxy\" Ellett" +
		                "\nHunter \"hfuller\" Fuller" +
		                "\nLeon \"Noel\" Kennedy" +
		                "\nWilliam \"Mr. Tuttle\" LeBlanc" +
		                "\nRaymond \"strages\" Nordin, III" +
		                "\nPatrick \"King\" Phillips" +
		                "\nDaniel \"Sunshine Dan\" Rhodes" +
		                "\nJesse \"Wolfenhex\" Schirmer" +
		                "\nAshley \"Ultimae\" West" +
		                "\n\nWith Music & Sounds from:" +
		                "\n\nKevin Macleod:" +
		                "\nTempting Secrets, Black Vortex, Day of Chaos" +
		                "\n\nMike Koenig:" +
		                "\nknife sharpening, stab, groan, suction, pain, swoosh" +
		                "\n");
		if (GUILayout.Button ("Back")) 
		{
			WindowMain = true;
			WindowCredits = false;
		}
	}
}