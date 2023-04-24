using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DisableCollision : MonoBehaviour
{
    public GameObject otherObject;

    private void Start()
    {
        // Ignorer les collisions entre ce collider et celui de l'autre objet.
        Physics.IgnoreCollision(GetComponent<Collider>(), otherObject.GetComponent<Collider>());
    }
}