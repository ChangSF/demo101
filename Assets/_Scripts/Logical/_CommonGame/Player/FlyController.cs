using UnityEngine;
using System.Collections;
using DG.Tweening;



namespace SuperHero.Logical
{
	public class FlyController : MonoBehaviour {
		public float flySpeed=10f;
		public float gravity=5f;
		public Vector3 direction;

		public eFlyMode mFlyMode=eFlyMode.EndFly;
		
		private PlayerController pc;
		
		private Tweener mTweener;

		
		private Animator mA;

		private bool isFlying=false;
		// Use this for initialization
		void Start () 
		{
		
		}
		
		// Update is called once per frame
		void Update () 
		{
			if(isFlying)
			{
				UpdateOffest();
				UpdatePositon();
				if(pc!=null)
				{
					if(pc.mCC.isGrounded)
					{
						EndFly();
					}
				}
			}
		}

	

		public void StartFly(PlayerController pcc,float ySpeed,float speed=10f,float gravity=5f)
		{
			Init();
			pc=pcc;

			this.speed=speed;
			isFlying=true;
			this.ySpeed=ySpeed;
			print("Flying");
			mFlyMode=eFlyMode.Flying;
			pc.mIC.TurnLeft+=TurnLeft;
			pc.mIC.TurnRight+=TurnRight;
			this.enabled=true;


		}
		public void StartFly(PlayerController pcc, float ySpeed,float gravity=5f)
		{

			StartFly(pcc, ySpeed, 10f, gravity=5f);
		}

		public void ContinueFly()
		{
			ContinueFly(10f);
		}
		public void ContinueFly(float ySpeed)
		{
			this.ySpeed=ySpeed;

		}

		public void EndFly()
		{
			Init();

			pc.mIC.TurnLeft-=TurnLeft;
			pc.mIC.TurnRight-=TurnRight;
			this.enabled=false;
			isFlying=false;
			mFlyMode=eFlyMode.EndFly;
		}

		void Init()
		{
			ySpeed=0f;
			localXOffset=0f;
			bIsChangeTrack=false;
			mSurplusChangeTime=0f;
			xChangTime=0.5f;
			mEndPos=0f;
			mStartPos=0f;
		}

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

		public float ySpeed=0f;
		public float speed;

		void UpdatePositon()
		{
			if(isFlying)
			{
				//重力应用
				ySpeed-=gravity*Time.deltaTime;
				Vector3 vv=new Vector3();
				//水平偏移量的应用
				vv.x=localXOffset;
				//z速度应用
				vv.z=speed*Time.deltaTime;
				//y速度应用
				vv.y=ySpeed*Time.deltaTime;

				//transform.Translate(vv,Space.World);
				pc.mCC.Move(vv);
			}
		}
		
		void TurnLeft()
		{
			if(pc.mTrack!=PlayerController.eTrack.midLeft&&!bIsChangeTrack)
			{
				mStartPos=((int)pc.mTrack-3)*pc.xTrackOffset;
				mEndPos=((int)pc.mTrack-4)*pc.xTrackOffset;
				mSurplusChangeTime=xChangTime;
				pc.mTrack--;
				bIsChangeTrack=true;

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

				print("right");
			}
		}


		public enum eFlyMode
		{
			StartFly=0,
			Flying=1,
			EndFly=2,
		}

	}
}