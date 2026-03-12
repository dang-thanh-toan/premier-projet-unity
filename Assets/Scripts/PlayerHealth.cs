using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int currentLifePoints;
    [SerializeField]
    private int maxLifePoints;

    private bool isInvulnerable = false;

    [SerializeField]
    private TextMeshProUGUI currentLifePointsText;

    [SerializeField]
    private HealthBar healthBar;


    // Start is called once before the first execution of Update after the MonoBehaviour is created

[SerializeField]
    private SpriteRenderer sr;


    void Awake()
    {
        currentLifePoints = maxLifePoints;
        currentLifePointsText.SetText(currentLifePoints.ToString());
        healthBar.SetHealth((float) currentLifePoints / maxLifePoints);
    }

    public void TakeDamage(int damage = 1)
    {
        if (isInvulnerable)
        {
            return;
        }
        isInvulnerable = true;
        StartCoroutine(InvulnerableDuration());
        currentLifePoints = Mathf.Clamp(currentLifePoints-damage,0,maxLifePoints);
        currentLifePointsText.SetText(currentLifePoints.ToString());

        healthBar.SetHealth((float) currentLifePoints / maxLifePoints);

        if (currentLifePoints == 0)
        {
            Debug.Log("Game over");
        }
    }

    IEnumerator InvulnerableDuration()
    {

        isInvulnerable = true;
        float duration = 1.25f;
        float timeElapsed = 0f;
        float flashDuration = 0.2f;
        float flashTimeElapsed = 0f;
        Debug.Log("End");

bool isVisible = true;

     while(timeElapsed < duration)
    {
        timeElapsed += Time.deltaTime;
        flashTimeElapsed += Time.deltaTime;
        if (flashTimeElapsed >= flashDuration)
        {
          if (isVisible)
          {
            sr.color = Color.clear;
          }
          else
          {
              sr.color = Color.white;
          }
          flashTimeElapsed = 0f;
            isVisible = !isVisible;
        }

       yield return null;
}
        sr.color = Color.white;
        isInvulnerable = false;
    }
}
