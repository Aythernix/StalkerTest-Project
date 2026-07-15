using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : PlayerSystem
{
    [Header("Camera Settings")]
    [SerializeField] private float _sensitivityX;
    [SerializeField] private float _sensitivityY;
    [SerializeField] private float _maxLookUpAngle;
    [SerializeField] private float _maxLookDownAngle;



    private Vector2 _mouseLook;
    private float _rotX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleCameraMovement();
    }

    public void GetMouseLookInput(InputAction.CallbackContext context)
    {
        _mouseLook = context.ReadValue<Vector2>();
    }

    private void HandleCameraMovement()
    {
        var mouseX = _mouseLook.x * _sensitivityX * Time.deltaTime;
        var mouseY = _mouseLook.y * _sensitivityY * Time.deltaTime;

        _rotX -= mouseY;
        _rotX = Mathf.Clamp(_rotX, _maxLookDownAngle, _maxLookUpAngle);

        player.Data.playerCamera.transform.localRotation = Quaternion.Euler(_rotX, 0f, 0f);

        player.Data.playerBody.transform.Rotate(Vector3.up * mouseX);
    }
}
