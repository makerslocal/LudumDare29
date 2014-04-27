using UnityEngine;

public static class Map
{
	static Map()
	{
		Clear();

		Generate.Border ();
		//Generate.Room ();
		//Generate.Room ();
	}

	public static void Clear()
	{
		int height = Random.Range (4,8);
		int width = Random.Range (4,8);
		
		height <<= 1;
		width <<= 1;
		
		height++;
		width++;
		
		Walls = new GameObject[width, height];

		Generate.Clear ();
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

	private static class Generate
	{
		static Generate()
		{
			Clear ();
		}

		public static void Border(int height, int width, int x, int y)
		{
			for (int xx = x; xx < width + x; xx++)
			{
				for(int yy = y; yy < height + y; yy++)
				{
					if(xx > x && yy > y && xx <  x + width - 1 && yy < y + height - 1)
					{
						continue;
					}

					Wall (xx, yy);					
				}
			}
		}

		public static void Border()
		{
			Border(Height, Width, 0, 0);
		}

		public static void Clear()
		{
			Floors = new bool[Width, Height];
		}

		public static void Door()
		{
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

			if(x >= Height)
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

		public static void Room()
		{
			int height = Random.Range(1, Height >> 1);
			int width = Random.Range(1, Width >> 1);

			height <<= 1;
			width <<= 1;
			
			height++;
			width++;

			int x = Random.Range (0, Width - width);
			int y = Random.Range (0, Height - height);

			Border (height, width, x, y);
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
}
