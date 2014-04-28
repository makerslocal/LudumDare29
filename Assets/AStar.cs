using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Class for performing A* pathfinding
/// </summary>
public sealed class AStar
{
	#region Private Fields

	private AStarNode2D FStartNode;
	private ArrayList FOpenList;
	private ArrayList FClosedList;
	private ArrayList FSuccessors;

	#endregion

	#region Properties

	/// <summary>
	/// Holds the solution after pathfinding is done. <see>FindPath()</see>
	/// </summary>
	public ArrayList Solution
	{
		get 
		{
			return FSolution;
		}
	}
	private ArrayList FSolution;

	#endregion
	
	#region Constructors

	public AStar()
	{
		FOpenList = new ArrayList();
		FClosedList = new ArrayList();
		FSuccessors = new ArrayList();
		FSolution = new ArrayList();
	}

	#endregion

	private AStarNode2D GetCheapest(ArrayList FOpenList)
	{
		// Get the node with the lowest TotalCost
		//AStarNode NodeCurrent = (AStarNode)FOpenList.Pop();
		AStarNode2D cheapest = (AStarNode2D)FOpenList[0]; // assuming at least one in there
		for (int x = 0; x < FOpenList.Count; x++) {
			if (cheapest == null || ((AStarNode2D)FOpenList[x]).TotalCost < cheapest.TotalCost) {
				cheapest = (AStarNode2D)FOpenList[x];
			}
		}
		return cheapest;
	}

	private bool HasXY(ArrayList List, AStarNode2D Node) {
		for (int x = 0; x < List.Count; x++) {
			if (((AStarNode2D)List[x]).X == Node.X && ((AStarNode2D)List[x]).Y == Node.Y)
				return true;
		}
		return false;
	}
	
	#region Public Methods
	
	/// <summary>
	/// Finds the shortest path from the start node to the goal node
	/// </summary>
	/// <param name="AStartNode">Start node</param>
	/// <param name="AGoalNode">Goal node</param>
	public void FindPath(AStarNode2D AStartNode,AStarNode2D AGoalNode)
	{
		FStartNode = AStartNode;
		int count = 0;

		FOpenList.Add(FStartNode);
		while(FOpenList.Count > 0) 
		{
			count++;
			if (count > 3000) {
				break;
			}
			AStarNode2D NodeCurrent = GetCheapest(FOpenList);
			
			// If the node is the goal copy the path to the solution array
			if(NodeCurrent.IsGoal()) {
				Debug.Log("found goal!");
				while(NodeCurrent != null) {
					FSolution.Insert(0, NodeCurrent);
					NodeCurrent = NodeCurrent.Parent;
				}
				break;
			}

			NodeCurrent.GetSuccessors(FSuccessors);
			foreach(AStarNode2D NodeSuccessor in FSuccessors)
			{
				// Algorithm from policyalmanac.org post-------------

				// If it is not walkable or if it is on the closed list, ignore it.
				if (HasXY(FClosedList, NodeSuccessor))
					continue;

				// If it isn’t on the open list, add it to the open list.
				// Record the F, G, and H costs of the square. 
				if (!HasXY(FOpenList, NodeSuccessor)) {
					FOpenList.Add(NodeSuccessor);
					continue;
				}

				// Make the current square the parent of this square.
				// done during get successors
				//NodeSuccessor.Parent = NodeCurrent;

				// Record the F, G, and H costs of the square.
				// done during get successors


				// If it is on the open list already, check to see if this path to that square is better,
				// using G cost as the measure. A lower G cost means that this is a better path. If so, 
				// change the parent of the square to the current square, and recalculate the G and F scores of the square.
				if (HasXY(FOpenList, NodeCurrent)) {
					if (NodeCurrent.Cost < NodeSuccessor.Cost) {
						NodeSuccessor.Parent = NodeCurrent.Parent;
						NodeSuccessor.Calculate();
					}
				}

				// Original algorithm --------------------------------

				// Test if the current successor node is on the open list, if it is and
				// the TotalCost is higher, we will throw away the current successor.

//				AStarNode2D NodeOpen = null;
//				if(FOpenList.Contains(NodeSuccessor)) {
//					NodeOpen = (AStarNode2D)FOpenList[FOpenList.IndexOf(NodeSuccessor)];
//				}
//				if((NodeOpen != null) && (NodeSuccessor.TotalCost > NodeOpen.TotalCost))
//					continue;
				
				// Test if the current successor node is on the closed list, if it is and
				// the TotalCost is higher, we will throw away the current successor.

//				AStarNode2D NodeClosed = null;
//				if(FClosedList.Contains(NodeSuccessor)) {
//					NodeClosed = (AStarNode2D)FClosedList[FClosedList.IndexOf(NodeSuccessor)];
//				}
//				if((NodeClosed != null) && (NodeSuccessor.TotalCost > NodeClosed.TotalCost)) 
//		 			continue;
				
				// Remove the old successor from the open list
				//FOpenList.Remove(NodeOpen);
				//FOpenList.Remove(NodeSuccessor);
				
				// Remove the old successor from the closed list
				//FClosedList.Remove(NodeClosed);
				//FClosedList.Remove(NodeSuccessor);
				
				// Add the current successor to the open list
				FOpenList.Add(NodeSuccessor);
			}
			// Add the current node to the closed list
			FClosedList.Add(NodeCurrent);
		}
	}
	
	#endregion
}