using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuCanvasController : MonoBehaviour
{
    [Header("Menu")]
    public Button buttonPlay;
    private Animator animPlay;

    private bool canStart;
    private float delayScene;

    public Button buttonCredits;
    private Animator animCredits;

    public GameObject creditsImage;
    private bool creditsOpen;

    private void Start()
    {
        animPlay = buttonPlay.gameObject.GetComponent<Animator>();

        animCredits = buttonCredits.gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        StartTimer();
    }

    public void ShowCredits()
    {
        if (creditsOpen)
        {
            creditsImage.SetActive(false);
            creditsOpen = false;
            animCredits.SetTrigger("UnPressed");
        }
        else
        {
            creditsImage.SetActive(true);
            creditsOpen = true;
            animCredits.SetTrigger("Pressed");
        }
    }


    public void SceneGame()
    {
        canStart = true;
    }

    public void StartTimer()
    {
        if (canStart)
        {
            delayScene += Time.deltaTime;
        }

        if (delayScene >= 0.9f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void PlayPressed()
    {
        animPlay.SetTrigger("Pressed");
    }
}
