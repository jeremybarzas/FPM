using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerBehaviour : MonoBehaviour, IDamageable
{
    public PlayerStats configStats;

    public void TakeDamage(float damage)
    {
        configStats.health -= damage;
    }

    // Use this for initialization
    void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}

[CustomEditor(typeof(PlayerBehaviour))] //use attribute and pass your class
public class EditorPlayerBehaviour : Editor //naming convention is Editor + name of class
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI(); //always call this when you first start writing your inspector
        var prop = serializedObject.FindProperty("configStats"); //find the property you want to draw
        if (prop != null) //if we have that property redraw it
        {
            //this prevents an editor value that did not get assigned throwing errors
            var so = new SerializedObject(prop.objectReferenceValue); //get the properties object reference
            EditorGUILayout.LabelField("Name", so.FindProperty("entityName").stringValue); //draw from that object reference
            EditorGUILayout.LabelField("Health", so.FindProperty("health").floatValue.ToString()); //draw from that object reference
            EditorGUILayout.LabelField("Stamina", so.FindProperty("stamina").floatValue.ToString()); //draw from that object reference
            EditorGUILayout.LabelField("Move Speed", so.FindProperty("movespeed").floatValue.ToString()); //draw from that object reference
            EditorGUILayout.TextField("Alive", so.FindProperty("alive").boolValue.ToString()); //draw from that object reference
        }
    }
}
