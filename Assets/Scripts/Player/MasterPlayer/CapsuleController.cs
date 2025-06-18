using UnityEngine;
using UnityEngine.InputSystem;

public class CapsuleController : MonoBehaviour
{
    [Header("Déplacement")]
    public float runSpeed = 5f;
    public float walkSpeed = 2f;
    public float jumpForce = 5f;
    public float gravity = -40f;

    [SerializeField] private CharacterController controller;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private bool isGrounded;
    [SerializeField] private Vector2 moveInput;
    [SerializeField] private bool jumpQueued;
    [SerializeField] private bool isWalking = false;

    private PlayerInput input;
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction walkRunAction;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        input = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        if (input?.actions != null)
        {
            moveAction = input.actions["Move"];
            jumpAction = input.actions["Jump"];
            walkRunAction = input.actions["WalkRun"];

            moveAction.performed += Move;
            moveAction.canceled += Move;
            jumpAction.performed += Jump;
            walkRunAction.performed += WalkRun;

            moveAction.Enable();
            jumpAction.Enable();
            walkRunAction.Enable();
        }
    }

    private void OnDisable()
    {
        if (moveAction != null)
        {
            moveAction.performed -= Move;
            moveAction.canceled -= Move;
        }
        if (jumpAction != null) jumpAction.performed -= Jump;
        if (walkRunAction != null) walkRunAction.performed -= WalkRun;
    }

    void Update()
    {
        if (GameSession.Instance != null && GameSession.Instance.gameEnded)
            return;

        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        float currentSpeed = isWalking ? walkSpeed : runSpeed;
        controller.Move(move * currentSpeed * Time.deltaTime);

        if (jumpQueued && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            jumpQueued = false;
        }

        velocity.y += (velocity.y < 0 ? gravity * 1.5f : gravity) * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
            jumpQueued = true;
    }

    private void WalkRun(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isWalking = !isWalking;
            Debug.Log("isWalking: " + isWalking);
        }
    }


}
