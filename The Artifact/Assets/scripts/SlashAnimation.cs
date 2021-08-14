using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAnimation : MonoBehaviour
{
    [SerializeField] private Sprite[] slashSprites;
    [SerializeField] private float timeThreshold = 0.06f;
    [SerializeField] private int damage =5;
    private float timer;
    private int state = 0;
    private SpriteRenderer sR;

    private void Awake()
    {
        sR = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(Time.time > timer)
        {
            if (state >= slashSprites.Length)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                sR.sprite = slashSprites[state];
                state++;
                timer = Time.time + timeThreshold;
            }
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wolf"))
        {
            collision.GetComponent<WolfHealth>().TakeDamage(damage);
        }
    }
}
