using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    Vector3 playerPos;
    [SerializeField] private GameObject player;
    [SerializeField] float minX, maxX, minY, maxY;
    
    private void LateUpdate()
    {
        playerPos = player.transform.position;
        if(playerPos.x < minX)
        {
            playerPos.x = minX;
        }
        if(playerPos.x > maxX)
        {
            playerPos.x = maxX;
        }
        if(playerPos.y < minY)
        {
            playerPos.y = minY;
        }
        if(playerPos.y > maxY)
        {
            playerPos.y = maxY;
        }

        transform.position = new Vector3(playerPos.x, playerPos.y, transform.position.z);
    }
}
