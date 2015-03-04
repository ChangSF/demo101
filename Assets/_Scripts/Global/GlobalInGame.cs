using UnityEngine;
using System.Collections;
using SuperHero.Logical;

public class GlobalInGame
{
	public static PlayerController currentPC=null;
	public static PropertyMaster currentPM=null;
	static PropManager currentPropManager=null;
	static BuildingManager currentBuildingManager=null;


	public static PropManager CurrentPropManager {
		get {
			if(currentPropManager==null)
			{
				GameObject propManagerGO=GameObject.Find("PropManager");
				currentPropManager=propManagerGO.GetComponent<PropManager>();
				if(currentPropManager==null)
				{
					if(propManagerGO==null)
						propManagerGO=new GameObject("PropManager");
					if(propManagerGO!=null)
					{
						currentPropManager=propManagerGO.AddComponent<PropManager>();
					}
				}
			}

			return currentPropManager;
		}
		set {
			currentPropManager = value;
		}
	}

	public static BuildingManager CurrentBuildingManager {
		get {
			if(currentBuildingManager==null)
			{
				GameObject buildingManager=GameObject.Find("BuildingManager");
				if(buildingManager==null)
				{
					buildingManager=new GameObject("BuildingManager");
				}
			}
			return currentBuildingManager;
		}
		set {
			currentBuildingManager = value;
		}
	}

	public static void Init()
	{
		currentPC=null;
		currentPM=null;
		currentPropManager=null;
	}
}
