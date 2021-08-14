using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBackPack : MonoBehaviour
{
    public int maxNumberOfFruits = 50;
    public int currentNumberOfFruits;
    [SerializeField] Text backpackInfo;

    private void Start()
    {
        SetBackpackInfoText(0);
    }
    public void AddFruits(int amount)
    {
        currentNumberOfFruits += amount;
        if(currentNumberOfFruits > maxNumberOfFruits)
        {
            currentNumberOfFruits = maxNumberOfFruits;
        }
        SetBackpackInfoText(currentNumberOfFruits);
    }

    public int TakeFruit()
    {
        int takenFruits = currentNumberOfFruits;
        currentNumberOfFruits = 0;
        SetBackpackInfoText(currentNumberOfFruits);
        return takenFruits; 
    }

    void SetBackpackInfoText(int amount)
    {
        backpackInfo.text = "Backpack :" + amount + "/" + maxNumberOfFruits;
    }
}
