using UnityEngine;
using System.Collections;

public class climbTrigger: MonoBehaviour 
{
	public Vector3 direction;

	// Use this for initialization
	void Start () 
	{
		OnEnable();
	}


	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnEnable()
	{

	}

	void OnTriggerEnter(Collider  other)
	{
		print(other.name+" climbing...");
		GlobalInGame.currentPC.Climbing(new Vector3(-90f,0f,0f));

	}
}
