using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(PlayerSettings))]
[CanEditMultipleObjects]
public class PlayerSettingsEditor : Editor {
//	PlayerSettings PS;

	public SerializedProperty
		Players_Prop,
		Size_Prop;

	void OnEnable () 
	{
//		PS = (PlayerSettings)target;
		Players_Prop = serializedObject.FindProperty ("Players");
		Size_Prop = serializedObject.FindProperty ("Data");

	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update ();

		DrawDefaultInspector ();

		Size_Prop.arraySize = Players_Prop.enumValueIndex + 1;

//		EditorGUILayout.PropertyField( Size_Prop );

//		PlayerSettings.data D = (PlayerSettings.data)Size_Prop.enumValueIndex;

//		switch( D )
//		{
//		case PlayerSettings.multiPlayer.Four:
//			EditorGUILayout.PropertyField( Size_Prop );
//			break;
//
//		case PlayerSettings.multiPlayer.Three:            
//			EditorGUILayout.PropertyField( Size_Prop );
//			break;
//			
//		case PlayerSettings.multiPlayer.Two:            
//			EditorGUILayout.PropertyField( Size_Prop );
//			break;
//
//		case PlayerSettings.multiPlayer.One:            
//			EditorGUILayout.PropertyField( Size_Prop );
//			break;
//		}

		serializedObject.ApplyModifiedProperties ();
	}
}
