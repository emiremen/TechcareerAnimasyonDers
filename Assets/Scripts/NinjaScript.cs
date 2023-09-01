using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaScript : MonoBehaviour
{
    public float moveSpeed = 3;
    public float rotationSpeed = 5;
    public float jumpForce = 5;
    
    public bool isOnGround;

    public Animator animator;

    void Start()
    {

    }

    void Update()
    {
        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        float verticalAxis = Input.GetAxisRaw("Vertical");

        Vector3 moveVector = new Vector3(horizontalAxis, 0, verticalAxis) * moveSpeed * Time.deltaTime;

        transform.position += moveVector;


        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            if (!animator.GetBool("isJumping"))
            {
                animator.SetBool("isJumping", true);
                animator.SetBool("isWalking", false);
            }
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

        if (horizontalAxis != 0 || verticalAxis != 0)
        {
            animator.SetBool("isWalking", true);
            Quaternion lookingRotation = Quaternion.LookRotation(moveVector);
            transform.localRotation = Quaternion.Lerp(transform.rotation, lookingRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;

            animator.SetBool("isJumping", false);
        }
    }
}
