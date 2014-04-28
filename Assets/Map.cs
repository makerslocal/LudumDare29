using UnityEditor;
using UnityEngine;

public static class Map
{
	static Map()
	{
		Clear ();
    }
    
    public static void Clear()
	{
		Player = null;

		Walls = new GameObject[0,0];

		Create.Clear ();
	}

	public static void Generate()
	{
		Debug.Log ("Generating Level...");

		Clear();

		int height = Random.Range (8,16);
		int width = Random.Range (8,16);
		
		height <<= 1;
		width <<= 1;
		
		height++;
		width++;

		Walls = null;
        
        Walls = new GameObject[width, height];

		Create.Reset ();

		int count = Height * Width * 10;
        
		Create.Border ();

		for(int i = 0; i < count; i++)
		{
			Create.Room();
		}
		
		for(int i = 0; i < count; i++)
		{
			Create.Hall();
		}

		for(int i = 0; i < count; i++)
		{
			Create.Pillar();
		}

		Create.Item();
		Create.Item();

		Create.Player();

		Create.Enemy();
		Create.Enemy();
		Create.Enemy();

		if(Camera.main == null)
		{
			return;
		}
		
		Camera.main.backgroundColor = Color.black;
	}
	
    public static int Height {
		get {
			return Walls.GetLength (1);
		}
	}

	public static Player Player {
		get;
		set;
	}
	
	public static GameObject[,] Walls {
		get;
		private set;
	}

	public static int Width {
		get {
			return Walls.GetLength (0);
		}
	}

	#region Create

	private static class Create
	{
		static Create()
		{
			Clear ();
		}

		public static void Border(bool floor, int height, int width, int x, int y)
		{
			for (int xx = x; xx < width + x; xx++)
			{
				for(int yy = y; yy < height + y; yy++)
				{
					if(xx > x && yy > y && xx <  x + width - 1 && yy < y + height - 1)
					{
						continue;
					}

					if(floor)
					{
						Floor (xx, yy);
					}
					else
					{
						Wall (xx, yy);
					}
				}
			}
		}

		public static void Border()
		{
			Border(false, Height, Width, 0, 0);
			Border(true, Height - 2, Width - 2, 1, 1);
		}
        
        public static void Clear()
		{
			Floors = new bool[0,0];
		}
		
		public static bool Door(int x, int y)
		{
			return Floor (x, y);
		}

		public static bool Door(int height, int width, int x, int y)
		{
			int xx;
			int yy;

			int Loops = 0;

			while(true)
			{
				if(++Loops > 1000)
				{
					break;
				}

				xx = Random.Range (x, x + width);

				if(xx < 1 || xx >= Width - 1)
				{
					continue;
                }

				yy = Random.Range (y, y + height);
                
				if(yy < 1 || yy >= Height - 1)
				{
					continue;
                }

				if(xx > x && xx < x + width && yy > y && yy < y + height)
				{
					continue;
                }

				if(xx == x && yy == y)
				{
                    continue;
                }

				if(xx == x + width - 1 && yy == y)
				{
					continue;
                }

				if(xx == x && yy == y + height - 1)
				{
					continue;
                }
                
                if(xx == x + width - 1 && yy == y + height - 1)
				{
					continue;
                }
                
                if(!Door (xx, yy))
                {
                    continue;
				}

				return true;
            }

			return false;
            
		}

		public static GameObject Enemy()
		{
			while(true)
			{
				int x = Random.Range (1, Width - 1);
				int y = Random.Range (1, Height - 1);
				
				if(!IsEmpty (x, y))
				{
					continue;
				}
				
				GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
				
				quad.AddComponent<Enemy>();
				
				quad.transform.position = new Vector2(x, y);
				
				return quad;
			}
		}

		public static bool[,] Floors {
			get;
			private set;
		}

		public static bool Floor(int x, int y)
		{
			if(x < 0)
			{
				return false;
			}

			if(y < 0)
			{
				return false;
			}

			if(x >= Width)
			{
				return false;
			}

			if(y >= Height)
			{
				return false;
			}

			if(Walls[x, y] != null)
			{
				return false;
			}

			Floors[x, y] = true;

			return true;
		}

