using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    public GameObject projectile;

    public float timeToShoot;
    public float shootCooldown;

    public bool freqShooter;
    public bool watcher;

    void Start()
    {
        shootCooldown = timeToShoot;

    }

    // Update is called once per frame
    void Update()
    {
        if (freqShooter)
        {
            shootCooldown -= Time.deltaTime;

            if (shootCooldown < 0)
            {
                Shoot();
            }
        }

        if (watcher)
        {

        }
      
    }
    public void Shoot()
    {
        GameObject cross = Instantiate(projectile, transform.position, Quaternion.identity);

        if (transform.localScale.x < 0)
        {
            cross.GetComponent<Rigidbody2D>().AddForce(new Vector2(300f, 0f), ForceMode2D.Force);
        }
        else
        {
            cross.GetComponent<Rigidbody2D>().AddForce(new Vector2(-300f, 0f), ForceMode2D.Force);
        }

        shootCooldown = timeToShoot;
    }
}
