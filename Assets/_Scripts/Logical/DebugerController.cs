using UnityEngine;
using System.Collections;

public class DebugerController : MonoBehaviour {
	public bool isDebug=true;
	// Use this for initialization
	void Start () {
		Debuger.EnableLog=isDebug;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
