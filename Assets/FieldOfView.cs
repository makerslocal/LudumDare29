using System;
using UnityEngine;
using System.Collections.Generic;

public class FieldOfView : MonoBehaviour {
	// From Author: Jason Morley (Source: http://www.morleydev.co.uk/blog/2010/11/18/generic-bresenhams-line-algorithm-in-visual-basic-net/)
	
	private static void Swap<T>(ref T lhs, ref T rhs) { T temp; temp = lhs; lhs = rhs; rhs = temp; }
			
	/// <summary>
	/// The plot function delegate
	/// </summary>
	/// <param name="x">The x co-ord being plotted</param>
	/// <param name="y">The y co-ord being plotted</param>
	/// <returns>True to continue, false to stop the algorithm</returns>
	public delegate bool PlotFunction(int x, int y);

	public static List<Pathfinder.Point> VisibleSquares;
	
	public static List<Pathfinder.Point> GetVisibleSquares (int x0, int y0, Moving.Direction d, int fov, int range) {
		VisibleSquares = new List<Pathfinder.Point>();

		for (int p = -fov; p <= fov; p++) {
			if (d == Moving.Direction.Up) {
				Line (x0, y0, x0 + p, Map.Height, PlotLine);
			} else if (d == Moving.Direction.Down) {
				Line (x0, y0, x0 + p, 0, PlotLine);
			} else if (d == Moving.Direction.Left) {
				Line (x0, y0, 0, y0 + p, PlotLine);
			} else if (d == Moving.Direction.Right) {
				Line (x0, y0, Map.Width, y0 + p, PlotLine);
			}
		}

		return VisibleSquares;
	}

	//public Pathfinder.Point[] GetVisibleLine (int x0, int y0)

	public static bool PlotLine (int x, int y) {
		Pathfinder.Point point = new Pathfinder.Point (x, y);
		if (x  > 0 && y > 0 && x < Map.Width && y < Map.Height && Map.Walls [x, y] == null) {
			if (!VisibleSquares.Contains(point)) {
				VisibleSquares.Add (new Pathfinder.Point (x, y));
			}
		}
		return true;
	}
			
	/// <summary>
	/// Plot the line from (x0, y0) to (x1, y10
	/// </summary>
	/// <param name="x0">The start x</param>
	/// <param name="y0">The start y</param>
	/// <param name="x1">The end x</param>
	/// <param name="y1">The end y</param>
	/// <param name="plot">The plotting function (if this returns false, the algorithm stops early)</param>
	public static void Line(int x0, int y0, int x1, int y1, PlotFunction plot)
	{
		bool steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);
		if (steep) { Swap<int>(ref x0, ref y0); Swap<int>(ref x1, ref y1); }
		if (x0 > x1) { Swap<int>(ref x0, ref x1); Swap<int>(ref y0, ref y1); }
		int dX = (x1 - x0), dY = Math.Abs(y1 - y0), err = (dX / 2), ystep = (y0 < y1 ? 1 : -1), y = y0;
				
		for (int x = x0; x <= x1; ++x)
		{
			if (!(steep ? plot(y, x) : plot(x, y))) return;
			err = err - dY;
			if (err < 0) { y += ystep;  err += dX; }
		}
	}
}

