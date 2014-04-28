using UnityEngine;
using System.Collections;

public class StoryWindows : MonoBehaviour {
	public GUISkin gooey = null;

	static public bool isEnabled
	{
		get;
		set;
	}

	void OnGUI()
	{
		if(isEnabled)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				GUILayout.Window(0, new Rect((Screen.width-300)/2, 100, 200, 200), DoWindowStory, "You downloaded a document.  Preview:",
				                 GUILayout.MinWidth (200), GUILayout.MaxWidth (800), GUILayout.MinHeight(200), GUILayout.MaxHeight (800));
			}
		}
	}

	void DoWindowStory(int WindowID)
	{
		int Piece = Random.Range(0, 6);

		switch(x)
		{
		case 0:
			GUILayout.Label("\nREMINDER TO ASSOCIATES:" +
							"\n\nPlease be sure to appropriate the proper amount of time to " +
							"reading and comprehending internal memos, but be sure not to " +
							"spend too much, or too little." +
							"\n\nThanks," +
			                "\n\nHR");
			if(GUILayout.Button ("Back"))
			{
				isEnabled = false;
			}

			break;

		case 1:
			GUILayout.Label("\nDear Associate," +
							"\nWelcome to Happy Corp, the leading innovator in cybernetic " +
							"and nano technologies. If you are reading this memo you have " +
							"just been employed within Happy Corp and are awaiting your " +
							"placement within our two facilities: the \"Mass Transfer\" " +
							"station or  \"The Deep.\" This memo will go over our basic " +
							"information security procedures and addresses many of the " +
							"frequently asked questions you as an associate may have." +
							"\nPart 1: Who can I trust?" +
							"\nAs a rule of thumb within Happy Corp, you cannot trust " +
							"anyone! Not even your family or closest friends with our " +
							"corporate information. Even if there is a co-worker that has " +
							"demonstrated complete loyalty to the Happy Corp brand, that " +
							"man might be a corporate spy working for the Chinese " +
							"insurgency or the Argentinian sleeper cells. Only trust " +
							"those with proper authentication codes and identification. " +
							"See Appendix A-3 provided for a list of proper " +
							"identification." +
							"\nPart 2: How do I access higher security zones?" +
							"\nFirst of all associate, why are you requesting access to " +
							"these high security zones?" +
							"\nPart 3: The Cloud(TM) and you." +
							"\nThe Cloud(TM) is your key to progress within Happy Corp. " +
							"The Cloud is you, the Cloud defines you. Within the Cloud is " +
							"a system of authentications and identifications that we, the " +
			                "administration, will use to authenticate you.");
			if(GUILayout.Button ("Back"))
			{
				isEnabled = false;
			}
			break;

		case 2:
			GUILayout.Label ("\nPractical Applications of Nanotechnology" +
							"\nby: Dr. Jeremy Scamall" +
							"\nAbstract: This paper demonstrates the practical, everyday " +
							"usage of nanotechnology in the common person as well as " +
							"demonstrating the capabilities of the technology to revolutionize " +
							"the world through applications in manufacturing, security, and " +
							"information technologies. In this paper, several cases are explored " +
							"and several documented phenomena by noted Professor Lebneiz are " +
							"considered. Ethical cases as well as many trade studies are examined " +
							"as well. It was found that nanotechnology is highly applicable in " +
							"social engineering, however the abusive nature of such an act could " +
			                 "permanently alter the societal ego.");

							//(note to artist, Catalyst should note that Jeremy is the person who taught them how to steal appearances with the CloudTM)
			if(GUILayout.Button ("Back"))
			{
				isEnabled = false;
			}
			break;

		case 3:
			GUILayout.Label ("\nDear Associate," +
							"\nWelcome to Happy Corp, the leading innovator in cybernetic and " +
							"nanotechnologies. If you are reading this memo you have just been " +
							"employed within Happy Corp and are awaiting your placement within our " +
							"two facilities: the \"Mass Transfer\" station or  \"The Deep.\" This " +
							"memo will go over our basic safety procedures and addresses many of " +
							"the frequently asked questions you as an associate may have." +
							"\nPart 1: Basic Workplace Safety" +
							"\nWhile at work, proper identification must be visible and must " +
							"match the Cloud(TM) provided to the employees." +
							"\nWhile at work it is advised to be dressed as Cloud(TM) is not a " +
							"good thermal insulator." +
							"\nWhile working within \"Secret\" zones, do not attempt to look at " +
							"the material being handled as learning secrets is known to be " +
							"hazardous to one’s health." +
							"\nDo not kick the chickens." +
							"\nPart 2: Manufacturing Safety" +
							"\nBe sure to wear close toed shoes with steel toes." +
							"\nBe sure to have close cut hair." +
							"\nBe sure to not wear long sleeved clothing." +
							"\nAlways wear pants." +
							"\nALWAYS WEAR PANTS" +
							"\nNever handle equipment you have not been certified on" +
							"\nRemember associate, a safe workplace is a happy workplace. " +
			                 "And remember UNITY THROUGH AGREEMENT.");
			if(GUILayout.Button ("Back"))
			{
				isEnabled = false;
			}
			break;

		case 4:
			GUILayout.Label ("\nCatalyst Tried and Sentenced to Life in the Pit!" +
							"\nThe prosecution presented damning evidence today as " +
							"they showed security footage of Catalyst placing a bomb " +
							"in the Clinic. Catalyst, whose alibi was that there was a " +
							"protest that same day, was not accepted by the judge as a " +
							"valid point. The judge, who deemed the Catalyst’s actions " +
							"to be too heinous, decided to lock the terrorist into the " +
							"darkest and deepest jail available at Happy Corp’s disposal: " +
							"The Pit. The judge was quoted as saying \"It brings me great " +
							"sadness to see you here today, Catalyst. I thought you were a " +
							"person of honor and integrity. Yet you sit with those low life " +
							"scum, Cell. I have nothing but regret for ever mentioning you " +
							"to my fellow man. I even told my wife that you were a good " +
							"person. I’m now ashamed of myself, and disappointed in you. " +
							"Life sentence, to the Pit.\" The Chief of Security gave a " +
							"small press conference afterwards and confirmed to the public " +
			                 "that no one has escaped the Pit.");
			if(GUILayout.Button ("Back"))
			{
				isEnabled = false;
			}
			break;

		case 5:
			GUILayout.Label ("\n");

			if(GUILayout.Button ("Back"))
			{
				isEnabled = false;
			}
			break;

		case 6:
			GUILayout.Label ("\n");
			if(GUILayout.Button ("Back"))
			{
				isEnabled = false;
			}
			break;
		}
	}
}
