﻿using System.Collections;
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

    // Update is called once per frame
    void Update()
    {
        if (freezePlayer == false)
        {
            MovementInput();
            MovementDirection();
            MovePlayer();
            LookAtMouse();
            Shoot();
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
        //playerPosition.position += direction * movementSpeed;
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
        if(Input.GetMouseButtonDown(0))
            Instantiate(bullet, shotLocation.position, player.rotation);
    }

    public void TakeDamage()
    {
        health--;
        if(health <= 0)
        {
            Respawn();
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
