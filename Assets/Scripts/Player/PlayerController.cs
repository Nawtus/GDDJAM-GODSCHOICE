using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : PlayerBehaviours
{
    private AudioController audioController;

    private Animator anim;

   // public Animator stormIconAnim;
   // public Animator tornadoIconAnim;
    //public Animator tsunamiIconAnim;

    private Vector2 mousePos;
    public SkillData[] skills;
    public int skillSelect;

    [SerializeField] int health;

    void Start()
    {

        stormCrono = skills[0].countdown;
        tornadoCrono = skills[1].countdown;
        tsunamiCrono = skills[2].countdown;


       audioController = GameObject.FindGameObjectWithTag("AudioController").GetComponentInChildren<AudioController>();

        anim = GetComponent<Animator>();
        health = 5;
    }



    void Update()
    {
        Inputs();
        VerificateSumoner();

        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }


    void VerificateSumoner()
    {
        if (canSumonerStorm == false)
        {
            CountdownStorm();
            if (stormCrono >= skills[0].countdown)
            {
                canSumonerStorm = true;
            }
        }

        if (canSumonerTornado == false)
        {
            CountdownTornado();
            if (tornadoCrono >= skills[1].countdown)
            {
                canSumonerTornado = true;
            }
        }

        if (canSumonerTsunami == false)
        {
            CountdownTsunami();
            if (tsunamiCrono >= skills[2].countdown)
            {
                canSumonerTsunami = true;
            }
        }
    }



    void Inputs()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(1))
        {
            skillSelect += 1;

            if (skillSelect > 2)
            {
                skillSelect = 0;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            switch (skillSelect)
            {
                case 0:
                    if (canSumonerStorm)
                    {
                        anim.SetTrigger("Charge");
                       // stormIconAnim.enabled = true;
                        Skill(skills[0].type, mousePos);
                        audioController.playSfx(audioController.sfxStorm, 1f);
                        stormCrono = 0;
                        canSumonerStorm = false;
                    }
                    break;
                case 1:
                    if (canSumonerTornado)
                    {
                        anim.SetTrigger("Charge");
                       // tornadoIconAnim.enabled = true;
                        audioController.playSfx(audioController.sfxTornado, 1f);
                        Skill(skills[1].type, mousePos);
                        tornadoCrono = 0;
                        canSumonerTornado = false;
                    }
                    break;
                case 2:
                    if (canSumonerTsunami)
                    {
                        anim.SetTrigger("Charge");
                       // tsunamiIconAnim.enabled = true;
                        audioController.playSfx(audioController.sfxTsunami, 0.8f);
                        Skill(skills[2].type, mousePos);
                        tsunamiCrono = 0;
                        canSumonerTsunami = false;
                    }
                    break;
            }
        }
    }


    void Skill(GameObject skillType, Vector2 mousePos)
    {
        Instantiate(skillType, mousePos, new Quaternion(0, 0, 0, 0));
    }

    void SfxCharge()
    {
        audioController.playSfx(audioController.sfxLoad, 1f);
    }

    void SfxAttack()
    {
        audioController.playSfx(audioController.sfxAttack, 1f);
    }


    public int TakeDamage(int damage)
    {
        anim.SetTrigger("TakeDamage");
        return health -= damage;
    }
}
