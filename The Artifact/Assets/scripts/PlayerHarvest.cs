using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHarvest : MonoBehaviour
{
    [SerializeField] float harvestTime = 1f;
    private PlayerBackPack playerBackPack;
    private PlayerMovement playerMovement;
    private BushFruits hitBush;
    private Collider2D collidedBush;
    private AudioSource audioSource;
    private bool canHarvestFruits;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerBackPack = GetComponent<PlayerBackPack>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E))
        {
            TryHarvestFruit();
        }
    }

    public void TryHarvestFruit()
    {
        if (!canHarvestFruits)
            return;
        if(collidedBush != null)
        {
            hitBush = collidedBush.GetComponent<BushFruits>();
            if (hitBush.HasFruits())
            {
                audioSource.Play();
                playerMovement.HarvestStopMovement(harvestTime);
                playerBackPack.AddFruits(hitBush.HarvestFruit());

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bush"))
        {
            canHarvestFruits = true;
            collidedBush = collision;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Bush"))
        {
            canHarvestFruits = false;
            collidedBush = null;
        }
    }
}
