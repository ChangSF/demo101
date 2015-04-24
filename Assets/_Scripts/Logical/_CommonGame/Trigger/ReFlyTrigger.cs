using UnityEngine;
using System.Collections;

public class ReFlyTrigger : MonoBehaviour 
{
	public float ySpeed=10f;
	void OnTriggerEnter(Collider  other)
	{
		if(other.tag=="Player")
			GlobalInGame.currentPC.ContinueFly(ySpeed);

		
	}

}
