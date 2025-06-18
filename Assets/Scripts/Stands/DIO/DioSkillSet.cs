using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class DioSkillSet : MonoBehaviour
{
    public float dashDistance = 5f;
    public float dashDelay = 0.1f;
    public float dashEndlag = 0.3f;

    private bool isDashing = false;
    private Vector3 lastMoveDirection;
    private CharacterController controller;
    private PlayerInput playerInput;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        if (move.sqrMagnitude > 0.01f)
        {
            lastMoveDirection = transform.TransformDirection(move.normalized);
        }
    }

    public void OnSkill1(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && !isDashing)
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
