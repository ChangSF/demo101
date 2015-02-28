using UnityEngine;
using System.Collections;
using SuperHero.Entity;
namespace SuperHero.Logical
{
	public class GroupAttackPlay : MonoBehaviour {

		public float gravity=20f;
		public float flyTime=0.5f;
		public float addedSpeed=10f;
		public float distance=10f;
		private PropInfo propInfo;

		/// <summary>
		/// 特效的实现
		/// </summary>
		public GameObject LiZi;

		public GameObject lz;

		public float ySpeed=0f;
		public bool isFlying=false;
		// Use this for initialization
		void Start ()
		{

		}
		
		// Update is called once per frame
		void Update () 
		{
			if(isFlying)
			{
				ySpeed-=Time.deltaTime*gravity;
				transform.Translate(
					transform.TransformVector( 
				           new Vector3(0f,ySpeed*Time.deltaTime,(addedSpeed+GlobalInGame.currentPC.moveSpeed)*Time.deltaTime)));
				StartCoroutine(FlyEnd());



			}


		}

		public void Init()
		{
			isFlying=false;
			isEnter=false;
			transform.position=Vector3.zero;
			transform.rotation=Quaternion.identity;
			transform.localScale=new Vector3(1f,1f,1f);
		}

		public void Init(Vector3 postion,Quaternion rotation,Vector3 scale)
		{
			isFlying=false;
			transform.position=postion;
			transform.rotation=rotation;
			transform.localScale=scale;
		}
		/// <summary>
		/// 使用前必须进行初始化!!!!!!
		/// </summary>
		/// <param name="gravity">Gravity.</param>
		/// <param name="flyTime">Fly time.</param>
		public void Flying(float gravity,float flyTime,float rotateSpeed)
		{
			this.gravity=gravity;
			this.flyTime=flyTime;
			this.addedSpeed=rotateSpeed;
			ySpeed=gravity*flyTime*0.5f;
			isFlying=true;

		}

		/// <summary>
		/// 使用前必须进行初始化!!!!!!
		/// </summary>
		/// <param name="gravity">Gravity.</param>
		/// <param name="flyTime">Fly time.</param>
		public void Flying(PropInfo propInfo)
		{
			this.propInfo=propInfo;
			this.gravity=propInfo.Gravity;
			this.flyTime=propInfo.FlyTime;
			this.addedSpeed=propInfo.FlySpeed;
			ySpeed=gravity*flyTime*0.5f;
			isFlying=true;
			this.gameObject.SetActive(true);
		}

		bool isEnter=false;
		void OnCollisionEnter(Collision other)
		{

			if(isEnter==false)
			{
				isEnter=true;
				StopCoroutine(FlyEnd());
				if(lz==null&&LiZi!=null)
				{
					lz=(GameObject)Instantiate(LiZi);
				}
				//粒子效果的播放啊，重置啊什么操作的调用
				
				/////////////
				isFlying=false;
				Debuger.Log("B O O M ! ! !");
				//RaycastHit[] hits= Physics.CapsuleCastAll(Vector3.zero,Vector3.zero,20f,Vector3.up,distance);
//				RaycastHit[] hits= Physics.SphereCastAll(transform.position,distance*5f,Vector3.forward);
				Ray ray=new Ray(transform.position,transform.position+new Vector3(0f,0.1f,0f));
				RaycastHit[] hits=Physics.SphereCastAll(ray,distance);
				if(hits.Length>0)
				{
					foreach(RaycastHit hit in hits)
					{
						//Obstacle障碍物
						if(hit.collider.gameObject.layer==10)
						{
							hit.collider.gameObject.SetActive(false);
						}
						//Monster怪物
						if(hit.collider.gameObject.layer==11)
						{
							hit.collider.gameObject.SetActive(false);
						}
					}
				}
				gameObject.SetActive(false);
			}

		}

		IEnumerator FlyEnd()
		{
			yield return new WaitForSeconds(flyTime*4f);
			Debuger.Log("time end!");
			isFlying=false;
			this.gameObject.SetActive(false);
			yield return null;
		}

	}
}