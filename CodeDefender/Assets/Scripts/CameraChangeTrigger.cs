using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeTrigger : MonoBehaviour
{
    [SerializeField] private float yRotation;
    [SerializeField] private float xDistance;
    [SerializeField] private float zDistance;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("colliding with camera script");
        if (other.CompareTag("Player"))
        {
            Camera.main.GetComponent<CameraFollowPlayer>().ChangeCamera(yRotation, xDistance, zDistance);
        }
    }
}
