using UnityEngine;
using System.Collections;
using System.Text;
using SuperHero.Entity;
namespace SuperHero.Logical
{
	/// <summary>
	/// 主要控制的是人物的位置信息
	/// </summary>
	public class PlayerController : MonoBehaviour 
	{
		#region 变量的定义
		/// <summary>
		/// 轨道之间的距离，到时候要和模型相匹配
		/// </summary>
		public float xTrackOffset=5f;
		/// <summary>
		/// 更换轨道的时间
		/// </summary>
		public float xChangTime=.5f;
		/// <summary>
		/// 重力大小，下落时为双倍重力
		/// </summary>
		public float gravity=9.8f;
		/// <summary>
		/// 前进的速度
		/// </summary>
		public float moveSpeed=10f;
		/// <summary>
		/// 前进方向的方向向量.注：需要单位向量化
		/// </summary>
		public Vector3 mDirection=Vector3.forward;
		/// <summary>
		/// 相对于路标点的位移
		/// </summary>
		public Vector3 mRoadOffset=Vector3.zero;

		public eRunMode mRunMode=eRunMode.straight;

		private CurrentGameInfo currentGameInfo=new CurrentGameInfo ();

		public CurrentGameInfo CurrentGameInfo {
			get 
			{
				return currentGameInfo;
			}
			set 
			{
				currentGameInfo = value;
			}
		}

		public Vector3 fallCenter;
		public float fallHeight;
		/// <summary>
		/// 当前角色身上的角色控制器
		/// </summary>
		private CharacterController mCC;
		/// <summary>
		/// 角色动画控制器
		/// </summary>
		private Animator mA;
		/// <summary>
		/// 当前场景的输入控制器
		/// </summary>
		private InputControl mIC;
		/// <summary>
		/// 标记:是否处在切换轨道的过程中
		/// </summary>
		private bool bIsChangeTrack=false;
		/// <summary>
		/// 本地相坐标的X偏移量，注：进度不包含Y轴
		/// </summary>
		private float localXOffset=0f;
		/// <summary>
		/// 跳跃的状态：木有跳，一级跳，二级跳
		/// </summary>
		private eJumpState mJumpState=eJumpState.NoneJump;
		/// <summary>
		/// 下落时是否加速下降
		/// </summary>
		private eFallDown mFallDown=eFallDown.normal;
		/// <summary>
		/// 当前运行在哪个轨道
		/// </summary>
		private eTrack mTrack=eTrack.middle;
		/// <summary>
		/// 轨道的数量3or5
		/// </summary>
		private eTrackNum mTrackNum=eTrackNum.Three;
		/// <summary>
		/// Y轴方向的速度
		/// </summary>
		private float mYSpeed=0f;
		/// <summary>
		/// 是否处在停留在空中的状态
		/// </summary>
		private bool mIsHover=false;

		Vector3 [] mCC_Center=new Vector3[2];
		float [] mCC_Height=new float[2];

		#endregion
		#region Interface
		// Use this for initialization
		void Start () {
			currentGameInfo.HP_Max=100f;
			currentGameInfo.MP_Max=100f;
			currentGameInfo.HP=100f;
			currentGameInfo.MP=100f;

			mCC=GetComponent<CharacterController>();
			mA=GetComponent<Animator>();
			mIC=GameObject.Find("InputController").GetComponent<InputControl>();
			if(mCC!=null&&mIC!=null)//注册委托
			{
				mIC.TurnLeft+=TurnLeft;
				mIC.TurnRight+=TurnRight;
				mIC.JumpOP+=Jump;
				mIC.FallDownOP+=FallDown;
				mIC.Attack+=Attack;

			}
			mYSpeed=gravity;
			mCC_Center[0]=mCC.center;
			mCC_Height[0]=mCC.height;
			mCC_Height[1]=fallHeight;
			mCC_Center[1]=fallCenter;
		}
		
		// Update is called once per frame
		void Update () {
			if(!isPause)
			{
				UpdateRotate();
				UpdateOffest();
				UpdateHeight();

				UpdatePositon();
			}

		}

		void OnGUI()
		{
			//GUILayout.Label(mTrack.ToString());
//			GUILayout.Label( mSurplusChangeTime.ToString());
//			GUILayout.Label(bIsChangeTrack.ToString());
//			GUILayout.Label(localXOffset.ToString());
//			GUILayout.Label(isPause.ToString());
//			GUILayout.Label(mJumpState.ToString());
		}

