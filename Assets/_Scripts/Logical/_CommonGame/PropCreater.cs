using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SuperHero.Logical
{
	public class PropCreater : MonoBehaviour {
		public List<GameObject> Props=new List<GameObject>();
		public List<int> numProps=new List<int>();
		public float length=100f;
		public float gap=5f;
		//
		public List<GameObject> HighObject=new List<GameObject>();
		public List<int> numHigh=new List<int>();
		public List<int> lengthHigh=new List<int>();

		int [][] path;

		// Use this for initialization
		void Start ()
		{
			path[0]=new int[Mathf.FloorToInt(length/gap)];
			path[1]=new int[Mathf.FloorToInt(length/gap)];
			path[2]=new int[Mathf.FloorToInt(length/gap)];
			Init();

		}

		void Init()
		{
			//初始化
			for(int i=0;i<path.Length;i++)
			{
				path[0][i]=0;
				path[1][i]=0;
				path[2][i]=0;
			}

		}
		//采用优先级队列啊，设置一个高优先级列表，其后n个空间无法放置
		void SetProp()
		{
			//生成可行路径
			for(int i=0;i<path[0].Length;i++)
			{
//				if(i==0)
//				{
//					path[Random.Range(0,2)][i]=3;
//				}
//				else
//				{
//
//				}
				path[Random.Range(0,2)][i]=3;
			}
			//标记0为空，1已被占用，2预置为空，3为可行路径，4为放置道具了的可行路径
			for(int i=0;i<HighObject.Count;i++)
			{
				for(int j=numHigh[i];j>0;j--)
				{
					int a=Random.Range(0,2);
					int b=Random.Range(0,path[0].Length-lengthHigh[i]-1);
					while(path[a][b]!=0)//只有空的地方才能放置打了会爆东西的道具
					{
						a=Random.Range(0,2);
						b=Random.Range(0,path[0].Length-lengthHigh[i]-1);
					}
					path[a][b]=1;

				}
			}

			for(int i=0;i<Props.Count;i++)
			{
				for(int j=numHigh[i];j>0;j--)
				{
					path[Random.Range(0,2)][Random.Range(0,path[0].Length-1)]=3;
				}
			}
		}


		// Update is called once per frame
		void Update () 
		{
		
		}
	}
}