using UnityEngine;
using System.Collections;

public class JumpTrigger : MonoBehaviour 
{

	public float ySpeed=20f;


	void OnTriggerEnter(Collider  other)
	{
		if(other.gameObject.tag=="Player")
		{
			GlobalInGame.currentPC.ClimbStart(ySpeed);
			//GlobalInGame.currentPC.ClimbStart();
		}
	}
}
