using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CameraFollw : MonoBehaviour {
	public Transform target;
	public Vector3 cameraOffset;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position=target.position+cameraOffset;
		transform.LookAt(target);
	}

	void OnGUI()
	{

	}
}
