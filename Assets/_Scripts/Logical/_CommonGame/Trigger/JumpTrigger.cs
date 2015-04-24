using UnityEngine;
using System.Collections;
using DG.Tweening;
namespace SuperHero.Logical
{
	public class JumpTrigger : MonoBehaviour 
	{
		
		public float ySpeed=20f;
		public bool cancelOP=true;
		
		void OnTriggerEnter(Collider  other)
		{
			if(other.gameObject.tag=="Player")
			{
				if(cancelOP)
					GlobalInGame.currentPC.ClimbStart(ySpeed);
				else
					GlobalInGame.currentPC.Jump(ySpeed);
			}
		}
	}
}
