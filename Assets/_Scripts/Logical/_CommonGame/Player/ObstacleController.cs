using UnityEngine;
using System.Collections;

namespace SuperHero.Logical
{
	public class ObstacleController : MonoBehaviour {

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () 
		{
			for(int i=0;i<5;i++)
			{
				RaycastHit hit;
				//Debug.DrawLine(transform.position+new Vector3((i-2)*GlobalInGame.currentPC.xTrackOffset,1f,0f),transform.position+new Vector3((i-2)*GlobalInGame.currentPC.xTrackOffset,1f,0f)+transform.forward*20f,Color.red);

				if(Physics.Raycast(transform.position+new Vector3((i-2)*GlobalInGame.currentPC.xTrackOffset,1f,0f),transform.forward,out hit,20f,1<<10))
				{
					Obstacle ob=hit.transform.GetComponent<Obstacle>();
					if(ob!=null)
						ob.GetStartReflection();
				}
			}
		}
		void FixedUpdate()
		{

		}




	}
}