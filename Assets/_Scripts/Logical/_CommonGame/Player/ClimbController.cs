using UnityEngine;
using System.Collections;

namespace SuperHero.Logical
{
	/// <summary>
	/// 攀爬控制器
	/// </summary>
	public class ClimbController : MonoBehaviour 
	{
		#region feild



		private PlayerController pc;
		
		
		
		
		#endregion
		#region Interface 
		void Start ()
		{
			OnEnable();
		}
		/// <summary>
		/// Use this for initialization
		/// </summary>
		void OnEnable()
		{
			
		}
		
		// Update is called once per frame
		void Update () 
		{
			UpdateOffest();
			UpdateHeight();
			UpdateRotate();
			UpdatePositon();

		}
		#endregion
		#region Method

		public void Climb(PlayerController pcc)
		{
			pc=pcc;
			pc.mIC.TurnLeft+=TurnLeft;
			pc.mIC.TurnRight+=TurnRight;
		}

		public void EndClimb()
		{
			pc.mIC.TurnLeft-=TurnLeft;
			pc.mIC.TurnRight-=TurnRight;
			this.enabled=false;
		}

		void TurnLeft()
		{
			if(pc.mRunMode!=PlayerController.eRunMode.straight)
				return;
			if(pc.mTrackNum==PlayerController.eTrackNum.Three)
			{
				if(pc.mTrack!=PlayerController.eTrack.midLeft&&!bIsChangeTrack)
				{
					mStartPos=((int)pc.mTrack-3)*pc.xTrackOffset;
					mEndPos=((int)pc.mTrack-4)*pc.xTrackOffset;
					mSurplusChangeTime=xChangTime;
					pc.mTrack--;
					bIsChangeTrack=true;
//					if(pc.mA)
//						//mA.SetTrigger("turnleft");
//						pc.mA.Play("turnleft");
				}
			}
		}
		
		void TurnRight()
		{
			
			if(pc.mTrackNum==PlayerController.eTrackNum.Three)
			{
				if(pc.mTrack!=PlayerController.eTrack.midRight&&!bIsChangeTrack)
				{
					mStartPos=((int)pc.mTrack-3)*pc.xTrackOffset;
					mEndPos=((int)pc.mTrack-2)*pc.xTrackOffset;
					mSurplusChangeTime=xChangTime;
					pc.mTrack++;
					bIsChangeTrack=true;
//					if(pc.mA)
//						pc.mA.SetTrigger("turnright");
				}
			}
		}

		#endregion
		
		#region UpdatePositionAndRotation
		
		float localXOffset=0f;
		bool bIsChangeTrack=false;
		float mSurplusChangeTime=0f;
		float xChangTime=0f;
		float mEndPos=0f;
		float mStartPos=0f;
		/// <summary>
		/// 应用偏移量:Tps:换轨过程中碰撞不可碰撞，不然会偏移错误，可以根据初始位置和方向进行矫正，后期修改
		/// </summary>
		void UpdateOffest()
		{
			if(bIsChangeTrack)
			{
				mSurplusChangeTime-=Time.deltaTime;
				if(mSurplusChangeTime<0f)
				{
					localXOffset=((mSurplusChangeTime+Time.deltaTime)/xChangTime)*(mEndPos-mStartPos);
					bIsChangeTrack=false;
					mSurplusChangeTime=0f;
				}
				else if(mSurplusChangeTime==0f)
				{
					localXOffset=0f;
					bIsChangeTrack=false;
					mSurplusChangeTime=0f;
				}
				else
				{
					localXOffset=(Time.deltaTime/xChangTime)*(mEndPos-mStartPos);
					
				}
			}
			else
			{
				localXOffset=0f;
			}
		}
		float localYOffset=0f;
		bool isCanLand=true;
		/// <summary>
		/// 更新高度    墙上面是否跑？
		/// </summary>
		void UpdateHeight()
		{

			
		}

		void UpdateRotate()
		{

		}
		
		void UpdatePositon()
		{

		}
		
		#endregion
		
	}
}
