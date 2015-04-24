//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor;
//using System.IO;
//
//[CustomEditor(typeof(StoreCars))]
//public class StoreCarsEditor : Editor {
//	StoreCars _target;
//
//
//	void OnEnable()
//	{
//		_target = (StoreCars)target;
//	}
//
////	#if UNITY_ANDROID
////	"jar:file://" + Application.dataPath + "!/assets/";
////	#elif UNITY_IPHONE
////	"file://"+  	Application.dataPath + "/Raw/";
////	#else
////	"file://"+Application.dataPath + "/StreamingAssets/";	
//	public override void OnInspectorGUI()
//	{
//		DrawDefaultInspector();
//
//
//		EditorGUILayout.BeginHorizontal();
//		if(GUILayout.Button("Save Cars"))
//		{
//			if(EditorUtility.DisplayDialog("Save cars infomation?","This operation will destory last cars information!", "OK", "Cancel"))
//			{
//				//FileInfo carsFile=new FileInfo(Application.streamingAssetsPath+@"/scenesData/"+EditorApplication.currentScene.Trim("Assets/".ToCharArray())+@"/cars.txt");
//				FileInfo carsFile=new FileInfo(Application.streamingAssetsPath+@"/scenesData/"+_target.sceneName+@"/cars.txt");
//
//				if(_target.isDebug)
//					Debug.Log(carsFile.Directory.FullName);
//				if(!Directory.Exists(carsFile.Directory.FullName))
//				{
//					Directory.CreateDirectory(carsFile.Directory.FullName);
//				}
//				FileStream fs=carsFile.Open(FileMode.Create);
//				StreamWriter sw=new StreamWriter(fs);
//				Transform [] cars=_target.transform.GetComponentsInChildren<Transform>();
//				foreach(Transform car in cars)
//				{
//					if(car.parent!=null&& car.parent.name==_target.gameObject.name)
//					{
//
//						string s=string.Format("name:{0};position:{1};rotation:{2};scale:{3};",
//						                       car.name,car.position.ToString(),car.rotation.ToString(),car.localScale.ToString());
//						sw.WriteLine(s);
//					}
//				}
//				//sw.WriteLine("Save OK!");
//				sw.Close();
//				fs.Close();
//			}
//		}
//		EditorGUILayout.EndHorizontal();
//		EditorGUILayout.BeginHorizontal();
//		if(GUILayout.Button("Load Cars"))
//		{
//			if(EditorUtility.DisplayDialog("Save cars infomation?","This operation will destory last cars information!", "OK", "Cancel"))
//			{
//				FileInfo carsFile=new FileInfo(Application.streamingAssetsPath+@"/scenesData/"+EditorApplication.currentScene.Trim("Assets/".ToCharArray())+@"/cars.txt");
//				if(_target.isDebug)
//					Debug.Log(carsFile.Directory.FullName);
//				if(!Directory.Exists(carsFile.Directory.FullName))
//				{
//					Directory.CreateDirectory(carsFile.Directory.FullName);
//				}
//				FileStream fs=carsFile.Open(FileMode.Create);
//				StreamWriter sw=new StreamWriter(fs);
//				Transform [] cars=_target.transform.GetComponentsInChildren<Transform>();
//				foreach(Transform car in cars)
//				{
//					if(car.parent!=null&& car.parent.name==_target.gameObject.name)
//					{
//						
//						string s=string.Format("name:{0};position:{1};rotation:{2};scale:{3};",
//						                       car.name,car.position.ToString(),car.rotation.ToString(),car.localScale.ToString());
//						sw.WriteLine(s);
//					}
//				}
//				sw.WriteLine("Save OK!");
//				sw.Close();
//				fs.Close();
//			}
//		}
//		EditorGUILayout.EndHorizontal();
//
//
//	}
//
//}
