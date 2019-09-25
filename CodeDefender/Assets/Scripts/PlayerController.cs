using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float verticalDirection;
    private float horizontalDirection;
    private Vector3 direction;
    private Vector3 pointUp;
    private Vector3 pointDown;
    private Vector3 mousePosition;
    private Transform player;
    private Vector3 respawnPosition;
    private CapsuleCollider CapsuleCollider;
    private Rigidbody rb;
    private RaycastHit groundHit;
    private Ray cameraRay;
    private int health = 5;
    private float shotDelay;
    private float takeDamageDelay;

    public LayerMask layer;
    public float movementSpeed;
    public GameObject bullet;
    public Transform shotLocation;
    public bool freezePlayer = false;

    void Start()
    {
        player = transform;
        respawnPosition = player.position;

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (freezePlayer == false)
        {
            MovementInput();
            MovementDirection();
            MovePlayer();
            LookAtMouse();
            Shoot();
            if(takeDamageDelay >= 0 && takeDamageDelay <= 0.5f)
            {
                takeDamageDelay += Time.deltaTime;
            }
        }
    }

    private void MovementInput()
    {
        verticalDirection = Input.GetAxisRaw("Vertical");
        horizontalDirection = Input.GetAxisRaw("Horizontal");
    }

    private void MovementDirection()
    {
        direction = new Vector3(horizontalDirection, 0, verticalDirection) * movementSpeed;
    }

    private void MovePlayer()
    {
        rb.velocity = direction;
    }

    private void LookAtMouse()
    {
        cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(cameraRay, out groundHit, Mathf.Infinity, layer))
        {
            mousePosition = new Vector3(groundHit.point.x, player.position.y, groundHit.point.z);
            player.LookAt(mousePosition);
        }
    }



    private void Shoot()
    {
        if (Input.GetMouseButton(0) && shotDelay >= 0.45f)
        {
            Instantiate(bullet, shotLocation.position, player.rotation);
            shotDelay = 0.0f;
        }
        if (shotDelay >= 0.0f || shotDelay <= 1.0f)
            shotDelay += Time.deltaTime;
        else
            shotDelay = 0.0f;
        
    }

    public void TakeDamage()
    {
        if (takeDamageDelay >= 0.5f)
        {
            takeDamageDelay = 0.0f;
            health--;
            if (health <= 0)
            {
                Respawn();
            }
        }
    }

    private void Respawn()
    {
        player.position = respawnPosition;
        health = 5;
    }

    public void FreezePlayer()
    {
        freezePlayer = true;
        rb.velocity = Vector3.zero;
    }
    
}
