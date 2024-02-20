using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float jumpForce;
    private Vector3 targetPosition;
    [SerializeField] float laneDistance = .1f; // Distancia entre carriles
    [SerializeField] float laneChangeSpeed = .1f;
    //[SerializeField] float speed = .1f;

    private PlayerActions playerActions;
    private Rigidbody rb;

    private void Awake()
    {
        playerActions = new PlayerActions();
        playerActions.Enable();
    }

    //private void FixedUpdate()
    //{
        //Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        //rb.MovePosition(rb.position + forwardMove);
        //rb.AddForce(Vector3.forward * speed, ForceMode.Impulse);
    //}

    void Start()
    {
        playerActions.Standard.Jump.performed += Jump;
        playerActions.Standard.Left.performed += Left;
        playerActions.Standard.Right.performed += Right;
        rb = GetComponent<Rigidbody>();
        targetPosition = transform.position;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
    }

    private void Left(InputAction.CallbackContext context)
    {
        targetPosition.x -= laneDistance;
    }

    private void Right(InputAction.CallbackContext context)
    {
        targetPosition.x += laneDistance;
    }

    void Update()
    {
        Vector3 newX = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * laneChangeSpeed);
        transform.position = newX;
    }
}