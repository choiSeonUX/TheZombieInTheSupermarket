using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaItem : MonoBehaviour
{
    [SerializeField]
    private int staminaAmount;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Stamina playerStamina = other.GetComponent<Stamina>();
            if (playerStamina != null)
            {
                playerStamina.GetPlusCurrentSP(staminaAmount);
                Destroy(gameObject);
            }
        }
    }
}
