using UnityEngine;
using System.Collections;


namespace SuperHero.Entity
{
	public class HeroInfo  {
		private eHeroType mHeroType=eHeroType.Undefine;
		private int agility;

		public int Agility {
			get {
				return agility;
			}
			set {
				agility = value;
			}
		}

		private int strength;
		public int Strength {
			get {
				return strength;
			}
			set {
				strength = value;
			}
		}

	


		// 0
		// character_id
		public int heroId;

		public int HeroId {
			get {
				return heroId;
			}
			set {
				heroId = value;
			}
		}

		

		// 1
		// model 文件名，Resources中的文件名
		
		// 2
		// 中文名字
		private string name;
		public string Name 
		{
			get 
			{
				return name;
			}
			set 
			{
				name = value;
			}
		}
		// 3
		// 图标路径
		private string iconPath;

		public string IconPath {
			get {
				return iconPath;
			}
			set {
				iconPath = value;
			}
		}

		// 4
		// 解锁价值$
		private int money;

		public int Money {
			get {
				return money;
			}
			set {
				money = value;
			}
		}

		// 5
		// 基础攻击ID
		private int attack;

		public int Attack {
			get {
				return attack;
			}
			set {
				attack = value;
			}
		}

		// 6
		// 技能名ID
		private int skillId;

		public int SkillId {
			get {
				return skillId;
			}
			set {
				skillId = value;
			}
		}

		// 7
		// 大招名ID
		private int bigSkill;

		public int BigSkill {
			get {
				return bigSkill;
			}
			set {
				bigSkill = value;
			}
		}

		// 8
		// 基础血量
		private int baseBlood;

		public int BaseBlood {
			get {
				return baseBlood;
			}
			set {
				baseBlood = value;
			}
		}
		private int baseMP;
		public int BaseMP {
			get {
				return baseMP;
			}
			set {
				baseMP = value;
			}
		}



		// 9
		//基础物理攻击
		
		// 10
		// 基础魔法攻击
		
		// 11
		// 进场攻击顺序例如 0|0|1|1,0为基础攻击，1为技能攻击
		
		// 12
		// 循环攻击, 例如 0|1|0|1
		
		//13
		//备注，使用全角符号。
	}

	public enum eHeroType
	{
		Undefine=-1,
		Agility=0,
		Strength=1,
		Balance=2,
	}

}