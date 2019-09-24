using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject player;

    private float distanceFromPlayer = 5f;
    private float heightOffset = 12.5f;

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, (player.transform.position.y + heightOffset), (player.transform.position.z - distanceFromPlayer));
    }
}