		void OnControllerColliderHit(ControllerColliderHit hit)
		{

			if(hit.collider.transform.root.gameObject.layer!=9&&mRunMode==eRunMode.straight)
			{
				if(bIsChangeTrack==true)
				{
					print("接触到碰撞器:"+LayerMask.LayerToName( hit.collider.gameObject.layer));
					mSurplusChangeTime=xChangTime-mSurplusChangeTime;
					if(mEndPos-mStartPos>0f)//Right
					{
						mTrack--;
					}
					else//Left
					{
						mTrack++;
					}
					float temp=mEndPos;
					mEndPos=mStartPos;
					mStartPos=temp;
					bIsChangeTrack=true;

					currentGameInfo.HP-=2f;
				}
				else
				{
					currentGameInfo.HP-=5f;
				}
				Debug.Log("Destoryed "+hit.collider.name);
				Destroy( hit.collider.gameObject);

				if(currentGameInfo.HP<=0f)
				{
					Debug.Log("Dead!!!!!");
					currentGameInfo.HP=0f;
				}


			}
			
		}
		#endregion
		#region OperationReflect
		private float mStartPos=0f;
		private float mEndPos=0f;
		private float mSurplusChangeTime=0f;
		void TurnLeft()
		{
			if(mRunMode!=eRunMode.straight)
				return;
			if(mTrackNum==eTrackNum.Five)
			{
				if(mTrack!=eTrack.left&&!bIsChangeTrack)
				{
					mStartPos=((int)mTrack-3)*xTrackOffset;
					mEndPos=((int)mTrack-4)*xTrackOffset;
					mSurplusChangeTime=xChangTime;
					mTrack--;
					bIsChangeTrack=true;

					if(mA)
						//mA.SetTrigger("turnleft");
						mA.Play("turnleft");
				}
			}
			else if(mTrackNum==eTrackNum.Three)
			{
				if(mTrack!=eTrack.midLeft&&!bIsChangeTrack)
				{
					mStartPos=((int)mTrack-3)*xTrackOffset;
					mEndPos=((int)mTrack-4)*xTrackOffset;
					mSurplusChangeTime=xChangTime;
					mTrack--;
					bIsChangeTrack=true;
					if(mA)
						//mA.SetTrigger("turnleft");
						mA.Play("turnleft");
				}
			}
		}

		void TurnRight()
		{
			if(mTrackNum==eTrackNum.Five)
			{
				if(mTrack!=eTrack.right&&!bIsChangeTrack)
				{
					mStartPos=((int)mTrack-3)*xTrackOffset;
					mEndPos=((int)mTrack-2)*xTrackOffset;
					mSurplusChangeTime=xChangTime;
					mTrack++;
					bIsChangeTrack=true;
					if(mA)
						mA.SetTrigger("turnright");
				}
			}
			else if(mTrackNum==eTrackNum.Three)
			{
				if(mTrack!=eTrack.midRight&&!bIsChangeTrack)
				{
					mStartPos=((int)mTrack-3)*xTrackOffset;
					mEndPos=((int)mTrack-2)*xTrackOffset;
					mSurplusChangeTime=xChangTime;
					mTrack++;
					bIsChangeTrack=true;
					if(mA)
						mA.SetTrigger("turnright");
				}
			}
		}


		void Jump()
		{
			if( mJumpState==eJumpState.NoneJump)
			{
				mYSpeed=-10f;
				mJumpState=eJumpState.FirstJump;
				mA.SetTrigger("jump");
				mA.SetBool("land",false);
			}
			else if(mJumpState==eJumpState.FirstJump)
			{
				mYSpeed=-10f;
				mJumpState=eJumpState.DoubleJump;
				mA.SetTrigger("jump");
				mA.SetBool("land",false);
			}
		}

		 void Attack()
		{
			if(mA)
				mA.SetTrigger("attack");
		}
		/// <summary>
		/// 下降
		/// </summary>
		void FallDown()
		{
			if(mA)
			{
				if(mA.GetBool("land")==false)
				{
					mFallDown=eFallDown.doubleGravity;
				}
				else
				{
					mA.CrossFade("fall",0.2f);
					StartCoroutine(mCCFallDown());
				}
			}
		}

		IEnumerator mCCFallDown()
		{
			mCC.height=mCC_Height[1];
			mCC.center= mCC_Center[1];
			yield return new WaitForSeconds(0.9f);
			mCC.height=mCC_Height[0];
			mCC.center= mCC_Center[0];
			yield return null;
		}

