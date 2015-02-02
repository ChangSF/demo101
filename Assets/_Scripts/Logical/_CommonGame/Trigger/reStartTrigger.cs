using UnityEngine;
using System.Collections;
namespace SuperHero.Logical
{
	public class reStartTrigger : MonoBehaviour {
		public Vector3 direction;
		public Vector3 position;
		private bool isEntered=false;
		void OnTriggerEnter(Collider other)
		{
			if(isEntered==false)
			{
				print ("reStart-> collider:"+other.name);
				PlayerController pc=other.transform.GetComponent<PlayerController>();
				pc.ReStart(position,direction);
				//pc.RegisterOP();
				StartCoroutine(EnableAgain());
				
				isEntered=true;
			}
		}
		
		IEnumerator EnableAgain()
		{
			yield return new WaitForSeconds(2);
			isEntered=false;
			yield return true;
		}

		
	}
}
