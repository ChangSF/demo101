using UnityEngine;
using System.Collections;
namespace SuperHero.Logical
{
	public class startTrigger : MonoBehaviour {
		public Vector3 direction;
		public Vector3 position;
		public Vector3 defultDirection;
		public Vector3 defultPosition;
		private bool isEntered=false;
		// Use this for initialization
		void Start ()
		{
//			position=transform.position;
		}
		
		// Update is called once per frame
		void Update () 
		{
			
		}

		void OnTriggerEnter(Collider other)
		{
			position=transform.position;
			if(isEntered==false)
			{
				defultPosition=Vector3.zero;
				position=transform.TransformPoint(defultPosition);
				direction=defultDirection+transform.eulerAngles;
				print ("collider:"+other.name);
				PlayerController pc=other.transform.GetComponent<PlayerController>();
				pc.ReStart(position,direction);
				pc.RegisterOP();
				StartCoroutine(EnableAgain());

				isEntered=true;
			}
		}

		IEnumerator EnableAgain()
		{
			yield return new WaitForSeconds(1f);
			isEntered=false;
			yield return true;
		}


	}
}
