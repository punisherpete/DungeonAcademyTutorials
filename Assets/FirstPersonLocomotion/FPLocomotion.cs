using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FPLocomotion : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float mouseX;
    private float mouseY;

    private float rotationX;

    [SerializeField] private float speed;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float jumpForce;

    [SerializeField] private Transform playerRoot;
    [SerializeField] private Transform groundPoint;
    [SerializeField] private Rigidbody playerRig;

    private bool IsGrounded =>
        Physics.OverlapSphere(groundPoint.position,
            0.1f, groundMask).Length != 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        ReadInput();
        Rotate();
        Move();
    }

    private void ReadInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
            Jump();
    }

    private void Rotate()
    {
        float rotationY =
            transform.localEulerAngles.y +
            mouseX * mouseSensitivity * Time.deltaTime;

        rotationX -= mouseY *
            mouseSensitivity * Time.deltaTime;

        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.localEulerAngles =
            new Vector3(0f, rotationY, 0f);
        playerRoot.localEulerAngles =
            new Vector3(rotationX, 0f, 0f);
    }

    private void Jump()
    {
        playerRig.AddForce(Vector3.up * jumpForce,
            ForceMode.Acceleration);
    }

    private void Move()
    {
        Vector3 moveDirection =
            transform.forward * verticalInput
            + transform.right * horizontalInput;

        transform.position +=
            moveDirection * speed * Time.deltaTime;
    }
}