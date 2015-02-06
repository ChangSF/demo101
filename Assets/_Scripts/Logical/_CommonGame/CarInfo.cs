using UnityEngine;
using System.Collections;

namespace SuperHero.Logical
{
	public class CarInfo : MonoBehaviour {
		public float hurtPoint=5f;
		public eCarMode mCarMode=eCarMode.STATIC;
		public bool isRunning=true;
		public float speed=5f;

		void Update()
		{
			if(mCarMode==eCarMode.DYNAMIC&& isRunning)
			{
				transform.Translate(new Vector3(0f,0f,speed*Time.deltaTime),Space.Self);
			}
		}

		//private PlayerController pc;

//		void OnControllerColliderHit(ControllerColliderHit hit)
//		{
//			print("hit");
//			if(hit.controller.gameObject.tag=="Player")
//			{
//				if(pc==null)
//					pc=hit.controller.GetComponent<PlayerController>();
//				pc.GetHurt(hurtPoint,hit);
//			}
//		}
//
//		public void OnCollisionEnter(Collision collision)
//		{
//			print("hit");
//			if(collision.gameObject.tag=="Player11")
//			{
//				if(pc==null)
//					pc=collision.gameObject.GetComponent<PlayerController>();
//				pc.GetHurt(hurtPoint);
//			}
//		}


		public enum eCarMode
		{
			STATIC=0,
			DYNAMIC=1,
		}

		public override string ToString ()
		{
			return string.Format("hurtPoint:{0};mCarMode:{1};isRunning:{2};speed:{3};",hurtPoint.ToString(),mCarMode.ToString(),isRunning.ToString(),speed.ToString());
		}

	}
}