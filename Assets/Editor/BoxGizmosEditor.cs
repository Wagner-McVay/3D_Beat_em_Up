//using UnityEngine;
//using UnityEditor;
//using System.Collections;
//
//[CustomEditor(typeof(BoxGizmos))]
//[CanEditMultipleObjects]
//public class BoxGizmosEditor : Editor {
//
//	BoxGizmos BG;
//
//
//
//	public SerializedProperty
//		SpawnType_Prop,
//		Players_Prop,
//		EnemyType_Prop;
//	
//	void OnEnable () 
//	{
//		PS = (BoxGizmos)target;
//		SpawnType_Prop = serializedObject.FindProperty ("SpawnType");
//		Size_Prop = serializedObject.FindProperty ("Data");
//		
//	}
//
//	public override void OnInspectorGUI()
//	{
//		serializedObject.Update ();
//		
//		DrawDefaultInspector ();
//		
//		Size_Prop.arraySize = Players_Prop.enumValueIndex + 1;
//		
//		EditorGUILayout.PropertyField( Size_Prop );
//		
//		BoxGizmos.type T = (BoxGizmos).type;
//		
//		switch( D )
//		{
//		case BoxGizmos.type.Players:
//			EditorGUILayout.PropertyField(, Size_Prop );
//			break;
//
//		case BoxGizmos.type.Enemys:          
//			EditorGUILayout.PropertyField( Size_Prop );
//			break;
//			
//		case BoxGizmos.type.Objects:      
//			EditorGUILayout.PropertyField( Size_Prop );
//			break;
//		}
//		
//		serializedObject.ApplyModifiedProperties ();
//	}
//}
//}
