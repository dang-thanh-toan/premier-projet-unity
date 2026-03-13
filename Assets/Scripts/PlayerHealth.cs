using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private IntVariable currentLifePoints;
    [SerializeField]
    private IntVariable maxLifePoints;

    private bool isInvulnerable = false;

    [SerializeField]
    private TextMeshProUGUI currentLifePointsText;




    // Start is called once before the first execution of Update after the MonoBehaviour is created

[SerializeField]
    private SpriteRenderer sr;

    [SerializeField]

    private VoidEventChannel OnTakeDamage;


    void Awake()
    {
        currentLifePoints.CurrentValue = maxLifePoints.CurrentValue;
        currentLifePointsText.SetText(currentLifePoints.CurrentValue.ToString());
      
    }

    public void TakeDamage(int damage = 1)
    {
        if (isInvulnerable)
        {
            return;
        }
        OnTakeDamage.Raise();
        isInvulnerable = true;
        StartCoroutine(InvulnerableDuration());
        currentLifePoints.CurrentValue = Mathf.Clamp(currentLifePoints.CurrentValue-damage,0,maxLifePoints.CurrentValue);
        currentLifePointsText.SetText(currentLifePoints.CurrentValue.ToString());

        

        if (currentLifePoints.CurrentValue == 0)
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
