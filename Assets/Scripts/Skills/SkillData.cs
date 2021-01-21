using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "ScriptableObject/Skill")]
public class SkillData : ScriptableObject
{
    public GameObject type;
    public Sprite model;

    public Texture2D cursor;
    public Sprite iconBordaDefault;
    public Sprite iconBordaSelected;

    public float delay;
    public int damage;
    public float countdown;
}
