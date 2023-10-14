using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject basicProjectilePrefab;

    [SerializeField] private float attackCooldown = 0.5f;

    [SerializeField] private float projectileSpeed = 10f;

    //[SerializeField] private float projectileDestroyTime = 100f;

    [SerializeField] private Transform projectileSpawnPoint;


    private PlayerMovement playerMovement;

    private float currentAttackCooldown;


    void Start() {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        currentAttackCooldown -= Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && currentAttackCooldown <= 0) {
            currentAttackCooldown = attackCooldown;
            
            GameObject projObj = Instantiate(basicProjectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
            Rigidbody2D projRb = projObj.GetComponent<Rigidbody2D>();
            projRb.position = projectileSpawnPoint.position;
            projRb.velocity = playerMovement.facing * projectileSpeed;

            Projectile proj = projObj.GetComponent<Projectile>();
        }
    }
}
