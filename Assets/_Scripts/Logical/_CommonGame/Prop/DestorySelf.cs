using UnityEngine;
using System.Collections;

public class DestorySelf : MonoBehaviour {
	public float degree=90f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0f,degree*Time.deltaTime,0f));
	}

	void OnTriggerEnter()
	{
		this.gameObject.SetActive(false);
	}

}
