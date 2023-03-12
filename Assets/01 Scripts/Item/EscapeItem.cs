using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeItem : ItemCollecter
{
    [SerializeField]
    private Item item; 
    public override void Use(GameObject target)
    {
        InventoryCheck inventory = target.GetComponent<InventoryCheck>();

        if (inventory != null)
        {        
                inventory.AcquireItem(item);
            
        }
    }
}