		#endregion
		#region Method
		float hoverTime=1f;
		/// <summary>
		/// 停留空中一定的时间
		/// </summary>
		/// <param name="time">停留的时间</param>
		void Hover(float time)
		{
			hoverTime=time;
			StartCoroutine(iHover());
		}
		/// <summary>
		/// 无限期滞留
		/// </summary>
		void Hover()
		{
			mIsHover=true;
		}
		/// <summary>
		/// 取消滞留空中，开始降落
		/// </summary>
		void Land()
		{
			mIsHover=false;
		}
		/// <summary>
		/// 内部方法，延时的协同实现
		/// </summary>
		IEnumerator iHover()
		{
			mIsHover=true;
			yield return new WaitForSeconds(hoverTime);
			mIsHover=false;
			yield return null;
		}




		public void ReStart(Vector3 startPosition,Vector3 startDirection)
		{
			mRunMode=eRunMode.straight;
			transform.eulerAngles=startDirection;
			mDirection=startDirection;
			float startXPosition=0f;
			switch(mTrack)
			{
			case eTrack.left:
				startXPosition=-2f*xTrackOffset;
				break;
			case eTrack.midLeft:
				startXPosition=-xTrackOffset;
				break;
			case eTrack.middle:
				startXPosition=0f;
				break;
			case eTrack.midRight:
				startXPosition=xTrackOffset;
				break;
			case eTrack.right:
				startXPosition=2f*xTrackOffset;
				break;
			default:break;
			}
			Vector3 currentP=transform.right*startXPosition+startPosition;
			transform.position=currentP;
			mSurplusChangeTime=0f;
		}
		bool isPause=false;

		public void Pause()
		{
			isPause=true;
			if(mIC)
			{
				mIC.TurnLeft-=TurnLeft;
				mIC.TurnRight-=TurnRight;
				mIC.JumpOP-=Jump;
				mIC.FallDownOP-=FallDown;
				mIC.Attack-=Attack;
			}
		}

		public void Resume()
		{
			isPause=false;
			RegisterOP();
		}

		public void Stop()
		{
			isPause=true;
			CancelOP();

		}

		public void RoundRight(Vector3 center)
		{
			roundCenter=center;
			radius=Vector3.Distance(center,transform.position);
			mRunMode=eRunMode.roundRight;
		}
		public void RoundLeft(Vector3 center)
		{
			roundCenter=center;
			radius=Vector3.Distance(center,transform.position);
			mRunMode=eRunMode.roundLeft;
		}

		public void RegisterOP()
		{
			if(mCC!=null&&mIC!=null)//注册委托
			{
				Debug.Log("RegisterOP");
				mIC.TurnLeft+=TurnLeft;
				mIC.TurnRight+=TurnRight;
				mIC.JumpOP+=Jump;
				mIC.FallDownOP+=FallDown;
				mIC.Attack+=Attack;
			}
		}
		public void CancelOP()
		{
			if(mIC)
			{
				Debug.Log("CancelOP");
				mIC.TurnLeft-=TurnLeft;
				mIC.TurnRight-=TurnRight;
				mIC.JumpOP-=Jump;
				mIC.FallDownOP-=FallDown;
				mIC.Attack-=Attack;
			}
		}


		public float speedUpDeltaTime=0.3f;
		/// <summary>
		/// 加速的剩余时间
		/// </summary>
		float speedUpTimeLeft=0f;
		/// <summary>
		/// 加速跑
		/// </summary>
		/// <param name="speedUp">增加的速度</param>
		/// <param name="speedTime">加速持续的时间,加速时间有最短的限制，必须>2*速度改变时间</param>
		public void SpeedUp(float speedUp,float speedTime)
		{
			//在加速过程中吃了加速的道具，刷新加速的时间
			if(speedUpTimeLeft>0f)
				speedUpTimeLeft=speedTime;
			//启动加速的协程
			StartCoroutine(SpeedUpYield());
		}

		IEnumerator SpeedUpYield()
		{
			while(speedUpTimeLeft>0f)
			{
				speedUpTimeLeft-=Time.deltaTime;
				yield return null;
			}
		}
		#endregion
		#region UpdatePositionAndRotation

