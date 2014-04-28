using UnityEngine;

public class Enemy : Moving {
	
	private Transform player;
	private GameObject[] vis;
	
	protected uint Frame
	{
		get;
		private set;
	}
	
	public bool IsGhost {
		get;
		protected set;
	}
	
	void Chase()
	{
		if (player == null) {
			player = Map.Player.transform;
			return;
		}

		done = true;

		AStar astar = new AStar();
		
		int goalx = Mathf.RoundToInt (player.position.x);
		int goaly = Mathf.RoundToInt (player.position.y);
		int startx = Mathf.RoundToInt (transform.position.x);
		int starty = Mathf.RoundToInt (transform.position.y);
		AStarNode2D GoalNode = new AStarNode2D(null,null,0,goalx,goaly);
		AStarNode2D StartNode = new AStarNode2D(null,GoalNode,0,startx,starty);
		StartNode.GoalNode = GoalNode;
		astar.FindPath(StartNode,GoalNode);

		if (astar.Solution.Count > 1) {
			// clear the visualization
			for (int o = 0; o < vis.Length; o++) {
				vis[o].renderer.enabled = false;
				//Destroy(vis[o]);
			}
			
			// let's visualize this
			AStarNode2D step;
			for (int s = 0; s < astar.Solution.Count; s++) {
				step = (AStarNode2D)astar.Solution[s];

				Debug.Log ("Step " + s + " X: " + step.X + " Y: " + step.Y);

				vis[s].renderer.enabled = true;
				vis[s].transform.position = new Vector2(step.X, step.Y);
			}

			AStarNode2D firstStep = (AStarNode2D)astar.Solution[1];
			//Move (firstStep.X - startx, firstStep.Y - starty);
			Move (startx, starty);
		}
	}
	
	void Flee()
	{
		if (player == null) {
			player = Map.Player.transform;
			return;
		}
		
		if (player.position.y <= transform.position.y) {
			Move (0, 1);
		}			
		if (player.position.y >= transform.position.y) {
			Move (0, -1);
		}
		if (player.position.x <= transform.position.x) {
			Move (1, 0);
		}
		if (player.position.x >= transform.position.x) {
			Move (-1, 0);
		}
	}
	
	void Start () {
		renderer.material.color = Color.green;
		vis = new GameObject[100];
		for (int x = 0; x < 100; x++) {
			vis[x] = GameObject.CreatePrimitive(PrimitiveType.Quad);
			vis[x].renderer.material.color = Color.red;
			vis[x].transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);
		}
	}

	bool done = false;

	void Update () {
		
		if (++Frame % 200 > 0) {
			return;
		}

		if (!done) {
			Chase ();
		}
		
		//Flee ();
		//Chase ();
	}
}