using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// A node class for doing pathfinding on a 2-dimensional map
/// </summary>
public class AStarNode2D : IComparable
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

	private AStarNode2D FParent;
	/// <summary>
	/// The parent of the node.
	/// </summary>
	public AStarNode2D Parent
	{
		get
		{
			return FParent;
		}
		set
		{
			FParent = value;
		}
	}

	/// <summary>
	/// The accumulative cost of the path until now.
	/// </summary>
	public double Cost 
	{
		set
		{
			FCost = value;
		}
		get
		{
			return FCost;
		}
	}
	private double FCost;
	
	/// <summary>
	/// The estimated cost to the goal from here.
	/// </summary>
	public double GoalEstimate 
	{
		set
		{
			FGoalEstimate = value;
		}
		get 
		{
			Calculate();
			return(FGoalEstimate);
		}
	}
	private double FGoalEstimate;
	
	/// <summary>
	/// The cost plus the estimated cost to the goal from here.
	/// </summary>
	public double TotalCost
	{
		get 
		{
			return(Cost + GoalEstimate);
		}
	}
	
	/// <summary>
	/// The goal node.
	/// </summary>
	public AStarNode2D GoalNode 
	{
		set 
		{
			FGoalNode = value;
			Calculate();
		}
		get
		{
			return FGoalNode;
		}
	}
	private AStarNode2D FGoalNode;

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

	public AStarNode2D(AStarNode2D AParent,AStarNode2D AGoalNode,double ACost,int AX, int AY)
	{
		FParent = AParent;
		FCost = ACost;
		GoalNode = AGoalNode;
		FX = AX;
		FY = AY;
	}

	#endregion

	#region

	/// <summary>
	/// Determines wheather the current node is the goal.
	/// </summary>
	/// <returns>Returns true if current node is the goal</returns>
	int goalcheckcount = 0;
	public bool IsGoal()
	{
		goalcheckcount++;
		if (goalcheckcount > 1000) {
			return IsSameState(FGoalNode);
		}
		return IsSameState(FGoalNode);
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
		if(CurrentCost != 1) 
			return;

		AStarNode2D NewNode = new AStarNode2D(this, GoalNode, Cost + CurrentCost, AX, AY);
		if(Parent != null && NewNode.IsSameState(Parent)) 
		{
			return;
		}
		ASuccessors.Add(NewNode);
	}

	private int GetMap(int x, int y)
	{
		//Debug.Log ("getmap: " + x + " " + y);

		if ((x < 0) || (x >= Map.Width)) {
			return(9999);
		}
		if ((y < 0) || (y >= Map.Height)) {
			return(9999);
		}

		bool wall = (Map.Walls [x, y] != null);

		return(wall ? 9999 : 1);
	}

	#endregion

	#region Public Methods

	/// <summary>
	/// Determines wheather the current node is the same state as the on passed.
	/// </summary>
	/// <param name="ANode">AStarNode to compare the current node to</param>
	/// <returns>Returns true if they are the same state</returns>
	public bool IsSameState(AStarNode2D ANode)
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
	public void Calculate()
	{
		if(GoalNode != null) 
		{
			double xd = FX - ((AStarNode2D)GoalNode).X;
			double yd = FY - ((AStarNode2D)GoalNode).Y;
			// "Euclidean distance" - Used when search can move at any angle.
			//GoalEstimate = Math.Sqrt((xd*xd) + (yd*yd));
			// "Manhattan Distance" - Used when search can only move vertically and 
			// horizontally.
			GoalEstimate = Math.Abs(xd) + Math.Abs(yd); 
			// "Diagonal Distance" - Used when the search can move in 8 directions.
			//GoalEstimate = Math.Max(Math.Abs(xd),Math.Abs(yd));
		}
		else
		{
			GoalEstimate = 0.0f;
		}
	}

	/// <summary>
	/// Gets all successors nodes from the current node and adds them to the successor list
	/// </summary>
	/// <param name="ASuccessors">List in which the successors will be added</param>
	public void GetSuccessors(ArrayList ASuccessors)
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

	#region Overridden Methods

	public override bool Equals(object obj)
	{
		return IsSameState((AStarNode2D)obj);
	}
	
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}
	
	#endregion
	
	#region IComparable Members
	
	public int CompareTo(object obj)
	{
		return(-TotalCost.CompareTo(((AStarNode2D)obj).TotalCost));
	}
	
	#endregion

}