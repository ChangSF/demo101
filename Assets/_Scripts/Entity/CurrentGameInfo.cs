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
		public int HP_Max;
		public int HP;
		public int MP_Max;
		public int MP;
		
		public int goldCions=0;
		
		
		/// <summary>
		/// 生命恢复速度
		/// </summary>
		public int HP_Restore;
		
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
