using UnityEngine;
using UnityEngine.InputSystem;

public class CapsuleController : MonoBehaviour
{
    [Header("Déplacement")]
    public float runSpeed = 5f;
    public float walkSpeed = 2f;
    public float jumpForce = 5f;
    public float gravity = -40f;  // Gravité augmentée pour éviter flottement

    [SerializeField] private CharacterController controller;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private bool isGrounded;
    [SerializeField] private Vector2 moveInput;
    [SerializeField] private bool jumpQueued;
    [SerializeField] private bool isWalking = false;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;  // Pour coller le joueur au sol
        }

        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        float currentSpeed = isWalking ? walkSpeed : runSpeed;
        controller.Move(move * currentSpeed * Time.deltaTime);

        if (jumpQueued && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            jumpQueued = false;
        }

        // Une seule application de la gravité
        if (velocity.y < 0)
            velocity.y += gravity * 1.5f * Time.deltaTime;
        else
            velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            jumpQueued = true;
        }
    }

    public void WalkRun(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isWalking = !isWalking;
        }
    }
}
