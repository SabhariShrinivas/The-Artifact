using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushVisual : MonoBehaviour
{
    [SerializeField] private Sprite[] bushSprites, fruitSprites, drySprites;
    [SerializeField] private SpriteRenderer[] fruitRenderer;
    public enum BushVarient { Green, Cyan, Yellow}
    public BushVarient bushVarient;
    public float hideTimePerFruit = 0.3f;
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        bushVarient = (BushVarient)Random.Range(0, bushSprites.Length);
        sr.sprite = bushSprites[(int)bushVarient];

        for(int i = 0; i < fruitSprites.Length; i++)
        {
            fruitRenderer[i].sprite = fruitSprites[(int)bushVarient];  
        }
    }  
}
