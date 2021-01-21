using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : Bondaries
{
    public Ships shipType;

    private Rigidbody2D rigid;
    private SpriteRenderer model;
    private Animator anim;

    private int health;
    private float speed;
    private int damage;

    private bool isLookLeft = true;
    private string direction = "Foward";
    private float randomTime;
    private float randomCrono;
    private int randomDirection;


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        model = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();

        model.sprite = shipType.shipModel;

        health = shipType.health;
        speed = shipType.speed;
        damage = shipType.damage;

        randomTime = Random.Range(0, 3);
        randomDirection = Random.Range(0, 4);

    }



    void Update()
    {
        if (health >= 1)
        {
            Moving();
            RandomizeDirection();
        }
        else
        {
            anim.SetTrigger("Broke");
            rigid.velocity = new Vector2(0,0);
        }
    }


    void RandomizeDirection()
    {
        randomCrono += Time.deltaTime;

        if (randomCrono >= randomTime)
        {
            randomDirection = Random.Range(0, 4);
            randomTime = Random.Range(0, 3);
            randomCrono = 0;
        }

        switch (randomDirection)
        {
            case 0:
                direction = "Foward";
                break;
            case 1:
                direction = "Up";
                break;
            case 2:
                direction = "Down";
                break;
        }
    }

    public void Moving()
    {
        switch (direction)
        {
            case "Foward":
                rigid.velocity = new Vector2(speed, 0);
                break;
            case "Up":
                rigid.velocity = new Vector2(speed, speed) / 2;
                break;
            case "Down":
                rigid.velocity = new Vector2(speed, -speed) / 2;
                break;
        }
    }


    int TakeDamage(int damage)
    {
        return health -= damage;
    }


    void Destroy()
    {
        Destroy(this.gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Background"))
        {
            collision.GetComponentInChildren<PlayerController>().TakeDamage(damage);
            Destroy(this.gameObject);
        }


        if (collision.CompareTag("Skill"))
        {
            int skillDamage = collision.GetComponentInParent<Skill>().skillType.damage;
            TakeDamage(skillDamage);
        }
    }
}
