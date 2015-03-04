using UnityEngine;
using System.Collections;

namespace SuperHero.Logical
{
	public class SpeedUp : MonoBehaviour {
		public float addedSpeed=10f;
		public float continueTime=3f;

		void OnTriggerEnter(Collider other)
		{
			if(other.GetComponent<Collider>().gameObject.tag=="Player")
			{
				GlobalInGame.currentPM.SpeedUp(addedSpeed,continueTime);
				this.gameObject.SetActive(false);
			}
		}


	}
}
