using UnityEngine;
using System.Collections;


namespace SuperHero.Logical
{
	public class WaterTank : Obstacle
	{
		public Animation aa;
		public GameObject TeXiao;
		public Transform TXpos;
		// Use this for initialization
		void Start ()
		{
//			aa.transform.FindChild("PK_model_tank").GetComponent<Animation>();
		}
		
		// Update is called once per frame
		void Update () 
		{
		
		}

		public override void GetStartReflection()
		{
//			base.GetStartReflection();
			if(base.isActived==false)
			{
				Debug.Log("WaterTank Active");
				aa.Play("Take 001",PlayMode.StopAll);
				if(TeXiao!=null)
				{
					GameObject gg=(GameObject) Instantiate(TeXiao);
					gg.transform.position=TXpos.position;
				}
				base.isActived=true;
			}

		}

	}
}
