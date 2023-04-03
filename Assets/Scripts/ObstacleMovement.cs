using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float forwardForce = -800f;

    void FixedUpdate()
    {
        rb.AddForce(new Vector3(0, 0, forwardForce * Time.deltaTime));
    }
}
