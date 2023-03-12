using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StaminaItem : ItemCollecter
{
    [SerializeField]
    private Stamina stamina; 
    [SerializeField]
    private int staminaAmount = 50;
    [SerializeField]
    private Item item;

    public override void Use(GameObject target)
    {
        stamina = target.GetComponent<Stamina>(); 
        if (stamina != null)
        {
                stamina.IncreaseSP(staminaAmount);
                gameObject.SetActive(false); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Stamina_Item"))
        {
            Use(other.transform.gameObject); 
        }
    }


}