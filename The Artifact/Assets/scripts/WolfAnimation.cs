using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAnimation : MonoBehaviour
{
    [SerializeField]private Sprite[] wolfAnimSprites;
    [SerializeField]private float animThreshold= 0.15f;
    private SpriteRenderer sR;
    private int state = 0;
    private float animTimer;
    private WolfAi wolfAI;

    private void Awake()
    {
        wolfAI = GetComponent<WolfAi>();
        sR = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (wolfAI.isMoving)
        {
            if (Time.time > animTimer)
            {
                sR.sprite = wolfAnimSprites[state];
                state++;
                if (state >= wolfAnimSprites.Length) { state = 0; }
                animTimer = Time.time + animThreshold;
            }
        }
        else
        {
            sR.sprite = wolfAnimSprites[0];
        }
        sR.flipX = wolfAI.left;
        
    }














}
