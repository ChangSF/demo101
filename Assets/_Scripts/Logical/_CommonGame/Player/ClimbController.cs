using UnityEngine;
using System.Collections;
using DG.Tweening;

namespace SuperHero.Logical
{
	/// <summary>
	/// 攀爬控制器
	/// 
	/// 三个阶段:跳跃进入，攀爬，跳跃出
	/// 进去有一个角度转换，禁用高度，不禁用人物控制器，修改人物控制器大小，适应人物高度，出爬墙的时候恢复
	/// </summary>
	public class ClimbController : MonoBehaviour 
	{
		#region feild

		public eClimbMode mClimbMode=eClimbMode.StartClimb;

		private PlayerController pc;
		
		private Tweener mTweener;

		private bool isClimbing=false;

		private Animator mA;
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
			mA=GetComponent<Animator>();
		}
		
		// Update is called once per frame
		void Update () 
		{
			UpdateOffest();
			UpdatePositon();

		}

//		void OnGUI()
//		{
//			if(pc!=null)
//				GUILayout.Label(pc.mTrack.ToString());
//			else
//				GUILayout.Label("");
//			GUILayout.Label(bIsChangeTrack.ToString());
//			GUILayout.Label(localXOffset.ToString());
//
//		}
		#endregion
		#region Method

		public void ClimbStart(PlayerController pcc)
		{
			pc=pcc;


			isClimbing=false;
			mClimbMode=eClimbMode.StartClimb;
			mTweener=transform.DORotate(new Vector3(-90f,0f,0f),0.5f,RotateMode.LocalAxisAdd);
			mTweener.SetEase(Ease.Linear);
			mTweener.OnComplete(Climbing);

		}

		public void Climbing()
		{
			print("Climbing");
			mClimbMode=eClimbMode.Climbing;
			isClimbing=true;
			pc.mIC.TurnLeft+=TurnLeft;
			pc.mIC.TurnRight+=TurnRight;
			this.enabled=true;
		}

		public void EndClimb(Vector3 roadDirection)
		{
			pc.mIC.TurnLeft-=TurnLeft;
			pc.mIC.TurnRight-=TurnRight;
			this.enabled=false;
			isClimbing=false;
			mClimbMode=eClimbMode.EndClimb;
		}

		void TurnLeft()
		{
//			if(pc.mRunMode!=PlayerController.eRunMode.climb)
//				return;

			if(pc.mTrack!=PlayerController.eTrack.midLeft&&!bIsChangeTrack)
			{
				mStartPos=((int)pc.mTrack-3)*pc.xTrackOffset;
				mEndPos=((int)pc.mTrack-4)*pc.xTrackOffset;
				mSurplusChangeTime=xChangTime;
				pc.mTrack--;
				bIsChangeTrack=true;
				if(mA)
					//mA.SetTrigger("turnleft");
					mA.Play("turnleft");
				print("left");
			}
		}
		
		void TurnRight()
		{

			if(pc.mTrack!=PlayerController.eTrack.midRight&&!bIsChangeTrack)
			{
				mStartPos=((int)pc.mTrack-3)*pc.xTrackOffset;
				mEndPos=((int)pc.mTrack-2)*pc.xTrackOffset;
				mSurplusChangeTime=xChangTime;
				pc.mTrack++;
				bIsChangeTrack=true;
				if(mA)
					mA.Play("turnright");
				print("right");
			}
		}

		public void Dead()
		{
			isClimbing=false;
		}

		#endregion
		
		#region UpdatePositionAndRotation
		
		float localXOffset=0f;
		bool bIsChangeTrack=false;
		float mSurplusChangeTime=0f;
		float xChangTime=0.5f;
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
		void UpdatePositon()
		{
			if(isClimbing)
			{

				transform.Translate(new Vector3(localXOffset,GlobalInGame.currentPC.moveSpeed*Time.deltaTime,0f),Space.World);
			}
		}
		
		#endregion


		//三个阶段:跳跃进入，攀爬，跳跃出
		public enum eClimbMode
		{
			StartClimb=0,
			Climbing=1,
			EndClimb=2,
		}
	}
}
