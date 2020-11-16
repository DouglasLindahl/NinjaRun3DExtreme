using System.Collections;


using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    //sätter vars för controllern och kameran
    public CharacterController controller;
    public Transform cam;

    //floats för spelarens speed, gravtitationskonstanten, jump height och sliding.
    public float speed;
    float gravity = -20f;
    public float jumpHeight = 3;
    float slideMultiplier = 1.7f;
    float dashAmount;
    public float duration = 1f;

    Vector3 velocity;

    public Transform playerBody;

    //vectors för normala player skala och en för hur liten spelaren blir när man crouchar.
    public Vector3 playerScale;
    private Vector3 crouchScale = new Vector3(1, 0.5f, 1);

    bool lockMovement = false;
    bool canTempJump;
    bool isGrounded;

    //Float för hur länge slide duration är

    //vars för vad ground är
    public Transform groundCheck;
    public float groundDistance = .5f;
    public LayerMask groundMask;

    float turnSmoothVelocity;
    float turnSmoothTime = 0.1f;

    float speedIncreaseWallRun = 10f;
    float tempGravity;

    void Start()
    {
        playerScale = transform.localScale;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            tempGravity = gravity;
            canTempJump = true;
            gravity = -4;
            speed += speedIncreaseWallRun;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wall")
        {
            gravity = tempGravity;
            speed -= speedIncreaseWallRun;
        }
    }

    void Update()
    {
        //determines what ground is
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //while standing on ground velocity is reduced
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (isGrounded)
        {
            dashAmount = 1;
        }

        //if button for jump is pressed and player is standing on the ground, the players jumps
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        if (Input.GetButtonDown("Jump") && canTempJump)
        {
            velocity.y = Mathf.Sqrt((jumpHeight/2) * -2 * tempGravity);
            canTempJump = false;
        }
        //adds a constant gravitational downforce on the player
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        
        //if horizontal input keys are used the player moves and rotates to face to point of moving.
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (Input.GetKeyDown(KeyCode.LeftControl) && dashAmount == 1)
        {
            StartCoroutine(SlideTimer());
            lockMovement = true;
            dashAmount--;
        }

        IEnumerator SlideTimer()
        {
            float elapsedTime = 0f;

            while (elapsedTime < duration && Input.GetKey(KeyCode.LeftControl))
            {
                transform.localScale = crouchScale;

                Vector3 moveDirection = transform.TransformDirection(Vector3.forward * Time.deltaTime * (speed * slideMultiplier));
                controller.Move(moveDirection);

                elapsedTime += Time.deltaTime;
                yield return null;
            }
            transform.localScale = playerScale;
            lockMovement = false;
        }

        if (direction.magnitude >= 0.1f && !lockMovement)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }
}