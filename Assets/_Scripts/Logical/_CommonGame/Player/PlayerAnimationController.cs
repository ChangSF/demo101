using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SuperHero.Logical
{
	public  delegate void AntCallback();

	public class PlayerAnimationController : MonoBehaviour {


		private RuntimeAnimatorController controller;
		private AntCallback animationEnd;
		private Animator amtor;

		private string lastclip="";
		private string currentclip="";
		List <AntCallback> callbackList=new List<AntCallback>();
		// Use this for initialization
		void Start () {
			OnEnable();
		}

		void OnEnable()
		{
			amtor=gameObject.GetComponent<Animator>();
			controller=amtor.runtimeAnimatorController;

//			print ( controller.animationClips.Length);
		}


		// Update is called once per frame
		void Update () 
		{
//			AnimatorStateInfo stateinfo = amtor.GetCurrentAnimatorStateInfo(0);
//			currentclip= stateinfo.IsName("run").ToString();
//
//			print( stateinfo.shortNameHash);
//			print(currentclip);
//			if(lastclip!=currentclip&&animationEnd!=null)
//			{
//				animationEnd.Invoke();
//				foreach(AntCallback aa in callbackList)
//				{
//					animationEnd-=aa;
//				}
//				callbackList.Clear();
//			}
//			if(Input.GetKeyDown(KeyCode.Space))
//			{
//				amtor.CrossFade("attack",0.3f);
//				amtor.GetCurrentAnimatorStateInfo(0).shortNameHash
//			}
		}

		public void PlayAnimationByName(string name,AntCallback callback)
		{
			amtor.CrossFade(name,0.3f);
			AnimatorClipInfo[] infos= amtor.GetCurrentAnimatorClipInfo(0);
			currentclip= infos[0].clip.name;
			lastclip=currentclip;
			animationEnd+=callback;
			callbackList.Add(callback);
		}

		public void PlayAnimationById(int id,AntCallback callback)
		{

		}

	}
}

