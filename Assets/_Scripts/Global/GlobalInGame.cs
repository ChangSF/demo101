using UnityEngine;
using System.Collections;
using SuperHero.Logical;

public class GlobalInGame
{
	public static PlayerController currentPC=null;
	public static PropertyMaster currentPM=null;
	static PropManager currentPropManager=null;



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

	public static void Init()
	{
		currentPC=null;
		currentPM=null;
		currentPropManager=null;
	}
}
