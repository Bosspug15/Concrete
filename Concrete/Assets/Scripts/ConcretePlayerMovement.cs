using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcretePlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    [SerializeField] public float speed = 12f;
    [SerializeField] public float jumpHeight = 3f;
    public float gravity = -9.81f;
    public AudioSource footstepsSound;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded) 
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        /*
        if (!isGrounded)
        {
            footstepsSound.enabled = false;
        }
        */

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && isGrounded)
        {
            footstepsSound.enabled = true;
        }
        else {

            footstepsSound.enabled = false;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
