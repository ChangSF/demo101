using UnityEngine;
using System.Collections;
using SuperHero.Entity;

namespace SuperHero.Logical
{
	public class SingleAttack : MonoBehaviour {
		
		private PropInfo prop;
		
		// Use this for initialization
		void Start () {
			prop=new PropInfo(130001,0.5f,10f,0f,25,eAttackMode.SingleAttack,"单体正直线攻击NPC",1);
		}
		
		// Update is called once per frame
		void Update () {
			
		}
		
		void OnTriggerEnter(Collider other)
		{
			if(other.gameObject.tag=="Player")
			{
				GlobalInGame.currentPM.GetProp(prop);
//				if(GlobalInGame.currentPC.mTrackNum==PlayerController.eTrackNum.Three)
//				{
//					Ray[] rays=new Ray[3];
//					Vector3 originalPostion=Vector3.zero;
//					switch(GlobalInGame.currentPC.mTrack)
//					{
//					case PlayerController.eTrack.midLeft:
//						originalPostion.x=GlobalInGame.currentPC.xTrackOffset;
//						break;
//					case PlayerController.eTrack.middle:
//						originalPostion.x=0f;
//						break;
//					case PlayerController.eTrack.midRight:
//						originalPostion.x=-GlobalInGame.currentPC.xTrackOffset;
//						break;
//					default:break;
//					}
//					for(int i=0;i<3;i++)
//					{
//						rays[i]=new Ray(
//							GlobalInGame.currentPC.gameObject.transform.TransformPoint(
//							new Vector3( originalPostion-GlobalInGame.currentPC.xTrackOffset*(i-1f),0f,0f))
//							,GlobalInGame.currentPC.gameObject.transform.TransformDirection(Vector3.forward));
//
//							
//					}
							
							//Need Change需要修改
							
							
							//
				}
							
				else if(GlobalInGame.currentPC.mTrackNum==PlayerController.eTrackNum.Five)
				{
				
				}
				this.gameObject.SetActive(false);
						

			}
		}
	}
