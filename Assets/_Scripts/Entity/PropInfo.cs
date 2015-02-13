using UnityEngine;
using System.Collections;

namespace SuperHero.Entity
{
	public class PropInfo
	{
		public int ID;
		public float FlyTime;
		public float Gravity;
		public float FlySpeed;
		/// <summary>
		/// 损耗的血量
		/// </summary>
		public float Blood;
		public eAttackMode AttackMode;
		public string Description;
		public int NumMax;

		public PropInfo(){}
		public PropInfo(int id,float flyTime,float gravity,float flySpeed,float blood,eAttackMode attackMode,string description,int numMax)
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

	public enum eAttackMode
	{
		SingleAttack=0,
		GroupAttack=1,
		SingleRecover=2,
		SingleSpeedUp=3,
		GroupAttract=4,
		SingleAchieve=5,
	}

}
