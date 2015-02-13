using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SuperHero.Entity;
namespace SuperHero.Logical
{
	public class PropManager :MonoBehaviour {

		public GameObject PrefabSpeedUp;

		public Queue<GameObject> QueueSpeedup;

		public GameObject PrefabGroupAttack;

		public Queue <GameObject> QueueGroupAttack;

		public GameObject PrefabGAPlay;
		
		public Queue <GameObject> QueueGroupAttackPlay;

		public GameObject PrefabRecoverHP;

		public Queue<GameObject> QueueRecoverHP;
		/// <summary>
		/// 地雷
		/// </summary>
		public GameObject PrefabMine;

		public Queue<GameObject> QueueMine;






	}
}