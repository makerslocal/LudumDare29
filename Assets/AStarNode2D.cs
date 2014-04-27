using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// A node class for doing pathfinding on a 2-dimensional map
/// </summary>
public class AStarNode2D : AStarNode
{
	#region Properties

	/// <summary>
	/// The X-coordinate of the node
	/// </summary>
	public int X 
	{
		get 
		{
			return FX;
		}
	}
	private int FX;

	/// <summary>
	/// The Y-coordinate of the node
	/// </summary>
	public int Y
	{
		get
		{
			return FY;
		}
	}
	private int FY;

	#endregion

	#region Constructors

	/// <summary>
	/// Constructor for a node in a 2-dimensional map
	/// </summary>
	/// <param name="AParent">Parent of the node</param>
	/// <param name="AGoalNode">Goal node</param>
	/// <param name="ACost">Accumulative cost</param>
	/// <param name="AX">X-coordinate</param>
	/// <param name="AY">Y-coordinate</param>
	public AStarNode2D(AStarNode AParent,AStarNode AGoalNode,double ACost,int AX, int AY) : base(AParent,AGoalNode,ACost)
	{
		FX = AX;
		FY = AY;
	}

	#endregion

	#region Private Methods

	/// <summary>
	/// Adds a successor to a list if it is not impassible or the parent node
	/// </summary>
	/// <param name="ASuccessors">List of successors</param>
	/// <param name="AX">X-coordinate</param>
	/// <param name="AY">Y-coordinate</param>
	private void AddSuccessor(ArrayList ASuccessors, int AX, int AY) 
	{
		int CurrentCost = GetMap(AX, AY);
		if(CurrentCost == -1) 
		{
			return;
		}
		AStarNode2D NewNode = new AStarNode2D(this, GoalNode, Cost + CurrentCost, AX, AY);
		if(NewNode.IsSameState(Parent)) 
		{
			return;
		}
		ASuccessors.Add(NewNode);
	}

	private int GetMap(int x, int y)
	{
		if((x < 0) || (x > Map.Width))
			return(-1);
		if((y < 0) || (y > Map.Height))
			return(-1);
		return((Map.Walls[y,x] == null) ? 0 : 1);
	}

	#endregion

	#region Overidden Methods

	/// <summary>
	/// Determines wheather the current node is the same state as the on passed.
	/// </summary>
	/// <param name="ANode">AStarNode to compare the current node to</param>
	/// <returns>Returns true if they are the same state</returns>
	public override bool IsSameState(AStarNode ANode)
	{
		if(ANode == null) 
		{
			return false;
		}
		return ((((AStarNode2D)ANode).X == FX) &&
			(((AStarNode2D)ANode).Y == FY));
	}
	
	/// <summary>
	/// Calculates the estimated cost for the remaining trip to the goal.
	/// </summary>
	public override void Calculate()
	{
		if(GoalNode != null) 
		{
			double xd = FX - ((AStarNode2D)GoalNode).X;
			double yd = FY - ((AStarNode2D)GoalNode).Y;
			// "Euclidean distance" - Used when search can move at any angle.
			//GoalEstimate = Math.Sqrt((xd*xd) + (yd*yd));
			// "Manhattan Distance" - Used when search can only move vertically and 
			// horizontally.
			//GoalEstimate = Math.Abs(xd) + Math.Abs(yd); 
			// "Diagonal Distance" - Used when the search can move in 8 directions.
			GoalEstimate = Math.Max(Math.Abs(xd),Math.Abs(yd));
		}
		else
		{
			GoalEstimate = 0;
		}
	}

	/// <summary>
	/// Gets all successors nodes from the current node and adds them to the successor list
	/// </summary>
	/// <param name="ASuccessors">List in which the successors will be added</param>
	public override void GetSuccessors(ArrayList ASuccessors)
	{
		ASuccessors.Clear();
		AddSuccessor(ASuccessors,FX-1,FY  );
		AddSuccessor(ASuccessors,FX-1,FY-1);
		AddSuccessor(ASuccessors,FX  ,FY-1);
		AddSuccessor(ASuccessors,FX+1,FY-1);
		AddSuccessor(ASuccessors,FX+1,FY  );
		AddSuccessor(ASuccessors,FX+1,FY+1);
		AddSuccessor(ASuccessors,FX  ,FY+1);
		AddSuccessor(ASuccessors,FX-1,FY+1);
	}

	#endregion
}