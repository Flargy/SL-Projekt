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
    private float newXDistance;
    private float newZDistance;
    private float lerpedXDistance;
    private float lerpedZDistance;
    private Vector3 lerpVector;

    void Update()
    {
        if (lerping)
        {
            transform.rotation = Quaternion.Lerp(oldRotation, newRotation, 0.2f * Time.time);
            lerpedXDistance = Mathf.Lerp(xDistanceFromPlayer, newXDistance, 0.2f * Time.time);
            lerpedZDistance = Mathf.Lerp(zDistanceFromPlayer, newZDistance, 0.2f * Time.time);
            lerpVector = new Vector3(player.transform.position.x - lerpedXDistance, (player.transform.position.y + heightOffset), player.transform.position.z - lerpedZDistance);
            transform.position = lerpVector;
            Debug.Log(lerpedZDistance);
            Debug.Log(lerpedXDistance);
            if (transform.rotation == newRotation)
            {
                Debug.Log(lerpVector);
                Debug.Log(newXDistance);
                Debug.Log(newZDistance);
                zDistanceFromPlayer = newZDistance;
                xDistanceFromPlayer = newXDistance;
                lerping = false;

            }
        }
        else if(lerping == false)
        {
            transform.position = new Vector3((player.transform.position.x - xDistanceFromPlayer), (player.transform.position.y + heightOffset), (player.transform.position.z - zDistanceFromPlayer));

        }
    }

    public void ChangeCamera(float rotation, float xDistance, float zDistance)
    {
        lerping = true;
        newRotation = Quaternion.Euler(xRotation, rotation, 0);
        oldRotation = transform.rotation;
        //transform.rotation = Quaternion.Euler(xRotation, rotation, 0);
        newZDistance = zDistance;
        newXDistance = xDistance;
        lerpedXDistance = xDistanceFromPlayer;
        lerpedZDistance = zDistanceFromPlayer;
    }

    

}
