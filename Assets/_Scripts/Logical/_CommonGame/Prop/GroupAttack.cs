using UnityEngine;
using System.Collections;
using SuperHero.Entity;
namespace SuperHero.Logical
{
	public class GroupAttack : MonoBehaviour {

		public int Id=130002;
		public float gravity=20f;
		public float flyTime=0.5f;
		public float flySpeed=10f;
		public int blood=-40;
		public ePropType PropType=ePropType.GroupAttack;
		public string description="群体范围攻击NPC";
		public int maxNum=1;
		private PropInfo propInfo;

//		void Start()
//		{
//
//			propInfo.ID=Id;
//			propInfo.Gravity=gravity;
//			propInfo.FlyTime=flyTime;
//			propInfo.FlySpeed=addedSpeed;
//			propInfo.Blood=blood;
//			propInfo.PropType=PropType;
//			propInfo.Description=description;
//			propInfo.NumMax=maxNum;
//		}

		void OnTriggerEnter()
		{
			propInfo=new PropInfo(Id,flyTime,gravity,flySpeed,blood,PropType,description,maxNum);
			GlobalInGame.currentPM.GetProp(propInfo);
			this.gameObject.SetActive(false);

		}
	}
}