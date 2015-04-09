using UnityEngine;
using System.Collections;

public class CancelInput : MonoBehaviour {

	void OnTriggerEnter(Collider  other)
	{
		if(other.gameObject.tag=="Player")
		{
			GlobalInGame.currentPC.CancelOP();
		}
	}
}
