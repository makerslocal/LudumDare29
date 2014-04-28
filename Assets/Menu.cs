using UnityEngine;
using System.Collections;
using System.Threading;

public class Menu : MonoBehaviour
{
	void OnGUI()
	{
		if (GUI.Button(new Rect(10, 10, 150, 50), "Clear"))
		{
			Application.LoadLevel(0);
		}

		if (GUI.Button(new Rect(10, 70, 150, 50), "Generate"))
		{
			Map.Generate();
		}
		
		if (GUI.Button(new Rect(10, 130, 150, 50), "Clear / Generate"))
		{
			Application.LoadLevel("Empty");
			Map.Generate();
		}
	}
}
