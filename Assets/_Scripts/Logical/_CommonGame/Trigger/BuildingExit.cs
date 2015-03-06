using UnityEngine;
using System.Collections;

public class BuildingExit : MonoBehaviour {
	void OnTriggerEnter()
	{
		GlobalInGame.CurrentBuildingCreater.CreateBuilding();
		StartCoroutine(MyDisable());
		//Destroy(this.gameObject.transform.parent.gameObject,2f);
	}

	IEnumerator MyDisable()
	{
		yield return new WaitForSeconds(2f);
		this.gameObject.transform.parent.gameObject.SetActive(false);
		yield return null;
	}

}
