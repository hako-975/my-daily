using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // joystick
    public Joystick joystick;
    public JoyButton jumpButton;

    public float turnSmoothTime = 0.1f;
    public float movementSpeed = 2f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;
    public float groundDistance = 0.25f;
    public float maxFallZone = -100f;

    public LayerMask groundMask;

    CharacterController characterController;

    Animator animator;

    GameObject cam;
    GameObject groundCheck;
    GameObject spawnPoint;

    Vector3 move;
    Vector3 velocity;

    float turnSmoothVelocity;
    float canJump = 0f;
    float horizontal;
    float vertical;

    bool isGrounded;
    bool isRunning;

    [HideInInspector]
    public float currentTransformY;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        animator = GetComponentInChildren<Animator>();

        cam = GameObject.FindGameObjectWithTag("MainCamera");
        groundCheck = GameObject.FindGameObjectWithTag("GroundCheck");
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");

        // move to first position
        characterController.enabled = false;
        characterController.transform.position = new Vector3(PlayerPrefsManager.instance.GetPlayerPositionX(), PlayerPrefsManager.instance.GetPlayerPositionY(), PlayerPrefsManager.instance.GetPlayerPositionZ());
        characterController.enabled = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if player fall
        if (characterController.transform.position.y < maxFallZone)
        {
            characterController.enabled = false;
            characterController.transform.position = spawnPoint.transform.position;
            characterController.enabled = true;
        }

        currentTransformY = GetComponent<Transform>().transform.eulerAngles.y;
        horizontal = Input.GetAxisRaw("Horizontal") + joystick.Horizontal;
        vertical = Input.GetAxisRaw("Vertical") + joystick.Vertical;

        isGrounded = Physics.CheckSphere(groundCheck.transform.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }

        move = new Vector3(horizontal, 0f, vertical).normalized;

        // movement
        if (move.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            characterController.Move(moveDirection.normalized * movementSpeed * Time.deltaTime);
        }

        // bool run animator
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        isRunning = hasHorizontalInput || hasVerticalInput;

        // jump
        if ((Input.GetKey(KeyCode.Space) || jumpButton.pressed) && isGrounded && Time.time > canJump)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            canJump = Time.time + 1f;
        }

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

        // animator
        animator.SetBool("IsRunning", isRunning);
        animator.SetBool("IsGrounded", isGrounded);
    }
}
