using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SuperHero.Logical
{
	public  delegate void AntCallback();

	public class PlayerAnimationController : MonoBehaviour {

		public float changeSpeed=15f;

		private RuntimeAnimatorController controller;
		private AntCallback animationEnd;
		private Animator amtor;

		public Animator Amtor {
			get {
				return amtor;
			}
			set {
				amtor = value;
			}
		}

		// Use this for initialization
		void Start () {
			OnEnable();
		}

		void OnEnable()
		{
			amtor=gameObject.GetComponent<Animator>();
			controller=amtor.runtimeAnimatorController;

		}


		// Update is called once per frame
		void Update () 
		{
			if(GlobalInGame.currentPC!=null&&amtor!=null)
			{
				amtor.SetFloat("speed", GlobalInGame.currentPC.moveSpeed-changeSpeed);
			}
		}

		public void TurnLeft()
		{
			amtor.CrossFade("left shift",0.1f);
		}
		public void TurnRight()
		{
			amtor.CrossFade("right shift",0.1f);
		}
		/// <summary>
		/// End With FlyEnd()
		/// </summary>
		public void Fly()
		{
			amtor.CrossFade("glide",0.3f);
			Debug.Log("fly");
			amtor.SetBool("fly",true);
		}
		public void FlyJump()
		{
			amtor.CrossFade("jump B 0",0.3f);
		}

		public void FlyEnd()
		{
			amtor.CrossFade("squat",0.3f);
			amtor.SetBool("fly",false);
		}
		public void FlyAttack()
		{
			amtor.CrossFade("fly attack",0.3f);
		}
		public void FlyHit()
		{
			amtor.CrossFade("fly hit",0.3f);
		}
		public void JumpA()
		{
			amtor.CrossFade("jump A",0.3f);
		}
		public void JumpB()
		{
			amtor.CrossFade("jump B",0.3f);
		}
		public void JumpTwo()
		{
			amtor.CrossFade("two jump",0.3f);
		}
		public void BeingAttacked()
		{
			amtor.CrossFade("being attacked",0.3f);
		}
		public void Attack()
		{
			amtor.CrossFade("attack",0.3f);
		}
		public void AttackTwo()
		{
			amtor.CrossFade("two attack",0.3f);
		}
		public void FailDown()
		{
			Shovel();
		}
		public void Shovel()
		{
			amtor.CrossFade("shovel",0.3f);
		}
		public void WallRight()
		{
			amtor.CrossFade("fly over the wall_right",0.3f);
		}
		public void WallLeft()
		{
			amtor.CrossFade("fly over the wall_left",0.3f);
		}
		public void RunA()
		{
			amtor.CrossFade("run A",0.3f);
		}
		public void RunB()
		{
			amtor.CrossFade("run B",0.3f);
		}
		public void Idle()
		{
			amtor.CrossFade("idle",0.3f);
		}
		public void Stand()
		{
			Idle();
		}
		public void StandTwo()
		{
			amtor.CrossFade("standby 2",0.3f);
		}
		public void Dead()
		{
			amtor.CrossFade("death",0.3f);
		}


	}
}

