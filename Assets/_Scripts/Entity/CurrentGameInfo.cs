using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SuperHero.Entity
{
	public class CurrentGameInfo  
	{
		public HeroInfo hero;
		public SkillInfo skill;
		public SkillInfo helpSkill;
		public float HP_Max;
		public float HP;
		public float MP_Max;
		public float MP;
		/// <summary>
		/// 生命恢复速度
		/// </summary>
		public float HP_Restore;

		public CurrentGameInfo(){}

		public CurrentGameInfo Init()
		{
			HP_Max=hero.BaseBlood;
			HP=HP_Max;
			MP_Max=hero.BaseMP;
			MP=MP_Max;


			return this;
		}

	}
}
