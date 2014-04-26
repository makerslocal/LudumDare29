using UnityEngine;
using System.Collections;

public class StartMenu: MonoBehaviour {
	private Rect windowRect = new Rect (100, 100, 200, 100);
	private bool menuStory = false;
	private bool mainMenu = true;

	void OnGUI () {
		GUILayout.BeginArea (new Rect (500, 500, 300, 300));
		if (mainMenu) {
			GUILayout.Box ("Main Menu");
			if (GUILayout.Button ("Story")) {
					menuStory = true;
					mainMenu = false;
			}
		}
		if (menuStory) {
			GUILayout.Box ("Story here");
			if(GUILayout.Button ("Back to Menu")) {
				mainMenu = true;
				menuStory = false;
			}
		}

		if(GUILayout.Button("Mechanics")) {
		}

		if (GUILayout.Button ("Start")) {
				}
	}
}