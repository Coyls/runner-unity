using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] Rigidbody rb;
    [SerializeField] float sidewaysForce = 300f;
    [SerializeField] float jump = 300f;

    bool isOnGround = false;


    void FixedUpdate()
    {
        if (Input.GetKey("d"))
        {
            rb.AddForce(new Vector3(sidewaysForce * Time.deltaTime, 0, 0), ForceMode.VelocityChange);
        }
        if (Input.GetKey("q"))
        {
            rb.AddForce(new Vector3(-sidewaysForce * Time.deltaTime, 0, 0), ForceMode.VelocityChange);
        }
        if (Input.GetKey("space"))
        {

            if (isOnGround)
            {

                rb.AddForce(new Vector3(0, jump * Time.deltaTime, 0), ForceMode.Impulse);
            }
        }

        if (rb.position.y < -2f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }
}
