using UnityEngine;
using System.Collections;

namespace SuperHero.Logical
{
	public class CatapultReadyTrigger : MonoBehaviour {

		void OnTriggerEnter(Collider  other)
		{
			if(other.tag=="Player")
			{
				GlobalInGame.currentPC.CatapultReady();
			}
		}
	}
}
