using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SuperHero.Logical
{
	public class BuildingInfo : MonoBehaviour {

		public int length;
		public Vector3 directionEuler=Vector3.zero;
		public List<int> NextBuildings=new List<int>();

	}

}