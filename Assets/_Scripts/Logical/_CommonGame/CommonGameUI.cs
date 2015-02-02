using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace SuperHero.Logical
{

	public class CommonGameUI : MonoBehaviour {


		public Image blood;
		public Text bloodNum;
		PlayerController pc;

		void Start()
		{
			pc=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		}


		void Update()
		{
			if(pc)
			{
				blood.fillAmount= Mathf.Clamp01( pc.CurrentGameInfo.HP*0.01f);
				bloodNum.text=pc.CurrentGameInfo.HP.ToString();
			}
		}


		public void Quit()
		{
			Debug.Log("Application is Exit!");
			Application.Quit();
		}

		public void Restart()
		{

		}

	}
}
