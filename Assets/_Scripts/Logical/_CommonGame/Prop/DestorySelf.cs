using UnityEngine;
using System.Collections;

public class DestorySelf : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter()
	{
		this.gameObject.SetActive(false);
	}

}
