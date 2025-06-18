using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class TimeDash : MonoBehaviour
{
    public float dashDistance = 5f;
    public float dashDelay = 0.1f;
    public float dashEndlag = 0.3f;

    private CharacterController controller;
    private Vector3 lastMoveDirection;
    private bool isDashing = false;

    [SerializeField] private InputActionReference dashAction;  // Associe ton action "Dash"
    [SerializeField] private InputActionReference moveAction;  // Associe ton action "Move" (Vector2)

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        dashAction.action.performed += OnDash;
        dashAction.action.Enable();
        moveAction.action.Enable();
    }

    private void OnDisable()
    {
        dashAction.action.performed -= OnDash;
        dashAction.action.Disable();
        moveAction.action.Disable();
    }

    private void Update()
    {
        // Met à jour la direction selon le stick / clavier
        Vector2 input = moveAction.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        if (move.sqrMagnitude > 0.01f)
        {
            lastMoveDirection = transform.TransformDirection(move.normalized);
        }
    }

    private void OnDash(InputAction.CallbackContext ctx)
    {
        if (!isDashing)
        {
            StartCoroutine(PerformDash());
        }
    }

    private IEnumerator PerformDash()
    {
        isDashing = true;

        yield return new WaitForSeconds(dashDelay);

        if (lastMoveDirection == Vector3.zero)
        {
            lastMoveDirection = transform.forward;
        }

        controller.Move(lastMoveDirection * dashDistance);

        yield return new WaitForSeconds(dashEndlag);
        isDashing = false;
    }
}
