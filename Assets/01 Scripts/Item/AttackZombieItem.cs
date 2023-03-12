using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZombieItem : MonoBehaviour
{
    [SerializeField]
    private Light attacklight;
    [SerializeField]
    InventoryCheck inventory;

    private bool infrareMode = false;
    private bool isLightGreen = false;
    private float limitTime = 3f; 

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            if(inventory != null)
            {
                int attackItemCount = inventory.GetItemCountWithTag();
                if(attackItemCount == 2)
                {
                    ToogleInfrareMode();
                }
            }
        }

        if(isLightGreen)
        {
            limitTime -= Time.deltaTime;
            if(limitTime <= 0f)
            {
                isLightGreen = false;
                attacklight.color = Color.white; 
            }
        }
    }

    void ToogleInfrareMode()
    {
        infrareMode = !infrareMode;

        if(infrareMode)
        {
            isLightGreen = true;
            limitTime = 3f; 
            attacklight.color = Color.green;
        }
        else
        {
            attacklight.color = Color.white;
        }
    }

  
}