		/// <summary>
		/// 应用偏移量:Tps:换轨过程中碰撞不可碰撞，不然会偏移错误，可以根据初始位置和方向进行矫正，后期修改
		/// </summary>
		void UpdateOffest()
		{
			if(bIsChangeTrack)
			{
				if(mRunMode==eRunMode.straight)
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
			}
			else
			{
				localXOffset=0f;
			}

		}
		float localYOffset=0f;
		bool isCanLand=true;
		/// <summary>
		/// 更新高度
		/// </summary>
		void UpdateHeight()
		{
			if(!mIsHover)
			{
				if(mYSpeed<gravity)
				{
					//加速下落的实现a*2,normal*1
					if(mFallDown==eFallDown.normal)
						mYSpeed+=gravity*Time.deltaTime;
					else if(mFallDown==eFallDown.doubleGravity)
						mYSpeed+=gravity*Time.deltaTime*5f;
						//mYSpeed+=gravity*Time.deltaTime*2f;
					if(mYSpeed<0f)
						isCanLand=false;
					else
						isCanLand=true;
				}
				else if(mYSpeed>gravity)
				{
					mYSpeed=gravity;
				}
				if(mCC)
				{
					localYOffset=-mYSpeed*Time.deltaTime;
					if(mJumpState==eJumpState.FirstJump||mJumpState==eJumpState.DoubleJump)
					{
						if(mCC.isGrounded&&isCanLand)
						{
							mA.SetBool("land",true);
							mJumpState=eJumpState.NoneJump;
						}
					}
					if(mFallDown==eFallDown.doubleGravity)//落地后清除加速下降状态
					{

						if(mCC.isGrounded)
						{
							mFallDown=eFallDown.normal;
							mJumpState=eJumpState.NoneJump;
							mA.SetBool("land",true);
						}
					}

				}
			}
			else//滞留空中
			{
				localYOffset=0f;
			}


		}
		/// <summary>
		/// 做圆周运动的时候的圆心坐标
		/// </summary>
		private Vector3 roundCenter=Vector3.zero;
		/// <summary>
		/// 做圆周运动的时候的半径
		/// </summary>
		private float radius=1f;
		/// <summary>
		/// 应用方向，direction的Y轴信息
		/// </summary>
		void UpdateRotate()
		{
			switch(mRunMode)
			{
			case eRunMode.straight:
				transform.eulerAngles=mDirection;
				break;
			case eRunMode.roundRight:
				transform.rotation=Quaternion.LookRotation(roundCenter-transform.position);
				transform.Rotate(new Vector3 (0f,-90f,0f),Space.World);
				transform.eulerAngles=new Vector3(0f,transform.eulerAngles.y,0f);
				Debug.DrawLine(roundCenter,transform.position,Color.red);
				break;
			case eRunMode.roundLeft:
				transform.rotation=Quaternion.LookRotation(roundCenter-transform.position);
				transform.Rotate(new Vector3 (0f,90f,0f),Space.World);
				transform.eulerAngles=new Vector3(0f,transform.eulerAngles.y,0f);
				Debug.DrawLine(roundCenter,transform.position,Color.red);
				break;
			default:break;
			}
		}

		void UpdatePositon()
		{
			switch(mRunMode)
			{
			case eRunMode.straight:
				Vector3 moveDirection=new Vector3(localXOffset,localYOffset,moveSpeed*Time.deltaTime);
				moveDirection= transform.TransformDirection(moveDirection);
				mCC.Move(moveDirection);
				break;
			case eRunMode.roundRight:
				float s=moveSpeed*Time.deltaTime;
				float d=s/radius;
				float x=radius-radius*Mathf.Cos(d);
				float h=radius*Mathf.Sin(d);
				mCC.Move(transform.TransformDirection(new Vector3(x,localYOffset,h)));
				break;
			case eRunMode.roundLeft:
				float s1=moveSpeed*Time.deltaTime;
				float d1=s1/radius;
				float x1=radius*Mathf.Cos(d1)-radius;
				float h1=radius*Mathf.Sin(d1);
				mCC.Move(transform.TransformDirection(new Vector3(x1,localYOffset,h1)));
				break;
			default :break;
			}
		}

		#endregion


		#region Enum
		private enum eFallDown
		{
			normal=0,
			doubleGravity=1,
		}

		private enum eJumpState
		{
			NoneJump=0,
			FirstJump=1,
			DoubleJump=2,
		};

		private enum eTrack
		{
			left=1,
			midLeft=2,
			middle=3,
			midRight=4,
			right=5,
		};

		private enum eTrackNum
		{
			Three=3,
			Five=5,
		}

		public enum eRunMode
		{
			straight=1,
			roundRight=2,
			roundLeft=3,
		}
		#endregion
	}

}
