using UnityEngine;
using System.Collections;

public class Dead : MonoBehaviour {



	void OnControllerColliderHit(ControllerColliderHit hit) 
	{
		Debug.Log("dead");
		GlobalInGame.currentPC.Dead();
	}
	 
}
