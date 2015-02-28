using UnityEngine;
using System.Collections;
using SuperHero.Entity;

namespace SuperHero.Logical
{
	public class RecoverHP : MonoBehaviour {

		PropInfo prop;

		// Use this for initialization
		void Start () {
			prop=new PropInfo(130004,0,0,0,20f,eAttackMode.SingleRecover,"恢复玩家血量",0);
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		void OnTriggerEnter(Collider other)
		{
			if(other.gameObject.tag=="Player")
			{
				GlobalInGame.currentPC.CurrentGameInfo.HP+=20f;
				this.gameObject.SetActive(false);
			}
		}
	}
}
