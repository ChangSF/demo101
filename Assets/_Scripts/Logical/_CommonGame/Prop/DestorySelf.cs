using UnityEngine;
using System.Collections;

public class Property : MonoBehaviour {
	public float degree=90f;
	// Use this for initialization
	protected void Start () {
	
	}
	
	// Update is called once per frame
	protected void Update () {
		transform.Rotate(new Vector3(0f,degree*Time.deltaTime,0f));
	}

	protected void OnTriggerEnter()
	{
		this.gameObject.SetActive(false);
	}

}
