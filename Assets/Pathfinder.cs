using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
	public static Point[] FindPath(int startX, int startY, int goalX, int goalY)
	{
		Path path = new Path(startX, startY);
		
		while(path.Nodes.Count > 0)
		{
			Node node = path.Nodes.Dequeue ();

			List<Point> list = Cache.Load (node.X, node.Y, goalX, goalY);

			if(list != null)
			{
				list = new List<Point>(list.ToArray ());
			}
			else if(node.X == goalX && node.Y == goalY)
			{
				list = new List<Point>();
			}

			if(list != null)
			{
				while(node.ParentX != null)
				{
					list.Add (new Point(node.X, node.Y));
					node = path[node.ParentX.Value, node.ParentY.Value];

					Cache.Save (node.X, node.Y, goalX, goalY, new List<Point>(list.ToArray ()));
				}

				list.Reverse ();
                
				return list.ToArray ();
			}

			node.Visited = true;

			for(int x = -1; x <= 1; x++)
			{
				for(int y = -1; y <= 1; y++)
				{
					if(Mathf.Abs (x) == Mathf.Abs (y))
					{
						continue;
					}

					int xx = node.X + x;
					int yy = node.Y + y;

					if(xx < 0)
					{
						continue;
					}

					if(yy < 0)
					{
						continue;
					}

					if(xx >= Map.Width)
					{
						continue;
					}

					if(yy >= Map.Height)
					{
						continue;
					}

					if(Map.Walls[xx, yy] != null)
					{
						continue;
					}

					if(path[xx, yy] != null && path[xx, yy].Visited)
					{
						continue;
					}

					path.Nodes.Enqueue(path[xx, yy] = new Node(node.X, node.Y, false, xx, yy));
				}
			}
		}			
		
		return null;
    }

	public static class Cache
	{
		private static List<Point>[,,,] _Data;

		public static void Clear()
		{
			_Data = null;
		}

		public static List<Point> Load(int startX, int startY, int goalX, int goalY)
		{
			if(_Data == null)
			{
				return null;
			}

			return _Data[startX, startY, goalX, goalY];
		}

		public static void Save(int startX, int startY, int goalX, int goalY, List<Point> data)
		{
			if(_Data == null)
			{
				_Data = new List<Point>[Map.Width, Map.Height, Map.Width, Map.Height];
			}

			_Data[startX, startY, goalX, goalY] = data;
		}
	}
	
	private class Path
	{
		Dictionary<int, Dictionary<int, Node>> _Nodes = new Dictionary<int, Dictionary<int, Node>>();

		public Path(int startX, int startY)
		{
			Nodes = new Queue<Node>();
			StartX = startX;
			StartY = startY;
			
			Nodes.Enqueue(this[startX, startY] = new Node(null, null, true, startX, startY));
		}

		public Queue<Node> Nodes
		{
			get;
			private set;
		}
		
		public int StartX
		{
			get;
			private set;
		}
		
		public int StartY
		{
			get;
			private set;
		}

		public Node this[int x, int y]
		{
			get
			{
				if(!_Nodes.ContainsKey (x))
				{
					return null;
				}

				if(!_Nodes[x].ContainsKey(y))
				{
					return null;
				}

				return _Nodes[x][y];
            }
			set
			{
				if(!_Nodes.ContainsKey (x))
				{
					_Nodes[x] = new Dictionary<int, Node>();
				}

				_Nodes[x][y] = value;
			}
		}
	}
	
	private class Node
	{
		public Node(int? parentX, int? parentY, bool visited, int x, int y)
		{
			ParentX = parentX;
			ParentY = parentY;
            Visited = visited;
            X = x;
            Y = y;
        }
        
        public int? ParentX
        {
            get;
            private set;
        }
        
        public int? ParentY
        {
            get;
            private set;
        }
        
        public int X
        {
            get;
            private set;
        }
        
        public int Y
        {
            get;
            private set;
        }
        
        public bool Visited
        {
            get;
            set;
        }
    }

	public class Point
	{
		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}

		public int X
		{
			get;
			private set;
		}
		
		public int Y
		{
			get;
			private set;
        }
    }
}