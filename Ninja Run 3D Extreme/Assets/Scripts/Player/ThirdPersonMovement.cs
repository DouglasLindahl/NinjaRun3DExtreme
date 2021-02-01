using System.Collections;


using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    //sätter vars för controllern och kameran
    [Header("Character Controller / Camera")]
    public CharacterController controller;
    public Transform cam;

    //floats för spelarens speed, gravtitationskonstanten, jump height och sliding.
    [Header("General Stats")]
    public float speed;
    public float jumpHeight = 3;
    public float slideDuration = .5f;

    AudioSource jumpSound;
    AudioSource dashSound;

    public float speedBoostDuration = 3f;
    public float speedMultiplier = 1.5f;

    float gravity = -20f;
    float slideMultiplier = 1.7f;
    float dashAmount;

    [Header("Player/Ground")]
    public Transform playerBody;

    Color orangeColor;

    Vector3 velocity;
    Vector3 playerScale;
    private Vector3 crouchScale = new Vector3(1, 0.5f, 1);

    bool lockMovement = false;
    bool canTempJump;
    bool isGrounded;
    bool triggerPowerup = false;

    //vars för vad ground är
    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = .25f;

    public TrailRenderer playerTrail;

    float turnSmoothVelocity;
    float turnSmoothTime = 0.1f;

    float speedIncreaseWallRun = 1.5f;
    float tempGravity;
    float tempSpeed;
    float ifErrorSpeed;

    private void Awake()
    {
        jumpSound = GameObject.Find("JumpSoundFX").GetComponent<AudioSource>();
        dashSound = GameObject.Find("DashSoundFX").GetComponent<AudioSource>();
    }
    void Start()
    {
        ifErrorSpeed = speed;
        playerScale = transform.localScale;

        orangeColor = new Color(1f, 0.64f, 0f);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            tempGravity = gravity;
            canTempJump = true;
            gravity = -4;
            dashAmount = 1;
            speed *= speedIncreaseWallRun;
        }
        if (other.tag == "Ring")
        {
            tempSpeed = speed;
            speed *= speedMultiplier;
            Destroy(other.gameObject);
            triggerPowerup = true;

            playerTrail.startColor = orangeColor;
            playerTrail.endColor = Color.yellow;

            playerTrail.time = 0.7f;
            playerTrail.startWidth = 0.6f;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wall")
        {
            gravity = tempGravity;
            speed /= speedIncreaseWallRun;
            dashAmount = 1;
        }
    }
    void Update()
    {
        if (speed < ifErrorSpeed)
        {
            speed = ifErrorSpeed;
        }
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
            jumpSound.Play();
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        if (Input.GetButtonDown("Jump") && canTempJump)
        {
            jumpSound.Play();
            velocity.y = Mathf.Sqrt((jumpHeight / 1.5f) * -2 * tempGravity);
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
            dashSound.Play();
            dashAmount--;
        }
        if (triggerPowerup)
        {
            StartCoroutine(SpeedBoostTimer());
        }

        IEnumerator SlideTimer()
        {
            float elapsedTime = 0;

            while (elapsedTime < slideDuration && Input.GetKey(KeyCode.LeftControl))
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
        IEnumerator SpeedBoostTimer()
        {
            float boostDuration = 0f;

            while (boostDuration < speedBoostDuration)
            {
                boostDuration += Time.deltaTime;
                yield return null;
            }
            triggerPowerup = false;

            speed = tempSpeed;

            playerTrail.startColor = Color.white;
            playerTrail.endColor = Color.white;

            playerTrail.time = 0.5f;
            playerTrail.startWidth = 0.5f;
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