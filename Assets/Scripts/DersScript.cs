using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DersScript : MonoBehaviour
{
    public float moveSpeed = 3;
    public float jumpForce = 5;
    public bool isOnGround = false;

    public Camera[] cameras;

    void Update()
    {
        float yatayHareket = Input.GetAxis("Horizontal");
        float dikeyHareket = Input.GetAxis("Vertical");

        Vector3 hareketVektoru = new Vector3(yatayHareket, 0, dikeyHareket) * moveSpeed * Time.deltaTime;

        transform.Translate(hareketVektoru);

        if (Input.GetKeyDown(KeyCode.Space) && !isOnGround)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

        for (int i = 0; i < cameras.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                cameras[i].enabled = true;
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

}