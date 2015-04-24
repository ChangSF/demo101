using UnityEngine;
using System.Collections;

public class CatapultEndTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider  other)
	{
		if(other.tag=="Player")
		{

		}
	}
}
