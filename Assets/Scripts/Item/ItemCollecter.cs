using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemCollecter : MonoBehaviour
{
    public abstract void Use(GameObject target);
    protected virtual void OnItemCollect(Collider other)
    {
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnItemCollect(other);
        }
    }
}