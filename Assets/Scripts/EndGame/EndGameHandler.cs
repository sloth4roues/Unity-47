using UnityEngine;

public class EndGameHandler : MonoBehaviour
{
    [Header("Références")]
    public MonoBehaviour cameraLookScript; // Le script de rotation à désactiver

    public void TriggerEndGameView()
    {
        // Désactive le script de rotation de la caméra
        if (cameraLookScript != null)
            cameraLookScript.enabled = false;

        // Libère et affiche le curseur
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
