using UnityEngine;
using System.Collections;

public class climbTrigger: MonoBehaviour 
{
	public Vector3 direction;



	void OnTriggerEnter(Collider  other)
	{
		GlobalInGame.currentPC.Climbing(direction);

	}
}
