using UnityEngine;
using System.Collections;

namespace SuperHero.Logical
{
	public class CatapultTrigger : MonoBehaviour {
		public CatapultEndTrigger endTrigger;
		public float gravity=10f;
		public float ySpeed=10f;


		void OnTriggerEnter(Collider  other)
		{
			if(other.tag=="Player")
			{
				//GlobalInGame.currentPC.CurrentCatapultCtrl.Catapulting(transform.position,endTrigger.transform.position,gravity,ySpeed);
				GlobalInGame.currentPC.CurrentCatapultCtrl.Catapulting(other.transform.position,endTrigger.transform.position,gravity,ySpeed);
			}
		}

	}
}
