using UnityEngine;
using System.Collections;

namespace SuperHero.Entity
{
	/// <summary>
	/// 道具信息，每个道具一个，包含道具的种类名编号，名字，个数，效果(暂时为加血，加速，攻击，载具)
	/// </summary>
	public class ItemInfo{
		public uint mItemID;
		public uint mItemNum;
		public string mName;
		public eItemType mItemTpye;
		public uint mBlood;
		public uint mSpeed;
		public float mSpeedTime;
		public uint mAttack;
		public bool mSkateboard;

	}
	public enum eItemType
	{
		AddBlood=0,
		AddSpeed=1,
		AddAttack=2,
		AddSkateboard=3,
	}
}
