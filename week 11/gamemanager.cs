using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject player;
    public GameObject gameOverUI;
    public GameObject tryHaderUI;
    public GameObject fightmeui;
    public animator fightMeAnimator
    private bool isGameOver = false;
    private bool hasTriggeredFightUI = false;

    void Update()
    {
        CheckLowHealth();
        GameEnd();
    }

    void CheckLowHealth()
    {
        if (playerHealth.health <= 90 && !hasTriggeredFightUI)
        {
            hasTriggeredFightUI = true;
            StartCoroutine(DelayedMessage());
        }
    }
    IEnumerator DelayedMessage()
    {
        playerHealth.healthText.text = "Health: 90";
        player.SetActive(true);
        fightmeui.SetActive(true);
        
        if (fightMeAnimator != null)
        {
            fightMeAnimator.Play("fightmeani");
            yield return new WaitForSeconds(2f);

            if (fightMeAnimator != null)
            {
                fightMeAnimator.Play("Idle");
            }
        }

        yield return new WaitForSeconds(2f);

        fightmeui.SetActive(false);
        player.SetActive(true);
    }

    void GameEnd()
    {
        if (playerHealth.health <= 0 && !isGameOver)
        {
            isGameOver = true;
            StartCoroutine(BeforeEnd());
        }
    }

    IEnumerator BeforeEnd()
    {
        playerHealth.healthText.text = "Health: 0";
        player.SetActive(false);
        tryHaderUI.SetActive(true);

        yield return new WaitForSeconds(3f);

        tryHaderUI.SetActive(false);
        gameOverUI.SetActive(true);
    }
}