using UnityEngine;
using System.Collections;

namespace SuperHero.Logical
{
	public class Monster : MonoBehaviour {

		public int attackpoint=10;

		protected bool isDying=false;
		// Use this for initialization
		protected virtual void Start () {
		
		}
		
		// Update is called once per frame
		protected virtual void Update () {
			if(isDying)
			{
				transform.Translate(GlobalInGame.currentPC.transform.forward*-3f+GlobalInGame.currentPC.transform.up);
			}
		}

		public virtual void BeAttack()
		{
			isDying=true;
			Destroy(gameObject,3f);
		}



		public enum MonsterState
		{
			Idle=0,
			Active=1,
			Move=2,
			Dead=3,
		}
	}
}