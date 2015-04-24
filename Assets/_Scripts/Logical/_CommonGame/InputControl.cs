using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace SuperHero.Logical
{

	public delegate void VoidDelegate();
	public class InputControl : MonoBehaviour {
	#if UNITY_EDITOR_OSX

	#elif UNITY_EDITOR

	#elif UNITY_ANDROID

	#elif UNITY_IPHONE

	#endif
		public VoidDelegate JumpOP;
		public VoidDelegate FallDownOP;
		public VoidDelegate TurnLeft;
		public VoidDelegate TurnRight;
		public VoidDelegate Attack;
		private bool isReceiveOP=true;


		public bool IsReceiveOP {
			get {
				return isReceiveOP;
			}
			set {
				isReceiveOP = value;
			}
		}

		// Use this for initialization
		void Start () {

		}
		
		// Update is called once per frame
		void Update () {
			if (Input.GetMouseButtonDown(0) )
			{
				//Debug.Log(EventSystem.current.gameObject.name);
//				if (EventSystem.current.IsPointerOverGameObject())
//					Debug.Log("当前触摸在UI上");
//				
//				else Debug.Log("当前没有触摸在UI上");
			}
			if(isReceiveOP)
			{
				#if UNITY_EDITOR
				RespondKeyCode();
				#elif UNITY_ANDROID  || UNITY_IPONE
				RespondTouch();
				#else
				RespondKeyCode();
				#endif
			}



		}



		void RespondKeyCode()
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				GameObject.FindGameObjectWithTag("Player").GetComponent<PropertyMaster>().SpeedUp(10f,3f);
			}

			if(Input.GetKeyDown(KeyCode.UpArrow))
			{
				if(JumpOP!=null)
				{
					JumpOP.Invoke();
				}
			}
			if(Input.GetKeyDown(KeyCode.DownArrow))
			{
				if(FallDownOP!=null)
				{
					FallDownOP.Invoke();
				}
			}
			if(Input.GetKeyDown(KeyCode.LeftArrow))
			{
				if(TurnLeft!=null)
				{
					TurnLeft.Invoke();
				}
			}
			if(Input.GetKeyDown(KeyCode.RightArrow))
			{
				if(TurnRight!=null)
				{
					TurnRight.Invoke();
				}
			}
//			if(Input.GetKeyDown(KeyCode.Space))
//			{
//				if(Attack!=null)
//				{
//					Attack.Invoke();
//				}
//			}
		}

		bool isTouch=false;
		void RespondTouch()
		{

			if (Input.touchCount > 0)
			{

				Touch firstTouch=Input.GetTouch(0);
				if (firstTouch.phase == TouchPhase.Moved)
				{
					if(isTouch)
					{
						if(firstTouch.deltaPosition.x>firstTouch.deltaPosition.y)
						{
							if(firstTouch.deltaPosition.x>-firstTouch.deltaPosition.y)
							{
								if(TurnRight!=null)
								{
									TurnRight.Invoke();
								}
							}
							else
							{
								if(FallDownOP!=null)
									FallDownOP.Invoke();
							}
						}
						else
						{
							if(firstTouch.deltaPosition.x>-firstTouch.deltaPosition.y)
							{
								if(JumpOP!=null)
									JumpOP();
							}
							else
							{
								if(TurnLeft!=null)
									TurnLeft();
							}
						}
						isTouch=false;
					}

				}        
				else if (firstTouch.phase == TouchPhase.Began)
				{
					isTouch=true;

				}
			}
			else
			{

			}

		}
		
		
		
		
		
		
	}
	
}
