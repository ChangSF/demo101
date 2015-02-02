using UnityEngine;
using System.Collections;

namespace SuperHero.Entity
{
	/// <summary>
	/// 首页商店状态信息
	/// </summary>
	public class MainStoreVO
	{
		public int nextTimeRefresh;     //刷新时间
		public GoodsItemVO[] goods;     //上架的商品（目前来看应该为6个）
	}
}
