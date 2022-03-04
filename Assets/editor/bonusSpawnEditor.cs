using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;


[CustomEditor(typeof(gemBonusSpawn))]
public class bonusSpawnEditor : Editor
{
    SerializedProperty paterns;

    //The Reorderable list we will be working with
    ReorderableList list;

    private void OnEnable()
    {
        //Gets the wave property in WaveManager so we can access it. 
        paterns = serializedObject.FindProperty("paterns");

        //Initialises the ReorderableList. We are creating a Reorderable List from the "wave" property. 
        //In this, we want a ReorderableList that is draggable, with a display header, with add and remove buttons        
        list = new ReorderableList(serializedObject, paterns, true, true, true, true);

        list.drawElementCallback = DrawListItems;
        list.drawHeaderCallback = DrawHeader;

    }

    void DrawListItems(Rect rect, int index, bool isActive, bool isFocused)
    {
        SerializedProperty element = list.serializedProperty.GetArrayElementAtIndex(index); //The element in the list

        // Create a property field and label field for each property. 

        // The 'mobs' property. Since the enum is self-evident, I am not making a label field for it. 
        // The property field for mobs (width 100, height of a single line)

        EditorGUI.LabelField(new Rect(rect.x, rect.y, 60, EditorGUIUtility.singleLineHeight), "prefab :");
        EditorGUI.PropertyField(
            new Rect(rect.x + 60, rect.y, 100, EditorGUIUtility.singleLineHeight),
            element.FindPropertyRelative("bonusPrefab"),
            GUIContent.none
        );

        EditorGUI.LabelField(new Rect(rect.x + 160, rect.y, 60, EditorGUIUtility.singleLineHeight), "patern :");
        EditorGUI.PropertyField(
            new Rect(rect.x + 220, rect.y, 100, EditorGUIUtility.singleLineHeight),
            element.FindPropertyRelative("patern"),
            GUIContent.none
        );

        EditorGUI.LabelField(new Rect(rect.x + 320, rect.y, 60, EditorGUIUtility.singleLineHeight), "id :");
        EditorGUI.PropertyField(
            new Rect(rect.x + 380, rect.y, 40, EditorGUIUtility.singleLineHeight),
            element.FindPropertyRelative("id"),
            GUIContent.none
        );

    }

    void DrawHeader(Rect rect)
    {
        string name = "paterns";
        EditorGUI.LabelField(rect, name);
    }

    //This is the function that makes the custom editor work
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        list.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }
}
