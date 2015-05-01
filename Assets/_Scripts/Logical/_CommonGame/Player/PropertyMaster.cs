using UnityEngine;
using System.Collections;
using SuperHero.Entity;

namespace SuperHero.Logical
{
	/// <summary>
	/// 道具效果实现类 先附加PlayerController脚本
	/// </summary>
	[RequireComponent(typeof(PlayerController))]
	public class PropertyMaster : MonoBehaviour
	{
		public float originalMoveSpeed;
		public float targetSpeedUp=0f;
		public float speedUpDeltaTime=0.3f;
		/// <summary>
		/// 加速的剩余时间
		/// </summary>
		public float speedUpTimeLeft=0f;
		
		private eSpeedMode mSpeedMode=eSpeedMode.normal;
		private PlayerController pc;
		
		public GameObject GoldSE;

		private PropInfo currentProp;

		private bool isMagnet=false;
		void Start () 
		{
			GlobalInGame.currentPM=this;
			pc=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
			if(pc==null)
			{
				pc=GameObject.FindGameObjectWithTag("Player").AddComponent<PlayerController>();
			}
			originalMoveSpeed=pc.moveSpeed;
			
		}
		
		void Update()
		{

		}
		
		void OnControllerColliderHit(ControllerColliderHit hit)
		{

			switch(hit.collider.transform.gameObject.layer)
			{
			case 9://Road路面
				//Debug.Log("road");
				break;
			case 10://Obstacle障碍物
				//Debug.Log(hit.collider.GetComponent<CarInfo>().hurtPoint.ToString());
				Obstacle cc=hit.collider.GetComponent<Obstacle>();
				if(cc!=null)
					pc.GetHurt(cc.hitPoint,hit,false);
				break;
			case 11://Monster怪物
				
				break;
			case 12://Prop道具
				PropInfo currentProp=hit.transform.GetComponent<PropInfo>();
				SwitchProp(currentProp);
				break;
			default:
				//Debug.Log(hit.transform.gameObject.layer.ToString());
				break;
			}
			
		}
		
		
		
		
		
		void SwitchProp(PropInfo prop)
		{
			switch(prop.PropType)
			{
				
			}
		}
		
		public void GetProp(PropInfo prop)
		{
			currentProp=prop;
			switch(prop.PropType)
			{
			case ePropType.GroupAttack:
				
				break;
			case ePropType.GroupAttract:
				
				break;
			case ePropType.SingleAchieve:
				
				break;
			case ePropType.SingleAttack:
				
				break;
			case ePropType.SingleRecover:
				GlobalInGame.currentPC.CurrentGameInfo.HP+=prop.Blood;
				
				break;
			case ePropType.SingleSpeedUp:
				SpeedUp(prop.FlySpeed,prop.FlyTime);
				break;
			case ePropType.GoldIcon:
				GlobalInGame.currentPC.CurrentGameInfo.goldCions++;
//				Debug.Log(GlobalInGame.currentPC.CurrentGameInfo.goldCions.ToString());
				GoldIN();
				break;

			case ePropType.Magnet:

				break;
			default:
				break;
			}
		}
		
		IEnumerator MagnetIN(float time)
		{
			while(time>0f)
			{
				for(int i=0;i<5;i++)
				{
					RaycastHit hit;
					//Debug.DrawLine(transform.position+new Vector3((i-2)*GlobalInGame.currentPC.xTrackOffset,1f,0f),transform.position+new Vector3((i-2)*GlobalInGame.currentPC.xTrackOffset,1f,0f)+transform.forward*20f,Color.red);
					
					if(Physics.Raycast(transform.position+new Vector3((i-2)*GlobalInGame.currentPC.xTrackOffset,1f,0f),transform.forward,out hit,20f,1<<10))
					{
						Obstacle ob=hit.transform.GetComponent<Obstacle>();
						if(ob!=null)
							ob.GetStartReflection();
					}
				}
				yield return null;
			}
		}

