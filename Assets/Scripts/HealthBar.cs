using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

[SerializeField]
private Image image;

[SerializeField]
private Gradient gradient;

public void SetHealth(float healthNormalized)
{
    Debug.Log(healthNormalized);
    image.fillAmount = healthNormalized;
    image.color = gradient.Evaluate(healthNormalized);
}
}
