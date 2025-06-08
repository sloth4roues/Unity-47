using UnityEngine;

public class EndGameHandler : MonoBehaviour
{
    [Header("R�f�rences")]
    public MonoBehaviour cameraLookScript; // Le script de rotation � d�sactiver

    public void TriggerEndGameView()
    {
        // D�sactive le script de rotation de la cam�ra
        if (cameraLookScript != null)
            cameraLookScript.enabled = false;

        // Lib�re et affiche le curseur
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
