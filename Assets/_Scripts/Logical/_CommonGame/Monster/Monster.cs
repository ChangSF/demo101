using UnityEngine;
using System.Collections;

namespace SuperHero.Logical
{
	public class Monster : MonoBehaviour {

		public int attackpoint=10;


		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		public void BeAttack()
		{
			Destroy(gameObject);
		}
	}
}