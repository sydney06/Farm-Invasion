using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyThirdPersonCharacterController : MonoBehaviour
{
    private Animator playerAnim;
    private Rigidbody playerRb;


    public bool isOnGround = true;
    public float runningSpeed = 15;
    public float walkingSpeed = 10;
    public float gravityModifier;
    public float jumpForce;


    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    void FixedUpdate()
    {
        // Jump
        if (Input.GetKey(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
        }

        PlayerMovement();
    }

    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");


        // Sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Vector3 playerMovement = new Vector3(hor, 0f, ver) * runningSpeed * Time.deltaTime;
            transform.Translate(playerMovement, Space.Self);
            playerAnim.Play("Run");
        }

        // Walk
        else
        {
            Vector3 playerMovement = new Vector3(hor, 0f, ver) * walkingSpeed * Time.deltaTime;
            transform.Translate(playerMovement, Space.Self);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            Debug.Log("I'm on ground");
        }

        else if (collision.gameObject.CompareTag("Destroy"))
        {
            return;
        }
    }
}
