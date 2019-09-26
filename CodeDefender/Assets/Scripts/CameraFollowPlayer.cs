using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject player;

    [SerializeField] private float zDistanceFromPlayer = 5f;
    [SerializeField] private float heightOffset = 12.5f;
    [SerializeField] private float xDistanceFromPlayer = 0;
    [SerializeField] private float xRotation;

    private bool lerping = false;
    private Quaternion oldRotation;
    private Quaternion newRotation;

    void Update()
    {
        transform.position = new Vector3((player.transform.position.x - xDistanceFromPlayer), (player.transform.position.y + heightOffset), (player.transform.position.z - zDistanceFromPlayer));
        if (lerping)
        {
            transform.rotation = Quaternion.Lerp(oldRotation, newRotation, 0.2f * Time.time);
            Debug.Log(oldRotation + "  " + newRotation);
            if (transform.rotation == newRotation)
            {
                lerping = false;
            }
        }
    }

    public void ChangeCamera(float rotation, float xDistance, float zDistance)
    {
        lerping = true;
        newRotation = Quaternion.Euler(xRotation, rotation, 0);
        oldRotation = transform.rotation;
        //transform.rotation = Quaternion.Euler(xRotation, rotation, 0);
        zDistanceFromPlayer = zDistance;
        xDistanceFromPlayer = xDistance;
    }

    

}
