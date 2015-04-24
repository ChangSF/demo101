using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	AsyncOperation op;
	float tempProgress = 0;
	float nowProgress = 0;
	
//	private void Update()
//	{
//		if (op != null)
//		{
//			//没有加载完成
//			if (!op.isDone && op.progress < 0.9f)
//			{
//				tempProgress = op.progress;
//				if (nowProgress < tempProgress)
//				{
//					nowProgress++;
//					SetLoadingPercentage(nowProgress);
//				}
//			}
//			else if (op.isDone || op.progress >= 0.9f)
//			{
//				tempProgress = 100;
//				if (nowProgress < tempProgress)
//				{
//					nowProgress += 10;
//					if (nowProgress > 100) nowProgress = 100;
//					SetLoadingPercentage(nowProgress);
//				}
//				else
//				{
//					op.allowSceneActivation = true;
//				}
//			}
//		}
//	}
	
	private IEnumerator StartLoading_3(int scene)
	{
		yield return new WaitForEndOfFrame();
		
		Application.backgroundLoadingPriority = ThreadPriority.High;
		op = Application.LoadLevelAsync(scene);
		op.allowSceneActivation = false;
		
		print("线程1");
		
		yield return op;
	}
}
