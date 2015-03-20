using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SuperHero.Logical
{
	public class BuildingInfo : MonoBehaviour {
		public eBuildType buildType=eBuildType.STRAIGHT;
		public Vector3 InCenter;
		public Vector3 OutCenter;
		public Vector3 directionEuler=Vector3.zero;
		public List<int> NextBuildings=new List<int>();

		public enum eBuildType
		{
			STRAIGHT=0,
			LEFT=1,
			RIGHT=2,
		}
	}

}