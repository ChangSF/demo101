using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace SuperHero.Logical
{
	public class BuildingCreater : MonoBehaviour 
	{
		public Vector3 buildPoint=Vector3.zero;
		public int maxBuildings=4;
		/// <summary>
		///最少几个直线的才能转弯
		/// </summary>
		public int minCross=3;
		/// <summary>
		/// 直线建筑物统计
		/// </summary>
		int straightCount=0;

		void Start()
		{
			GlobalInGame.CurrentBuildingCreater=this;
		}

		public void CreateBuilding()
		{
			//直线型的建筑物
			if(straightCount<=minCross)
			{
				int id=Random.Range(1,4+1);
				GameObject build= GlobalInGame.CurrentBuildingManager.GetBuildingByID(id);
				BuildingInfo info=build.GetComponent<BuildingInfo>();
				if(info==null)
				{
					Debuger.LogError("建筑的prefab里面没有附加Info类！！！");
					return;
				}

			}
			else//转弯的建筑物
			{
				int id=Random.Range(5,6+1);
				GameObject build= GlobalInGame.CurrentBuildingManager.GetBuildingByID(id);
				BuildingInfo info=build.GetComponent<BuildingInfo>();
				if(info==null)
				{
					Debuger.LogError("建筑的prefab里面没有附加Info类！！！");
					return;
				}
			}

		}

		public void CreateBuilding(int buildingID)
		{
			
		}

		private void Create()
		{

		}
	}
}