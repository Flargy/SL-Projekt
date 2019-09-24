using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private RaycastHit bulletHit;

    public LayerMask interactionLayer;
    public float travelSpeed;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BulletTravel();
        HitDetection();
    }

    private void BulletTravel()
    {
        transform.position += transform.forward * travelSpeed * Time.deltaTime;
    }

    private void HitDetection()
    {
        if(Physics.SphereCast(transform.position, 0.50f, transform.forward, out bulletHit, 0.3f, interactionLayer))
        {
            Destroy(gameObject);
            if(bulletHit.transform.tag == "Enemy")
            {
                bulletHit.transform.gameObject.GetComponent<EnemyScript>().Die();
            }
        }
    }
}
