using UnityEngine;
using System.Collections;

public class flyStartTrigger : MonoBehaviour {
	public float ySpeed=10f;
	public float speed=10f;
	public float gravity=5f;



	void OnTriggerEnter(Collider other)
	{
		if(other.tag=="Player")
		{
			GlobalInGame.currentPC.FlyStart(ySpeed,speed,gravity);
		}
	}
}
