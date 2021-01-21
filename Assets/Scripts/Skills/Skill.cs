using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public SkillData skillType;

    private Animator anim;
    private SpriteRenderer render;

    private int damage;
    private float countdown;

    void Start()
    {
        anim = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        render.sprite = skillType.model;
        damage = skillType.damage;
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
