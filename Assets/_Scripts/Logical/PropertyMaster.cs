using UnityEngine;
using System.Collections;

namespace SuperHero.Logical
{
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

		void Start () 
		{
			pc=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
			if(pc==null)
			{
				pc=GameObject.FindGameObjectWithTag("Player").AddComponent<PlayerController>();
			}
			originalMoveSpeed=pc.moveSpeed;
			
		}

		#region 攻击效果


		#endregion

		#region 回血效果
		public void AddBlood(float addBlood)
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