using UnityEngine;
using System.Collections.Generic;

public class Player : Moving {

	private Dictionary<string, Dictionary<Direction, Texture2D[]>> Textures;

	public Player() : base()
	{
		Direction = Direction.Down;

		Textures = new Dictionary<string, Dictionary<Direction, Texture2D[]>>()
		{
			{"Attack", new Dictionary<Direction, Texture2D[]>
			{
				{ Direction.Up, new[] { Resources.Load<Texture2D>("player_attack_1-1"), Resources.Load<Texture2D>("player_attack_1-2") } },
				{ Direction.Right, new[] { Resources.Load<Texture2D>("player_attack_2-1"), Resources.Load<Texture2D>("player_attack_2-2") } },
				{ Direction.Down, new[] { Resources.Load<Texture2D>("player_attack_3-1"), Resources.Load<Texture2D>("player_attack_3-2") } },
			}},
			{"Idle", new Dictionary<Direction, Texture2D[]>
			{
				{ Direction.Up, new[] { Resources.Load<Texture2D>("player_idle_1") } },
				{ Direction.Right, new[] { Resources.Load<Texture2D>("player_idle_2") } },
				{ Direction.Down, new[] { Resources.Load<Texture2D>("player_idle_3") } },
			}},
			{"Walk", new Dictionary<Direction, Texture2D[]>
			{
				{ Direction.Up, new[] { Resources.Load<Texture2D>("player_walk_1-1"), Resources.Load<Texture2D>("player_walk_1-2") } },
				{ Direction.Right, new[] { Resources.Load<Texture2D>("player_walk_2-1"), Resources.Load<Texture2D>("player_walk_2-2") } },
				{ Direction.Down, new[] { Resources.Load<Texture2D>("player_walk_3-1"), Resources.Load<Texture2D>("player_walk_3-2") } },
			}},
		};
    }
    
    public new Moving.Direction Direction
	{
		get;
		private set;
	}

	public int Frames
	{
		get;
		private set;
	}

	void Start () {

		Map.Player = this;

		while(!Move (0,0))
		{
			transform.position = new Vector2 (Random.Range (0, Map.Width), Random.Range (0, Map.Height));
		}
	}
	
	void Update ()
	{
		int x = 0;
		int y = 0;

		if(Input.GetKeyDown(KeyCode.UpArrow)) {
			y += 1;
        }
		if(Input.GetKeyDown(KeyCode.RightArrow)) {
			x += 1;
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)) {
			y -= 1;
        }
		if(Input.GetKeyDown(KeyCode.LeftArrow)) {
			x -= 1;
        }

		if(!(x != 0 && y != 0))
		{
			if(y > 0)
			{
				Direction = Direction.Up;
			}
			
			if(x < 0)
			{
				Direction = Direction.Right;
			}
			
			if(y < 0)
            {
                Direction = Direction.Down;
            }
            
            if(x > 0)
            {
                Direction = Direction.Left;
            }
		}

		Direction direction = Direction;
		bool mirror = false;
        
		if(direction == Direction.Left)
		{
			direction = Direction.Right;
			mirror = true;
		}

		Texture2D texture = null;

		if(!Move (x, y) || (x == 0 && y == 0))
		{
			texture = Textures["Idle"][direction][Frames % Textures["Idle"][direction].Length];
        }
		else
		{
			Frames++;

			texture = Textures["Walk"][direction][Frames % Textures["Walk"][direction].Length];
        }

		Debug.Log (Direction);
		Debug.Log (texture);
		Debug.Log (mirror);

		renderer.material.mainTexture = texture;
		renderer.material.mainTextureScale = new Vector2(mirror ? -1 : 1, 1);
        
		if(Camera.main == null)
		{
			return;
		}

		Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
	}
}
