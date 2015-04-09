using UnityEngine;
using System.Collections;

namespace SuperHero.Logical
{
	public class roundTrigger : MonoBehaviour {
		public Transform centeraa;
		public Vector3 center=Vector3.zero;
 		public float radius=1f;
		public eRoundDirection mRoundDre=eRoundDirection.Right;
		private PlayerController pc;
		void Start ()
		{

		}
		

		void Update ()
		{

		}

		void OnTriggerEnter(Collider other)
		{
			if(centeraa)
				center=centeraa.position;
			print ("roundCollider:"+other.name+" 开始进入圆形轨道");
			PlayerController pc=other.transform.GetComponent<PlayerController>();
			if(pc)
			{
				pc.CancelOP();
				if(mRoundDre==eRoundDirection.Right)
					pc.RoundRight(center);
				else if(mRoundDre==eRoundDirection.Left)
					pc.RoundLeft(center);
			}

		}




		void OnGUI()
		{
//			GUILayout.Label("");
//			GUILayout.Label(radius.ToString());
//			if(character)
//			GUILayout.Label(Vector3.Distance(character.position,center).ToString());
		}

		public enum eRoundDirection
		{
			Left=1,
			Right=2,
		}
	}
}
