using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DictionaryTest))]
public class DictionaryEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (((DictionaryTest)target).ModifyValues) 
        {
            if (GUILayout.Button("Save changes")) 
            {
                ((DictionaryTest)target).DeserializeDictioanry();
            }
        }
    }
}