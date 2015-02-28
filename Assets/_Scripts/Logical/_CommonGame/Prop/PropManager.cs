using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SuperHero.Entity;
using System.Collections.Specialized;
namespace SuperHero.Logical
{
	public class PropManager :MonoBehaviour {

		public Dictionary<int, GameObject> PrefabByID=new Dictionary<int, GameObject>();

		public Dictionary<int, Queue<GameObject>> Props=new Dictionary<int, Queue<GameObject>>();



		public void Init()
		{

		}

		public void Dispose()
		{

			foreach (Queue<GameObject> qq in Props)
			{
				foreach(GameObject pp in qq)
				{
					Destroy(pp);
				}
				qq.Clear();
			}
			Props.Clear();
			Debuger.Log("PropManager have Disposed!");
		}


		public GameObject GetPropByID(int propId)
		{
			Props.
		}



	}
}