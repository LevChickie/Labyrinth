using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class WallCoordinates
	{
		private int positionA;
		private int positionB;
		private bool active;
		String walltype;
		public WallCoordinates (int positionA, int positionB, String walltype, bool active)
		{
			this.active = active;
			this.positionA = positionA;
			this.positionB = positionB;
			this.walltype = walltype;
		}

	}
}

