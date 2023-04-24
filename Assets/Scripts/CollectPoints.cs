using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPoints : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {

        if (!other.CompareTag("Ground"))
        {
            // L'objet est entré en collision avec un obstacle. Ignorer la collision.
            // Physics.IgnoreCollision(other, GetComponent<Collider>());
        }


    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            // Ajouter un point au joueur ou faire toute autre action que vous voulez.
            // Ici, nous détruisons simplement l'objet point collectable.
            Destroy(gameObject);
        }
    }
}
