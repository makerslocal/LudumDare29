using UnityEngine;

public class Enemy : Moving {
	
	private Transform player;
	
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
		AStar astar = new AStar();
		
		int goalx = Mathf.RoundToInt (Map.Player.transform.position.x);
		int goaly = Mathf.RoundToInt (Map.Player.transform.position.y);
		int startx = Mathf.RoundToInt (transform.position.x);
		int starty = Mathf.RoundToInt (transform.position.y);
		AStarNode2D GoalNode = new AStarNode2D(null,null,0,goalx,goaly);
		AStarNode2D StartNode = new AStarNode2D(null,GoalNode,0,startx,starty);
		StartNode.GoalNode = GoalNode;
		astar.FindPath(StartNode,GoalNode);
		
		if (astar.Solution.Count > 1) {
			AStarNode2D firstStep = (AStarNode2D)astar.Solution[1];
			Move (firstStep.X - startx, firstStep.Y - starty);
		}
	}
	
	void Flee()
	{
		if (player == null) {
			player = Map.Player.transform;
		}
		
		if (player == null) {
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
	}
	
	void Update () {
		
		if (++Frame % 20 > 0) {
			return;
		}
		
		Flee ();
		//Chase ();
	}
}