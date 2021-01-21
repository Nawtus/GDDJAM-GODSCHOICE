using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ship", menuName = "ScriptableObject/Ship")]
public class Ships : ScriptableObject
{
    public Sprite shipModel;

    public int health;
    public float speed;
    public int damage;
}
