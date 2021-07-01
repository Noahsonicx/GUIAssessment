using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CapsuleCollider), typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerControllerExample : MonoBehaviour
{
    private Transform CanTransform => camera.transform;




    [Header("Movement Settings")]
    [SerializeField, Min(1.0f)] private float defaultSpeed = 5f;
    [SerializeField, Min(1.0f)] private float wallSpeedModifier = 1f;
    [SerializeField, Min(1.5f)] private float sprintSpeedModifier = 2f;
    [SerializeField, Min(0.5f)] private float crouchSpeedModifier = .5f;
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference jumpAction;
    [SerializeField] private InputActionReference sprintAction;
    [SerializeField] private InputActionReference crouchAction;

    [Header("Look Settings")]
    [SerializeField] private InputActionReference lookAction;
    [SerializeField] private new Camera camera;
    // This value is set to a low number because our camera controller
    // is not framrate locked which means it fell smoother
    [SerializeField, Range(0, 3)] private float sensitivity = .5f;
    // This is how for up and down the camera will be able to look.
    // 90 means full vertical look without importing the camera.
    [SerializeField, Range(0, 90)] private float verticalLookCap = 90f;
    [SerializeField] private float cameraSmoothing = 1;

    private new CapsuleCollider collider;
    private new Rigidbody rigidbody;

    // The current rotation of the camera that gets updated every 
    // time the input is changed
    private Vector2 rotation = Vector2.zero;
    // The amount of movement that is waiting to be applied
    private Vector3 movement = Vector3.zero;

    private bool isSprinting = false;
    private bool isCrouching = false;

    // Start is called before the first frame update
    void Start()
    {
        collider = gameObject.GetComponent<CapsuleCollider>();
        rigidbody = gameObject.GetComponent<Rigidbody>();

        // This is how you line the function into the actual press/image
        // if the action such as moving the mouse will perform the 
        // lookAction
        lookAction.action.performed += OnLookPerformed;

        sprintAction.action.performed += (_context) => isSprinting = true;
        sprintAction.action.canceled += (_context) => isSprinting = false;
        crouchAction.action.performed += (_context) => isCrouching = true;
        crouchAction.action.canceled += (_context) => isCrouching = false;



        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        CanTransform.localRotation = Quaternion.AngleAxis(rotation.y, Vector3.left);
        transform.localRotation = Quaternion.AngleAxis(rotation.x, Vector3.up);

        // Apply the movement and reach it to 0
        UpdateMovement();
        transform.position += movement;
        movement = Vector3.zero;
    }
    private void OnLookPerformed(InputAction.CallbackContext _context)
    {
        // There has been some sort of Input update
        // get the actual value of the input
        Vector2 value = _context.ReadValue<Vector2>();



        rotation.x += value.x * sensitivity;
        rotation.y += value.y * sensitivity;

        // Present the vertical look from going outside the specified angle
        rotation.y = Mathf.Clamp(rotation.y, -verticalLookCap, verticalLookCap);
    }

    private void UpdateMovement()
    {
        float speed = defaultSpeed *
            (isCrouching ? crouchSpeedModifier :
            isSprinting ? sprintSpeedModifier : wallSpeedModifier)
            * Time.deltaTime;

        Vector2 value = moveAction.action.ReadValue<Vector2>();
        movement += transform.forward * value.y * speed;
        movement += transform.right * value.x * speed;
    }
}
