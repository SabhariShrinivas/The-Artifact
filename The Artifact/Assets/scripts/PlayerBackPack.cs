using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBackPack : MonoBehaviour
{
    public int maxNumberOfFruits = 50;
    public int currentNumberOfFruits;
   
    public void AddFruits(int amount)
    {
        currentNumberOfFruits += amount;
        if(currentNumberOfFruits > maxNumberOfFruits)
        {
            currentNumberOfFruits = maxNumberOfFruits;
        }
    }

    public int TakeFruit()
    {
        int takenFruits = currentNumberOfFruits;
        currentNumberOfFruits = 0;
        return takenFruits; 
    }
}
