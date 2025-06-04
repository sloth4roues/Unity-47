using UnityEngine;

public class EndGameHandler : MonoBehaviour
{
    [Header("R�f�rences")]
    public Transform playerCamera;         // La cam�ra du joueur (ex: Camera.main.transform)
    public Transform menu3DTarget;         // Le menu 3D dans la sc�ne
    public MonoBehaviour cameraLookScript; // Le script de rotation � d�sactiver (ex: MouseLook, PlayerLook, etc.)

    [Header("Rotation")]
    public float rotationSpeed = 2f;
    private bool shouldRotate = false;

    void Update()
    {
        if (!shouldRotate) return;

        Vector3 direction = (menu3DTarget.position - playerCamera.position).normalized;
        direction.y = 0f; // pour �viter l'inclinaison haut/bas
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        playerCamera.rotation = Quaternion.Slerp(playerCamera.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    public void TriggerEndGameView()
    {
        shouldRotate = true;

        // D�sactive le script de rotation de cam�ra
        if (cameraLookScript != null)
            cameraLookScript.enabled = false;

        // Montre et lib�re le curseur
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
