using UnityEngine;
using System.Collections;

public class TestInput : MonoBehaviour {

	private Animator ant;
	// Use this for initialization
	void Start () {
		ant=gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			ant.CrossFade("fly over the wall left",.3f);
		}
		if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			ant.CrossFade("fly over the wall_right",.3f);
		}

	}
	string speed="20";
	bool AorB=true;
	bool DoubleJump=false;
	void OnGUI()
	{
		if(GUILayout.RepeatButton("Be Attacked"))
		{
			ant.CrossFade("being attacked",0.3f,0);
		}

		if(GUILayout.Button("Attack"))
		{
			ant.CrossFade("attack",0.3f,0);
		}



		if(GUILayout.Button("Fly"))
		{
			ant.CrossFade("glide",0.3f,0);
		}

		speed= GUILayout.TextField(speed);
		ant.SetFloat("MoveSpeed",float.Parse(speed));


		if(GUILayout.Button("Right"))
		{
			ant.CrossFade("right shift",0.3f,0);
		}
		if(GUILayout.Button("Left"))
		{
			ant.CrossFade("left shift",0.3f,0);
		}
		if(GUILayout.Button("Shovel"))
		{
			ant.CrossFade("shovel",0.3f,0);
		}
		if(GUILayout.Button("Jump A"))
		{
			ant.CrossFade("jump A",0.3f,0);
		}
		if(GUILayout.Button("jump B"))
		{
			ant.CrossFade("jump B",0.3f,0);
		}
		if(GUILayout.Button( "DoubleJump"))
		{
			ant.CrossFade("two jump",0.3f,0);
		}

		if(GUILayout.Button("Idle touch"))
		{
			ant.CrossFade("standby 2",0.3f,0);
		}



	}
}
