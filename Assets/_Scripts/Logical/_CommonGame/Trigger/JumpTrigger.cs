using UnityEngine;
using System.Collections;

public class JumpTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider  other)
	{
		if(other.gameObject.tag=="Player")
		{
//			GlobalInGame.currentPC.CancelOP();
			GlobalInGame.currentPC.Jump();
		}
	}
}
