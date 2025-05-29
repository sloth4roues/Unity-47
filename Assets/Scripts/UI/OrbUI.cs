using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrbUI : MonoBehaviour
{
    public TextMeshProUGUI orbText;

    void OnEnable()
    {
        OrbCollector.OnOrbChanged += UpdateOrb;
    }

    void OnDisable()
    {
        OrbCollector.OnOrbChanged -= UpdateOrb;
    }

    void UpdateOrb(int current, int max)
    {
        orbText.text = $"{current} / {max}";
    }
}
