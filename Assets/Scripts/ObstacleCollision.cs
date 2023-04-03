using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    [SerializeField] ObstacleMovement obstacleMovement;

    void OnCollisionEnter(Collision collisionInfo)
    {

        if (collisionInfo.collider.tag == "Player")
        {
            obstacleMovement.enabled = false;
        }


    }
}
