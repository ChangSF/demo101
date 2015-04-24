using UnityEngine;
using System.Collections;
using UnityEditor;
public class revertGO : ScriptableObject 
{
	[MenuItem ("Tools/Revert GameObject")]
	static void Revert_GameObject()
	{
		//获取选中的gameobject对象  
		GameObject [] selectedsGameobject= Selection.gameObjects;  
		
		GameObject prefab = PrefabUtility.FindPrefabRoot (selectedsGameobject[0]);  
		
		for (int i = 0; i < selectedsGameobject.Length; i++) {
			GameObject obj=selectedsGameobject[i];  
			if(PrefabUtility.GetPrefabType(obj)  == PrefabType.PrefabInstance)
			{
				Debug.Log("revert");
				PrefabUtility.RevertPrefabInstance(obj);
			}

		}
//			UnityEngine.Object newsPref= PrefabUtility.GetPrefabObject(obj);  
//			
//			//判断选择的物体，是否为预设  
//			if(PrefabUtility.GetPrefabType(obj)  == PrefabType.PrefabInstance){  
//				
//				UnityEngine.Object parentObject = PrefabUtility.GetPrefabParent(obj);   
//				//获取路径  
//				//string path = AssetDatabase.GetAssetPath(parentObject);  
//				//Debug.Log("path:"+path);  
//				//替换预设  
//				PrefabUtility.ReplacePrefab(obj,parentObject,ReplacePrefabOptions.ConnectToPrefab);  
//				//刷新  
//				AssetDatabase.Refresh();  
//			}  

	}


}
