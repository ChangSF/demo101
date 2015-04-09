using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace SuperHero.Logical
{
	public class BuildingCreater : MonoBehaviour 
	{
		public Vector3 buildPoint=Vector3.zero;
		public Vector3 buildDirection=Vector3.zero;
		public int maxBuildings=4;
		/// <summary>
		///最少几个直线的才能转弯
		/// </summary>
		public int minCross=3;
		/// <summary>
		/// 直线建筑物统计
		/// </summary>
		int straightCount=0;
		/// <summary>
		/// 当前触发的那个建筑的info
		/// </summary>
		public BuildingInfo currentBuildInfo=null;
		public BuildingInfo startBuildInfo;

		public GameObject buildPointGO;

		void Awake()
		{
			GlobalInGame.CurrentBuildingCreater=this;
		}
		void Start()
		{
			buildPointGO=new GameObject("buildPointGO");

			currentBuildInfo=startBuildInfo;
			for(int i=0;i<4;i++)
			{
				CreateBuilding();
			}
		}

		/// <summary>
		/// 随机构建路径
		/// </summary>
		public void CreateBuilding()
		{
			//直线型的建筑物
			if(straightCount<=minCross)
			{
				int id=Random.Range(1,4+1);
				GlobalInGame.buildLsit+=" A"+id.ToString();
				GameObject build= GlobalInGame.CurrentBuildingManager.GetBuildingByID(id);
				//build.SetActive(true);
				BuildingInfo info=build.GetComponent<BuildingInfo>();
				if(info==null)
				{
					Debuger.LogError("建筑的prefab里面没有附加Info类！！！");
					return;
				}
				createBB(build,info);


				straightCount++;
			}
			else//转弯的建筑物
			{
				int id=Random.Range(5,6+1);
				GlobalInGame.buildLsit+=" B"+id.ToString();
				GameObject build= GlobalInGame.CurrentBuildingManager.GetBuildingByID(id);
				BuildingInfo info=build.GetComponent<BuildingInfo>();
				if(info==null)
				{
					Debuger.LogError("建筑的prefab里面没有附加Info类！！！");
					return;
				}
				createBB(build,info);
				straightCount=0;
			}

		}

		void createBB(GameObject build,BuildingInfo info)
		{
			build.SetActive(true);
			//更新构建的位置点
			//buildPoint=currentBuildInfo.gameObject.transform.TransformPoint( currentBuildInfo.OutCenter+info.InCenter);
			buildPoint=buildPointGO.transform.TransformPoint( currentBuildInfo.OutCenter+info.InCenter);
			build.transform.position=buildPoint;
			buildPointGO.transform.position=buildPoint;
			//更新建筑物方向,欧拉角
			build.transform.eulerAngles=buildDirection;
			buildDirection+=info.directionEuler;
			buildPointGO.transform.eulerAngles=buildDirection;

			currentBuildInfo=info;
			build.transform.parent=GlobalInGame.CurrentBuildingManager.gameObject.transform;
			
		}
		
		public void CreateBuilding(int buildingID)
		{
			
		}

		private void Create()
		{

		}

		void OnGUI()
		{
			//GUILayout.Label(GlobalInGame.buildLsit);
		}
	}
}