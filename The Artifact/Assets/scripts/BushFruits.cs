using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushFruits : MonoBehaviour
{
    [SerializeField] private int[] amountPerType;
    [SerializeField] private float[] respawnTime;
    private BushVisuals bushVisuals;
    private bool hasFruits;
    private float timer;

    private void Start()
    {
        bushVisuals = GetComponent<BushVisuals>();
        //Randomly initialize some bush and fruits
        if(Random.Range(0,2) == 0)
        {
            hasFruits = false;
            timer = Time.time + respawnTime[(int)bushVisuals.GetBushVarient()];
        }
        else
        {
            hasFruits = true;
            bushVisuals.ShowFruits(); 
        }
    }
    private void Update()
    {
        if(Time.time > timer)
        {
            hasFruits = true;
            bushVisuals.ShowFruits();
        }
    }
    //when enemy eats fruit
    public void EatBushFruits()
    {
        enabled = false;
        bushVisuals.SetToDry();
    }
    public int HarvestFruit()
    {
        if (hasFruits)
        {
            hasFruits = false;
            bushVisuals.HideFruits();
            timer = Time.time + respawnTime[(int)bushVisuals.GetBushVarient()];
            return amountPerType[(int)bushVisuals.GetBushVarient()];
        }
        else
        {
            return 0;
        }
    }
    public bool HasFruits()
    {
        return hasFruits;
    }
}
