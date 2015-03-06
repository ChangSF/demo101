using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SuperHero.Entity;
using System.Collections.Specialized;
namespace SuperHero.Logical
{
	public class PropManager :MonoBehaviour 
	{

		public Dictionary<int, GameObject> PrefabByID=new Dictionary<int, GameObject>();

		public Dictionary<int, Queue<GameObject>> Props=new Dictionary<int, Queue<GameObject>>();

		public List<GameObject> prefabs;
		public List<int > ids;

		/// <summary>
		/// 加载prefab，依据路径来，但是测试阶段使用2个list列表代替
		/// </summary>
		public void Init()
		{
			Dispose();
			if(prefabs.Count==ids.Count)
			{
				int length=prefabs.Count;
				for(int i=0;i<length;i++)
				{
					PrefabByID.Add(ids[i],prefabs[i]);

					//Debuger.Log(ids[i].ToString());
				}
			}
			GlobalInGame.CurrentPropManager=this;
		}


		public void Dispose()
		{

			foreach (Queue<GameObject> qq in Props.Values)
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

		/// <summary>
		/// 向道具管理器请求道具，根据所需道具的ID来进行,如无相对应道具ID的预设，则返回值为Null，并打印error
		/// </summary>
		/// <returns>向道具管理器请求的道具,如无相对应道具ID的预设，则返回值为Null</returns>
		/// <param name="propId">所需道具的ID </param>
		public GameObject GetPropByID(int propId)
		{
			Queue<GameObject> propQueue;
			GameObject result=null;
			//找队列顶部的道具是否处于激活状态
			if(Props.TryGetValue(propId,out propQueue))
			{
				if(propQueue.Peek().active==false)
				{
					result=propQueue.Dequeue();
				}
			}
			else
			{
				//prefab里面有这个ID的道具，那么初始化道具实例的队列
				if(PrefabByID.ContainsKey(propId))
				{
					propQueue=new Queue<GameObject>();
					Props.Add(propId,propQueue);
				}
				else
				{
					string str="哎呀，prefab里面没有这个prop的ID呀，快点补补:"+propId.ToString();
					str+="\n"+PrefabByID.Count.ToString();
					Debuger.Log(str);
					return null;
				}
			}
			//道具队列顶部仍使用或者没有实例化过
			if(result==null)
			{

				if(PrefabByID.ContainsKey(propId))
				{
					GameObject prefab;
					if(PrefabByID.TryGetValue(propId,out prefab))
					{
						result=(GameObject)Instantiate(prefab);
						result.SetActive(false);

					}
					else
					{
						Debuger.Log("哎呀2，prefab里面没有这个prop的ID呀，快点补补:"+propId.ToString());
						return null;
					}
				}
			}
			if(result!=null)
			{
				propQueue.Enqueue(result);
			}
			return result;

		}

		public void HideGameObject(GameObject prop)
		{
			prop.SetActive(false);
		}

		public void HideAll()
		{
			foreach (Queue<GameObject> qq in Props.Values)
			{
				foreach(GameObject pp in qq)
				{
					pp.SetActive(false);
				}
			}
		}

		void Start()
		{
			Init();
		}

		public void GetPrefabsFromFile()
		{
			return;
		}


	}
}