		public static bool Hall()
		{
			int loops = 0;

			int x;
			int y;

			while(true)
			{
				if(++loops > 100)
				{
					return false;
				}

				x = Random.Range (1, (Width >> 1) - 1);
				y = Random.Range (1, (Height >> 1) - 1);

				x <<= 1;
				y <<= 1;

				if(!IsEmpty (1, x, y))
				{
					continue;
				}

				break;
			}

			int length = 0;

			loops = 0;

			while(true)
			{
				if(++loops > 25)
				{
					break;
				}

				int xx = x;
				int yy = y;

				switch(Random.Range (1, 4))
				{
					case 1:
						xx -= 2;
						break;

					case 2:
						xx += 2;
						break;

					case 3:
						yy -= 2;
						break;

					case 4:
						yy -= 2;
						break;

					default:
						continue;
				}

				if(!IsEmpty (1, xx, yy))
				{
					continue;
				}

				for(int xxx = Mathf.Min (x, xx); xxx <= Mathf.Max (x, xx); xxx++)
				{
					for(int yyy = Mathf.Min (y, yy); yyy <= Mathf.Max (y, yy); yyy++)
					{
						Wall (xxx,yyy);
					}
				}

				length++;
			}

			return length > 0;
        }

		private static bool IsEmpty(int border, int x, int y)
		{
			if(border == 0)
			{
				return Walls[x, y] == null;
			}

			for(int xx = -border; xx <= border; xx++)
			{
				for(int yy = -border; yy <= border; yy++)
				{
					int xxx = x + xx;

					if(xxx < 0)
					{
						return false;
					}
					
					if(xxx >= Width)
					{
						return false;
					}

					int yyy = y + yy;

					if(yyy < 0)
					{
						return false;
					}

					if(yyy >= Height)
					{
						return false;
					}
					
					if(Walls[xxx, yyy] != null)
					{
						return false;
					}
				}
			}

			return true;
		}

		private static bool IsEmpty(int x, int y)
		{
			return IsEmpty (0, x, y);
		}

		public static GameObject Item()
		{
			while(true)
			{
				int x = Random.Range (1, (Width >> 1) - 1);
				int y = Random.Range (1, (Height >> 1) - 1);

				x <<= 1;
				y <<= 1;

				if(!IsEmpty (x,y))
				{
					continue;
				}

				GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);

				quad.AddComponent<Item>();

				quad.transform.position = new Vector2(x, y);

				return quad;
			}
		}

		public static bool Pillar()
		{
			int x = Random.Range (1, (Width >> 1) - 1);
			int y = Random.Range (1, (Height >> 1) - 1);

			x <<= 1;
			y <<= 1;

			if(!IsEmpty (1, x, y))
			{
				return false;
			}

			if(!Wall (x, y))
			{
				return false;
			}

            for(int xx = -1; xx <= 1; xx++)
			{
				for(int yy = -1; yy <= 1; yy++)
				{
					Floor (x + xx, y + yy);
                }
            }

			return true;
		}

		public static GameObject Player()
		{
			if(Map.Player != null)
			{
				return Map.Player.gameObject;
			}

			while(true)
			{
				int x = Random.Range (1, Width - 1);
				int y = Random.Range (1, Height - 1);
				
				if(!IsEmpty (x, y))
				{
					continue;
				}
				
				GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);

				Map.Player = quad.AddComponent<Player>();
				
				quad.transform.position = new Vector2(x, y);

				return quad;
			}
		}

		public static void Reset()
		{
			Floors = null;
			Floors = new bool[Width, Height];
		}

		public static bool Room()
		{
			int height = Random.Range(2, Height >> 2);
			int width = Random.Range(2, Width >> 2);

			height <<= 1;
			width <<= 1;
			
			height++;
			width++;

			int x = Random.Range (0, Width - width);
			int y = Random.Range (0, Height - height);

			x >>= 1;
			x <<= 1;

			y >>= 1;
			y <<= 1;

			for(int xx = x; xx < x + width; xx++)
			{
				for(int yy = y; yy < y + height; yy++)
				{
					if(Floors[xx,yy])
					{
						return false;
					}
				}
			}

			if(!Door (height, width, x, y))
			{
				return false;
			}

			for(int xx = x + 1; xx < x + width - 1; xx++)
			{
				for(int yy = y + 1; yy < y + height - 1; yy++)
				{
					Floor (xx, yy);
                }
            }
            
            Border (false, height, width, x, y);

			return true;
		}

		public static GameObject Wall(int x, int y)
		{
			if(x < 0)
			{
				return null;
			}

			if(y < 0)
			{
				return null;
			}

			if(x >= Width)
			{
				return null;
			}

			if(y >= Height)
			{
				return null;
			}

			if(Floors[x, y])
			{
				return null;
			}

			if(Walls[x, y] != null)
			{
				return Walls[x, y];
			}

			GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
			quad.transform.position = new Vector2(x, y);
			
			Walls[x, y] = quad;

			return quad;
		}
	}

	#endregion
}