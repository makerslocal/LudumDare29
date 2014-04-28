﻿using UnityEngine;

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
		
		int goalX = Mathf.RoundToInt (player.position.x);
		int goalY = Mathf.RoundToInt (player.position.y);
		int startX = Mathf.RoundToInt (transform.position.x);
		int startY = Mathf.RoundToInt (transform.position.y);

		Pathfinder.Point[] points = Pathfinder.FindPath (startX, startY, goalX, goalY);

		if(points == null)
		{
			return;
		}

		if(points.Length < 1)
		{
			return;
		}

		Pathfinder.Point point = points[0];

		if(point == null)
		{
			return;
		}

		Move(point.X - startX, point.Y - startY);
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
	}

	void Update () {
		
		if (++Frame % 16 > 0) {
			return;
		}

		Chase ();
	}
}