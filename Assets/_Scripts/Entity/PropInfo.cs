using UnityEngine;
using System.Collections;

namespace SuperHero.Entity
{
	[SerializeField]
	public class PropInfo
	{
		[SerializeField]
		public int ID;
		[SerializeField]
		public float FlyTime;
		[SerializeField]
		public float Gravity;
		[SerializeField]
		public float FlySpeed;
		/// <summary>
		/// 损耗的血量
		/// </summary>
		[SerializeField]
		public int Blood;
		[SerializeField]
		public ePropType AttackMode;
		[SerializeField]
		public string Description;
		[SerializeField]
		public int NumMax;
		
		public PropInfo(){}
		public PropInfo(int id,float flyTime,float gravity,float flySpeed,int blood,ePropType attackMode,string description,int numMax)
		{
			this.ID=id;
			this.FlyTime=flyTime;
			this.Gravity=gravity;
			this.FlySpeed=FlySpeed;
			this.Blood=blood;
			this.AttackMode=attackMode;
			this.NumMax=numMax;
		}
		
	}
	[SerializeField]
	public enum ePropType
	{
		SingleAttack=0,
		GroupAttack=1,
		SingleRecover=2,
		SingleSpeedUp=3,
		GroupAttract=4,
		SingleAchieve=5,
		GoldIcon=6,
	}
	
}
