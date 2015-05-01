using UnityEngine;
using System.Collections;

namespace SuperHero.Logical
{
	public class Obstacle : MonoBehaviour 
	{
		protected bool isActived=false;
		public int hitPoint=100;
		// Use this for initialization
		void Start () 
		{
			
		}
		
		// Update is called once per frame
		void Update () 
		{
			
		}

		public virtual void GetAttack()
		{

		}

		public virtual void GetStartReflection()
		{
			if(isActived==false)
			{
				Debug.Log("Active");
				isActived=true;
			}
		}

	}

}