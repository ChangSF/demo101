using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace SuperHero.Logical
{
	public class BuildingManager : MonoBehaviour {

		public Dictionary <int,GameObject> PrefabBuildingIDs=new Dictionary<int, GameObject>();
		public Dictionary<int ,Queue<GameObject>> BuildingQueues=new Dictionary<int, Queue<GameObject>>();

		public List<int> idBuilding=new List<int>();
		public List<GameObject> prefabBuilding=new List<GameObject>();

		void OnAwake()
		{
			GlobalInGame.CurrentBuildingManager=this;
		}

		void Start()
		{

			if(idBuilding.Count==prefabBuilding.Count)
			{
				for(int i=0;i<idBuilding.Count;i++)
				{
					PrefabBuildingIDs.Add(idBuilding[i],prefabBuilding[i]);
				}
			}

		}


		public GameObject GetBuildingByID(int buildingID)
		{
			GameObject building=null;
			//Prefab里面寻找建筑物
			if(PrefabBuildingIDs.ContainsKey(buildingID))
			{
				Queue<GameObject> buildingQueue=null;
				if(!BuildingQueues.ContainsKey(buildingID))
				{
					buildingQueue=new Queue<GameObject>();
					BuildingQueues.Add(buildingID,buildingQueue);
				}
				else
				{
					buildingQueue=BuildingQueues[buildingID];
				}
				while(BuildingQueues[buildingID].Count>0&&BuildingQueues[buildingID].Peek()==null)
				{
					BuildingQueues[buildingID].Dequeue();
				}
				if(BuildingQueues[buildingID].Count==0||BuildingQueues[buildingID].Peek().active==true)
				{
					building=(GameObject)Instantiate(PrefabBuildingIDs[buildingID]);
					buildingQueue.Enqueue(building);
				}
			}
			else
			{
				Debuger.Log("哎呀，这里面没有这个建筑物的ID呢，记错了吧？补补吧");
			}
			return building;
		}

		public void GetPrefabsFromFile()
		{

		}


	}
}
