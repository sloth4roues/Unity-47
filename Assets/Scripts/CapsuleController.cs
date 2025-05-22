using UnityEngine;
using UnityEngine.InputSystem;

public class CapsuleController : MonoBehaviour
{
    [Header("D�placement")]
    public float moveSpeed = 5f;
    public float moveWalk = 2f;
    public float jumpForce = 5f;
    public float gravity = -9.81f;

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
            velocity.y = -2f;
        }

        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;

        if (isWalking)
        {
            controller.Move(move * moveWalk * Time.deltaTime);
        }
        else
        {
            controller.Move(move * moveSpeed * Time.deltaTime);

        }
        if (jumpQueued && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            jumpQueued = false;
        }
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
        if (context.performed && isGrounded)
        {
            isWalking = !isWalking;
        }
    }
}