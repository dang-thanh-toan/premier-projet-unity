using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

[SerializeField]
private Image image;

[SerializeField]
private Gradient gradient;

 [SerializeField]
private IntVariable currentLifePoints;
[SerializeField]
    private IntVariable maxLifePoints;

    [SerializeField]
    private VoidEventChannel OnPlayerTakeDamage;

void OnEnable()
    {
        OnPlayerTakeDamage.OnEventRaised += UpdateBar;
    }
void OnDisable()
    {
        OnPlayerTakeDamage.OnEventRaised -= UpdateBar;
    }

    void UpdateBar()
    {
        SetHealth((float) currentLifePoints.CurrentValue / maxLifePoints.CurrentValue);
    }
    public void SetHealth(float healthNormalized)
{
    Debug.Log(healthNormalized);
    image.fillAmount = healthNormalized;
    image.color = gradient.Evaluate(healthNormalized);
}
}
