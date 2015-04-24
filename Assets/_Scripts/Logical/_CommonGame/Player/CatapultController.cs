using UnityEngine;
using System.Collections;

namespace SuperHero.Logical
{
	public class CatapultController : MonoBehaviour 
	{
		public Vector3 startPos;
		public Vector3 targetPos;
		public float gravity;
		public float ySpeed;

		private float Xgap;
		private float Ygap;
		private float Zgap;

		private float changeTime;
		private float totalTime;

		bool isCatapulting=false;
		// Use this for initialization
		void Start () 
		{
			
		}
		
		// Update is called once per frame
		void Update () 
		{
			if(isCatapulting)
			{
				totalTime+=Time.deltaTime;
				if(totalTime<changeTime)
				{
					float percentage=totalTime/changeTime;
					transform.position=startPos+new Vector3(Xgap*percentage,ySpeed*totalTime-0.5f*gravity*totalTime*totalTime,Zgap*percentage);
				}
				else
				{
					isCatapulting=false;
				}
			}
		}

		public void CatapultReady()
		{
			PlayerController pc=GlobalInGame.currentPC;
			pc.CancelOP();
			if(pc.mJumpState==PlayerController.eJumpState.NoneJump)
			{
				pc.mFallDown= PlayerController.eFallDown.doubleGravity;
			}
		}

		public void Catapulting(Vector3 start,Vector3 target,float gravity,float ySpeed)
		{
			this.startPos=start;
			this.targetPos=target;
			this.gravity=gravity;
			this.ySpeed=ySpeed;
			Xgap=target.x-start.x;
			Ygap=target.y-start.y;
			Zgap=target.z-start.z;
			changeTime=ySpeed*2f/gravity;
			totalTime=0f;
			isCatapulting=true;
		}

		public void CatapultEnd()
		{
			isCatapulting=false;

		}


	}
}
