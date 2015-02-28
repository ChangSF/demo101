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
				GameObject.Find("PropManager").GetComponent<PropManager>();
			if(currentPropManager==null)
				currentPropManager=new PropManager();
			return currentPropManager;
		}
	}
}
