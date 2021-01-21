using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    private PlayerController player;

    [Header("Storm")]
    public Animator stormBordaAnim;
    public Image stormBordaImage;
    public Image stormImage;

    [Header("Tornado")]
    public Animator tornadoBordaAnim;
    public Image tornadoBordaImage;
    public Image tornadoImage;

    [Header("Tsunami")]
    public Animator tsunamiBordaAnim;
    public Image tsunamiBordaImage;
    public Image tsunamiImage;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        stormBordaImage.sprite = player.skills[0].iconBordaDefault;
        tornadoBordaImage.sprite = player.skills[1].iconBordaDefault;
        tsunamiBordaImage.sprite = player.skills[2].iconBordaDefault;
    }



    void Update()
    {
        stormImage.fillAmount = player.stormCrono / player.skills[0].countdown;
        tornadoImage.fillAmount = player.tornadoCrono / player.skills[1].countdown;
        tsunamiImage.fillAmount = player.tsunamiCrono / player.skills[2].countdown;

        switch (player.skillSelect)
        {
            case 0:
                tsunamiBordaImage.sprite = player.skills[2].iconBordaDefault;
                stormBordaImage.sprite = player.skills[0].iconBordaSelected;
                break;

            case 1:
                stormBordaImage.sprite = player.skills[0].iconBordaDefault;
                tornadoBordaImage.sprite = player.skills[1].iconBordaSelected;
                break;
            case 2:
                tornadoBordaImage.sprite = player.skills[1].iconBordaDefault;
                tsunamiBordaImage.sprite = player.skills[2].iconBordaSelected;
                break;
        }
    }
}
