// using UnityEditor;
// using UnityEngine;

// public class ProjectNavigator : EditorWindow
// {
//     string pathSettingUI = "Assets/ModelData/ScriptableObject/SettingUIData.asset";

//     [MenuItem("Tools/Project Navigator")]
//     public static void ShowWindow()
//     {
//         GetWindow<ProjectNavigator>("Project Navigator");
//     }

//     private void OnGUI()
//     {
//         GUILayout.Label("Project Navigator", EditorStyles.boldLabel);

//         GUILayout.BeginHorizontal();
//         if (GUILayout.Button("i", GUILayout.Width(20), GUILayout.Height(20)))
//         {
//             EditorUtility.DisplayDialog("Help", "This is a help message for the Project Navigator tool.", "OK");
//         }

//         if (GUILayout.Button("SettingUI File"))
//         {
//             string path = pathSettingUI;
//             Object obj = AssetDatabase.LoadAssetAtPath<Object>(path);
//             if (obj != null)
//             {
//                 Selection.activeObject = obj;
//                 EditorGUIUtility.PingObject(obj);
//             }
//             else
//             {
//                 EditorUtility.DisplayDialog("Error", "File not found at the specified path.", "OK");
//             }
//         }
//         GUILayout.EndHorizontal();
//     }
// }
