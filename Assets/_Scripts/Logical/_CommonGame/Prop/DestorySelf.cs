using UnityEngine;
using System.Collections;

public class DestorySelf : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0f,90f*Time.deltaTime,0f));
	}

	void OnTriggerEnter()
	{
		this.gameObject.SetActive(false);
	}

}
