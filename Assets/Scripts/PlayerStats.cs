using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Stats")]
public class PlayerStats : ScriptableObject
{
    public string entityName;
    public float health;
    public float stamina;
    public float movespeed;
    public bool alive;
}
