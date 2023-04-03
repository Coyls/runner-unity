using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    
    void Update()
    {

        if(transform.position.y < 0.95) {
            Destroy(gameObject);
        }
        
    }
}
