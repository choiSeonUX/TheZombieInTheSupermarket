using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    [SerializeField]
    private float sp;
    public float currentSp { get; set; }

    [SerializeField]
    private float spIncreaseSpeed;

    [SerializeField]
    private float spRechargeTime;
    private int currentSpRechargeTime;

    private bool spUsed;

    [SerializeField]
    private Image[] images_Gauge;

    private const int SP = 0; 

    private void Start()
    {
        currentSp = sp; 
    }

    private void Update()
    {
        SPRechargeTime();
        SPRecover();
        GaugeUpdate();
    }

    private void SPRechargeTime()
    {
        if (spUsed && currentSpRechargeTime < spRechargeTime)
            currentSpRechargeTime++;
        else if (spUsed)
            spUsed = false;
    }

    private void SPRecover()
    {
        if (!spUsed && currentSp < sp)
        {
            currentSp += spIncreaseSpeed;
        }
    }
    public void IncreaseSP(int Amount)
    {
        if (currentSp < sp)
        {
            currentSp += Amount;
        }
        else if (currentSp > sp)
        {
            currentSp = sp;
        }
    }

    private void GaugeUpdate()
    { 
        images_Gauge[SP].fillAmount = (float)currentSp / sp;    
    }

    public void DecreaseStamina(int count)
    {
        spUsed = true;
        currentSpRechargeTime = 0;

        if (currentSp - count > 0)
            currentSp -= count;
        else
            currentSp = 0;
    }
}
