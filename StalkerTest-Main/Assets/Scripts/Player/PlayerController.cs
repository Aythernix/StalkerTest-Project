using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : PlayerSystem
{

    [Header("MovementSettings")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _runSpeed;

    private Vector3 _inputDirection;

    private CharacterController controller;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        controller.Move(_inputDirection);
    }

    public void HandlePlayerWalkInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            var input = context.ReadValue<Vector2>();
            _inputDirection = new Vector3(input.x, 0, input.y);
            Debug.Log(_inputDirection);
        }
    }
}
