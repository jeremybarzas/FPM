using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WeaponBehaviour : MonoBehaviour
{
    public WeaponStats configStats;

    // Use this for initialization
    void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerBehaviour>() != null)
        {
            other.GetComponent<PlayerBehaviour>().TakeDamage(configStats.damage);
        }
    }
}

[CustomEditor(typeof(WeaponBehaviour))] //use attribute and pass your class
public class EditorWeaponBehaviour : Editor //naming convention is Editor + name of class
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI(); //always call this when you first start writing your inspector
        var prop = serializedObject.FindProperty("configStats"); //find the property you want to draw
        if (prop != null) //if we have that property redraw it
        {
            //this prevents an editor value that did not get assigned throwing errors
            var so = new SerializedObject(prop.objectReferenceValue); //get the properties object reference
            EditorGUILayout.LabelField("Name", so.FindProperty("weaponName").stringValue); //draw from that object reference
            EditorGUILayout.LabelField("Damage", so.FindProperty("damage").floatValue.ToString()); //draw from that object reference           
        }
    }
}
