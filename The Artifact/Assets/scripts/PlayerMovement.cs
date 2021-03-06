using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 3f;
    private Rigidbody2D rb;
    private Vector2 moveVector;
    private SpriteRenderer sR;
    private float harvestTimer;
    private bool isHarvesting;
    private GameObject artifact;
    // Start is called before the first frame update
    void Awake()
    {
        artifact = GameObject.FindWithTag("Artifact");
        rb = GetComponent<Rigidbody2D>();
        sR = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(Time.time > harvestTimer) { isHarvesting = false; }
        flipSprite();
    }
    void FixedUpdate()
    {
        if (!artifact)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        if (isHarvesting)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            moveVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if(moveVector.sqrMagnitude > 1)
            {
                moveVector = moveVector.normalized;
            }
            rb.velocity = new Vector2(moveVector.x * movementSpeed, moveVector.y * movementSpeed);
        }
        
    }
    void flipSprite()
    {
        if(Input.GetAxisRaw("Horizontal") == 1)
        {
            sR.flipX = false;
        }
        else if(Input.GetAxisRaw("Horizontal") == -1)
        {
            sR.flipX = true;
        }
    }
    
    public void HarvestStopMovement(float time)
    {
        isHarvesting = true;
        harvestTimer = Time.time + time;
    }

    public bool IsHarvesting()
    {
        return isHarvesting;
    }
}
