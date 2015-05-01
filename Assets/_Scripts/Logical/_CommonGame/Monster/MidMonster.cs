using UnityEngine;
using System.Collections;

namespace SuperHero.Logical
{
	public class MidMonster : Monster {

		// Use this for initialization
		protected override void Start () {
		
		}
		
		// Update is called once per frame
		protected override void Update () {
			base.Update();
		}

		public override void BeAttack()
		{
			isDying=true;
			Destroy(gameObject,3f);
		}
	}
}
