using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SuperHero.Logical
{
	public class PropCreater : MonoBehaviour 
	{
		public List<int> PropIDs=new List<int>();
		public List<int> numProps=new List<int>();
		public float length=100f;
		public float gap=10f;
		//
		public List<int> HighObjectIDs=new List<int>();
		public List<int> numHigh=new List<int>();
		public List<int> lengthHigh=new List<int>();

		Transform propsParent;
		int [][] path;

//		// Use this for initialization
//		void Start ()
//		{
//
//			Init();
//		}

		void Init()
		{
			path=new int[3][];
			path[0]=new int[Mathf.FloorToInt(length/gap)];
			path[1]=new int[Mathf.FloorToInt(length/gap)];
			path[2]=new int[Mathf.FloorToInt(length/gap)];
			//初始化
			for(int i=0;i<path[0].Length;i++)
			{
				path[0][i]=0;
				path[1][i]=0;
				path[2][i]=0;
			}
			if(propsParent!=null)
			{
				foreach (Transform tt in propsParent.GetComponentsInChildren(typeof(Transform)))
				{
					if(tt!=propsParent)
						tt.gameObject.SetActive(false);
				}
			}
		}

//		void OnGUI()
//		{
//			string str="";
//			for(int i=0;i<path.Length;i++)
//			{
//				for(int j=0;j<path[i].Length;j++)
//				{
//					str+= path[i][j].ToString()+"  ";
//				}
//				str+="\n";
//			}
//			GUILayout.Label(str);
//		}

		/// <summary>
		/// 采用优先级队列啊，设置一个高优先级列表，其后n个空间无法放置,道具数量控制在30%左右，金币直接摆可行路径
		/// </summary>
		void SetProp()
		{
			Init();
			#region 已经不采用的方案，使用可行路径预设
//			//生成可行路径
//			for(int i=0;i<path[0].Length;i++)
//			{
////				if(i==0)
////				{
////					path[Random.Range(0,2)][i]=3;
////				}
////				else
////				{
////
////				}
//				path[Random.Range(0,2+1)][i]=3;
//			}
//			//标记0为空，1已被占用，2预置为空，3为可行路径，4为放置道具了的可行路径
//			for(int i=0;i<HighObjectIDs.Count;i++)
//			{
//				for(int j=numHigh[i];j>0;j--)
//				{
//					int a=Random.Range(0,2+1);
//					int b=Random.Range(0,path[0].Length-lengthHigh[i]-1+1);
//					while(path[a][b]!=0)//只有空的地方才能放置打了会爆东西的道具
//					{
//						a=Random.Range(0,2+1);
//						b=Random.Range(0,path[0].Length-lengthHigh[i]-1+1);
//					}
//
//					//放置道具
//					GameObject prop=null;
//					prop= GlobalInGame.CurrentPropManager.GetPropByID(HighObjectIDs[i]);
//					if(prop!=null)
//					{
//						prop.transform.position=transform.TransformPoint(new Vector3((a-1)*GlobalInGame.currentPC.xTrackOffset,1f,(b+0.5f)*gap));
//						prop.transform.rotation=transform.rotation;
//						prop.SetActive(true);
//						if(path[a][b]==0)
//							path[a][b]=1;
//						if(path[a][b]==3)
//							path[a][b]=4;
//					}
//					path[a][b]=1;
//					//摆放的爆出来的道具
//					for(int k=0;k<lengthHigh[i];k++)
//					{
//						path[a][b+k]=2;
//					}
//
//				}
//			}
//
//			for(int i=0;i<PropIDs.Count;i++)
//			{
//				for(int j=numProps[i];j>0;j--)
//				{
//					int a=Random.Range(0,2+1);
//					int b=Random.Range(0,path[0].Length-1+1);
//					//不是空的或者可行路径，那么就重新寻找
//					if(!(path[a][b]==0||path[a][b]==3))
//					{
//						a=Random.Range(0,2+1);
//						b=Random.Range(0,path[0].Length-1+1);
//					}
//					//放置道具
//					GameObject prop=null;
//					prop= GlobalInGame.CurrentPropManager.GetPropByID(PropIDs[i]);
//					if(prop!=null)
//					{
//						prop.transform.position=transform.TransformPoint(new Vector3((a-1)*GlobalInGame.currentPC.xTrackOffset,1f,(b+0.5f)*gap));
//						prop.transform.rotation=transform.rotation;
//						prop.SetActive(true);
//						Record rr= prop.AddComponent<Record>();
//						rr.a=a;
//						rr.b=b;
//						if(path[a][b]==0)
//							path[a][b]=1;
//						if(path[a][b]==3)
//							path[a][b]=4;
//					}
//				}
//			}
			#endregion
			#region 完全随机丢，丢一个是一个，哈哈
			//标记0为空，1已被占用，2预置为空，3为可行路径，4为放置道具了的可行路径
			for(int i=0;i<HighObjectIDs.Count;i++)
			{
				for(int j=numHigh[i];j>0;j--)
				{
					int a=Random.Range(0,2+1);
					int b=Random.Range(0,path[0].Length-lengthHigh[i]-1+1);
					while(path[a][b]!=0)//只有空的地方才能放置打了会爆东西的道具
					{
						a=Random.Range(0,2+1);
						b=Random.Range(0,path[0].Length-lengthHigh[i]-1+1);
					}

					//放置道具
					GameObject prop=null;
					prop= GlobalInGame.CurrentPropManager.GetPropByID(HighObjectIDs[i]);
					if(prop!=null)
					{
						prop.transform.position=transform.TransformPoint(new Vector3((a-1)*GlobalInGame.currentPC.xTrackOffset,1f,(b+0.5f)*gap));
						prop.transform.rotation=transform.rotation;
						prop.SetActive(true);
						if(path[a][b]==0)
							path[a][b]=1;
//						if(path[a][b]==3)
//							path[a][b]=4;
					}
					path[a][b]=1;
					//摆放的爆出来的道具
					for(int k=0;k<lengthHigh[i];k++)
					{
						path[a][b+k]=2;
					}

				}
			}

			for(int i=0;i<PropIDs.Count;i++)
			{
				for(int j=numProps[i];j>0;j--)
				{
					int a=Random.Range(0,2+1);
					int b=Random.Range(0,path[0].Length-1+1);
					//不是空的或者可行路径，那么就重新寻找
					while(path[a][b]!=0)
					{
						a=Random.Range(0,2+1);
						b=Random.Range(0,path[0].Length-1+1);
					}
					//放置道具
					GameObject prop=null;
					prop= GlobalInGame.CurrentPropManager.GetPropByID(PropIDs[i]);
					if(prop!=null)
					{
						//prop.transform.position=transform.localToWorldMatrix* transform.TransformPoint(new Vector3((a-1)*GlobalInGame.currentPC.xTrackOffset,1f,(b+0.5f-path[0].Length*0.5f)*gap));
						prop.transform.position=transform.TransformPoint(new Vector3((a-1)*GlobalInGame.currentPC.xTrackOffset,1f,(b+0.5f-path[0].Length*0.5f)*gap));

						prop.transform.rotation=transform.rotation;
						prop.SetActive(true);

						SetParent(prop);
						Record rr=prop.GetComponent<Record>();
						if(rr==null)
							rr= prop.AddComponent<Record>();
						rr.a=a;
						rr.b=b;
						if(path[a][b]==0)
							path[a][b]=1;

					}
				}
			}
			#endregion
		}


		void SetParent(GameObject propChild)
		{
			
			propsParent=transform.FindChild("props");
			if(propsParent==null)
			{
				propsParent=new GameObject("props").transform;
				propsParent.transform.parent=transform;
			}
			propChild.transform.parent=propsParent.transform;

		}
		
		//		List< GameObject> props=new List<GameObject>();
//		int hight=1;
//		int [] ids=new int[]{130008,130001,130002,130003,130004,130005,130006};
//		// Update is called once per frame
//		void Update () 
//		{
////			if(Input.GetKeyDown(KeyCode.A))
////			{
////				GameObject prop=null;
////				int idd=ids[ Random.Range(0,6)];
////				prop= GlobalInGame.CurrentPropManager.GetPropByID(idd);
////				if(prop!=null)
////				{
////					props.Add(prop);
////					prop.transform.position=new Vector3(0f,2f*hight,0f);
////					hight++;
////					prop.SetActive(true);
////				}
////			}
////			if(Input.GetKey(KeyCode.D))
////			{
////				GlobalInGame.CurrentPropManager.HideAll();
////			}
//			if(Input.GetKeyDown(KeyCode.C))
//			{
//				SetProp();
//			}
//
//		}
	}
}