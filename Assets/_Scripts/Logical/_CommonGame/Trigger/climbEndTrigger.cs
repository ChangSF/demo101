using UnityEngine;
using System.Collections;
using DG.Tweening;

namespace SuperHero.Logical
{
	public class climbEndTrigger : MonoBehaviour {
		public Vector3 roadDirection;

		void OnTriggerEnter(Collider  other)
		{
			if(other.gameObject.tag=="Player")
			{
				Tweener twewner=other.transform.DOLocalRotate(roadDirection,.5f,RotateMode.Fast);
				twewner.OnComplete(End);
				GlobalInGame.currentPC.Jump(10f);


			}
		}

		void End()
		{
			GlobalInGame.currentPC.ClimbEnd(Vector3.zero);
		}
		void Down()
		{

		}
	}
}