		public void GoldIN()
		{
			GameObject go=(GameObject)Instantiate(GoldSE);
			go.transform.parent=transform;
			go.transform.localPosition=new Vector3(0f,0.73f,0f);
			ParticleSystem ps=go.GetComponent<ParticleSystem>();
		}
		
		
		#region 群体攻击效果
		
		public void GroupAttack(PropInfo ga)
		{
			
		}
		
		
		public void GroupAttackPlay(PropInfo ga)
		{
			
		}
		
		
		
		#endregion
		
		#region 单体攻击效果
		
		
		
		
		
		#endregion
		
		#region 回血效果
		public void AddBlood(int addBlood)
		{
			pc.CurrentGameInfo.HP+=addBlood;
			if(pc.CurrentGameInfo.HP>pc.CurrentGameInfo.HP_Max)
				pc.CurrentGameInfo.HP=pc.CurrentGameInfo.HP_Max;
		}
		
		
		#endregion
		
		#region 加速效果
		
		
		
		/// <summary>
		/// 加速跑
		/// </summary>
		/// <param name="speedUp">增加的速度</param>
		/// <param name="speedTime">加速持续的时间,加速时间有最短的限制，必须>2*速度改变时间</param>
		public void SpeedUp(float speedUp,float speedTime)
		{

			//在加速过程中吃了加速的道具，刷新加速的时间
			if(speedUpTimeLeft>2f*speedUpDeltaTime)
			{
				Debug.Log("dsfsd");
				//0.3秒内再吃一个加速不现实吧，加速状态的速度最好是一个固定值
				speedUpTimeLeft=speedTime;
				targetSpeedUp=speedUp;
				if(mSpeedMode==eSpeedMode.normal||mSpeedMode==eSpeedMode.speedDown)
					mSpeedMode=eSpeedMode.high;
			}
			else if(speedUpTimeLeft==0f)
			{
				targetSpeedUp=speedUp;
				speedUpTimeLeft=speedTime;
				mSpeedMode=eSpeedMode.speedUp;
				
				//启动加速的协程
				StartCoroutine(SpeedUpYield());
			}
		}
		
		IEnumerator SpeedUpYield()
		{
			float tempDeltaTime=speedUpDeltaTime;
			while(mSpeedMode==eSpeedMode.speedUp)
			{
				if(tempDeltaTime>0f)
				{
					tempDeltaTime-=Time.deltaTime;
					pc.moveSpeed=originalMoveSpeed+targetSpeedUp*tempDeltaTime/speedUpDeltaTime;
				}
				else
				{
					tempDeltaTime=speedUpDeltaTime;
					mSpeedMode=eSpeedMode.high;
					pc.moveSpeed=originalMoveSpeed+targetSpeedUp;
					break;
				}
				yield return null;
			}
			yield return null;
			while(mSpeedMode==eSpeedMode.high)
			{
				if(speedUpTimeLeft>0f)
				{
					speedUpTimeLeft-=Time.deltaTime;
				}
				else 
				{
					speedUpTimeLeft=0f;
					mSpeedMode=eSpeedMode.speedDown;
					break;
				}
				yield return null;
				
			}
			yield return null;
			while(mSpeedMode==eSpeedMode.speedDown)
			{
				if(tempDeltaTime>0f)
				{
					tempDeltaTime-=Time.deltaTime;
					pc.moveSpeed=originalMoveSpeed+targetSpeedUp*(1f-tempDeltaTime/speedUpDeltaTime);
				}
				else
				{
					tempDeltaTime=0f;
					mSpeedMode=eSpeedMode.normal;
					pc.moveSpeed=originalMoveSpeed;
					speedUpTimeLeft=0f;
					break;
				}
				yield return null;
				
			}
			yield return null;
			
		}
		
		
		private enum eSpeedMode
		{
			speedUp=0,
			speedDown=1,
			high=2,
			normal=3,
		}
		#endregion
		
		
		
	}
}