using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlash : MonoBehaviour
{
    [SerializeField] private GameObject slashPrefab;
    [SerializeField] private float attackCooldown;
    private float attackTimer;
    private AudioSource audioSource;
    private Camera cam;
    private Vector3 spawnPosition;
    private GameObject artifact;
    private void Awake()
    {
        artifact = GameObject.FindWithTag("Artifact");
        audioSource = GetComponent<AudioSource>();
        cam = Camera.main;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && Time.time > attackTimer)
        {
            Slash();
            attackTimer = Time.time + attackCooldown;
        }
    }
    void Slash()
    {
        if (!artifact)
        {
            return;
        }
        audioSource.Play();
        spawnPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        spawnPosition.z = 0;
        Instantiate(slashPrefab, spawnPosition, Quaternion.identity);
    }
}
