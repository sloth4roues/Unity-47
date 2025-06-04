using UnityEngine;

public class EndGameHandler : MonoBehaviour
{
    [Header("Références")]
    public Transform playerCamera;         // La caméra du joueur (ex: Camera.main.transform)
    public Transform menu3DTarget;         // Le menu 3D dans la scène
    public MonoBehaviour cameraLookScript; // Le script de rotation à désactiver (ex: MouseLook, PlayerLook, etc.)

    [Header("Rotation")]
    public float rotationSpeed = 2f;
    private bool shouldRotate = false;

    void Update()
    {
        if (!shouldRotate) return;

        Vector3 direction = (menu3DTarget.position - playerCamera.position).normalized;
        direction.y = 0f; // pour éviter l'inclinaison haut/bas
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        playerCamera.rotation = Quaternion.Slerp(playerCamera.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    public void TriggerEndGameView()
    {
        shouldRotate = true;

        // Désactive le script de rotation de caméra
        if (cameraLookScript != null)
            cameraLookScript.enabled = false;

        // Montre et libère le curseur
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
