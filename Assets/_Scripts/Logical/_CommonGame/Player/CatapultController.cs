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
		bool isLand=false;
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
					transform.position=startPos+new Vector3(Xgap*percentage,Ygap*percentage+ySpeed*totalTime-0.5f*gravity*totalTime*totalTime,Zgap*percentage);
				}
				else
				{
					isCatapulting=false;
				}
			}
			else if(isLand==true)
			{
				PlayerController pc=GlobalInGame.currentPC;
				pc.RegisterOP();
				GlobalInGame.currentPC.mRunMode= PlayerController.eRunMode.straight;
				isLand=false;
			}
		}

		public void CatapultReady()
		{
			PlayerController pc=GlobalInGame.currentPC;
			pc.CancelOP();

			if(pc.mJumpState!=PlayerController.eJumpState.NoneJump)
			{
				pc.mFallDown= PlayerController.eFallDown.doubleGravity;
			}
		}

		public void Catapulting(Vector3 start,Vector3 target,float gravity,float ySpeed)
		{
			PlayerController pc= GlobalInGame.currentPC;
			float startXPosition=0f;
			switch(pc.mTrack)
			{
			case PlayerController.eTrack.left:
				startXPosition=-2f*pc.xTrackOffset;
				break;
			case PlayerController.eTrack.midLeft:
				startXPosition=-pc.xTrackOffset;
				break;
			case PlayerController.eTrack.middle:
				startXPosition=0f;
				break;
			case PlayerController.eTrack.midRight:
				startXPosition=pc.xTrackOffset;
				break;
			case PlayerController.eTrack.right:
				startXPosition=2f*pc.xTrackOffset;
				break;
			default:break;
			}
			this.startPos=start;
			this.targetPos=new Vector3( target.x+startXPosition,target.y,target.z);
			this.gravity=gravity;
			this.ySpeed=ySpeed;
			Xgap=targetPos.x-start.x;
			Ygap=targetPos.y-start.y;
			Zgap=targetPos.z-start.z;
			changeTime=ySpeed*2f/gravity;
			totalTime=0f;
			isCatapulting=true;
			isLand=false;
			GlobalInGame.currentPC.mRunMode= PlayerController.eRunMode.changeRoad;
		}

		public void CatapultEnd()
		{
//			isCatapulting=false;
			isLand=true;

			
		}


	}
}
