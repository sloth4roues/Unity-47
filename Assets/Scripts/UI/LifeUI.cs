using TMPro;
using UnityEngine;

public class LifeUI : MonoBehaviour
{
    public TextMeshProUGUI lifeText;

    void OnEnable()
    {
        LifePlayer.OnHPChanged += UpdateLife;
    }

    void OnDisable()
    {
        LifePlayer.OnHPChanged -= UpdateLife;
    }

    void UpdateLife(int current, int max)
    {
        lifeText.text = $"{current} / {max}";
    }
}

