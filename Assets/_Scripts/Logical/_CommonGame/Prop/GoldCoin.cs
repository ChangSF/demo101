using UnityEngine;
using System.Collections;
using SuperHero.Entity;

namespace SuperHero.Logical
{
	public class GoldCoin : DestorySelf {
		[SerializeField]
		public PropInfo jinbi;

		public int id=130008;

		public ePropType propType=ePropType.GoldIcon;
		public string description="金币";
		public int numMax=1;

		// Use this for initialization
		protected void Start ()
		{
			base.Start();
			jinbi=new PropInfo(id, 0f, 0f, 0f, 0,propType, description,numMax);
		}
		
		// Update is called once per frame
		protected void Update () 
		{
			base.Update();
		}
		protected void OnTriggerEnter()
		{
			GlobalInGame.currentPC.GetProps(jinbi);
			base.OnTriggerEnter();
			
		}
		
	}
}
