using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemCollecter : MonoBehaviour
{
    public abstract void Use(GameObject target);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Use(other.gameObject);
        }
    }
}