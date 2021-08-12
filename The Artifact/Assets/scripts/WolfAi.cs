using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAi : MonoBehaviour
{
    [SerializeField] bool isEater;
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] int attackDamage = 5;
    [SerializeField] float attackTimeThreshold = 1f;
    [SerializeField] float eatTimeThreshold = 2f;
    [SerializeField] LayerMask bushMask;
    private Artifact artifact;
    private BushFruits bushFruitsTarget;
    private float attackTimer;
    private float eatTimer;
    private bool killingBush;
    private bool isAttacking;
    [HideInInspector] public bool isMoving, left;

    private void Start()
    {
        if (isEater)
        {
            SearchForTarget();
            killingBush = false;
        }
        else
        {
            isAttacking = false;
        }
        artifact = GameObject.FindWithTag("Artifact").GetComponent<Artifact>();
    }

    private void Update()
    {
        if (!artifact)
        {
            return;
        }
        if (isEater) //if wolf is a bush eater
        {
            if (bushFruitsTarget && bushFruitsTarget.enabled && bushFruitsTarget.HasFruits() && !killingBush)
            {
                if (Vector2.Distance(transform.position, bushFruitsTarget.transform.position) > 0.5f)
                {
                    isMoving = true;
                    float step = moveSpeed * Time.deltaTime;
                    transform.position =  Vector2.MoveTowards(transform.position, bushFruitsTarget.transform.position, step);
                }
                else
                {
                    isMoving = false;
                    bushFruitsTarget.HarvestFruit();
                    eatTimer = Time.time + eatTimeThreshold;
                    killingBush = true;
                }
            }
            else if (killingBush)
            {
                if (Time.time > eatTimer)
                {
                    bushFruitsTarget.EatBushFruits();
                    killingBush = false;
                    SearchForTarget();
                }
            }
            else
            {
                SearchForTarget();
            }
            if (bushFruitsTarget)
            {
                if (bushFruitsTarget.transform.position.x < transform.position.x)
                {
                    left = true;
                }
                else
                {
                    left = false;
                }
            }
            if (!bushFruitsTarget)
            {
                SearchForTarget();
            }
        }
        else //if wolf is a artifact eater
        {
            if (Vector2.Distance(transform.position, artifact.transform.position) > 1.5f)
            {
                float step = moveSpeed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, artifact.transform.position, step);
                isMoving = true;
            }
            else if (!isAttacking)
            {
                isAttacking = true;
                attackTimer = Time.time + attackTimeThreshold;
                isMoving = false;
            }
            if (isAttacking)
            {
                if(Time.time > attackTimer)
                {
                    Attack();
                    attackTimer = Time.time + attackTimeThreshold;
                }
            }
            if(artifact.transform.position.x < transform.position.x)
            {
                left = true;
            }
            else
            {
                left = false;
            }

        }
        
    }

    void SearchForTarget()
    {
        bushFruitsTarget = null;
        Collider2D[] hits;
        for(int i= 1; i< 50; i++)
        {
            hits = Physics2D.OverlapCircleAll(transform.position, Mathf.Exp(i), bushMask);

            foreach(Collider2D hit in hits)
            {
                if(hit && hit.GetComponent<BushFruits>().HasFruits() && hit.GetComponent<BushFruits>().enabled)
                {
                    bushFruitsTarget = hit.GetComponent<BushFruits>();
                    break;
                }
            }
            if (bushFruitsTarget)
            {
                break;
            }
        }
    }
    void Attack()
    {
        artifact.TakeDamage(attackDamage);
    }
}

