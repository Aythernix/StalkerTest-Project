using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : PlayerSystem
{

    [Header("MovementSettings")]
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;

    private float _moveSpeed;

    private Vector3 _inputDirection;

    private CharacterController controller;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        
        // *Debug
        _moveSpeed = _walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 FinalMotion = Vector3.zero;

        FinalMotion += GetHorizontalMovement(_inputDirection);

        controller.Move(FinalMotion * Time.deltaTime);
    }

    public void HandlePlayerWalkInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            var input = context.ReadValue<Vector2>();
            _inputDirection = new Vector3(input.x, 0, input.y);
            Debug.Log(_inputDirection);
        }
        else if (context.canceled)
        {
            _inputDirection = Vector2.zero;
            Debug.Log(_inputDirection);
        }
    }

    public Vector3 GetHorizontalMovement(Vector3 dir)
    {
        var HorizontalMovement = transform.TransformDirection(dir.normalized * _moveSpeed);

        return HorizontalMovement;
    }
}
