using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour
{
    public TextMeshProUGUI ammoText;

    void OnEnable()
    {
        Gun.OnAmmoChanged += UpdateAmmo;
    }

    void OnDisable()
    {
        Gun.OnAmmoChanged -= UpdateAmmo;
    }

    void UpdateAmmo(int current, int max)
    {
        ammoText.text = $"{current} / {max}";
    }
}
