using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float Health;
    public float maxHealth;
    bool isImmune;
    public Image healthImg;
    public float ImmunityTime;
    Blinks material;
    SpriteRenderer sprite;
    public float knockbackForceX;
    public float knockbackForceY;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<Blinks>();
        Health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthImg.fillAmount = Health / 100;
        if(Health > maxHealth)
        {
            Health = maxHealth;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !isImmune)
        {
            Health -= collision.GetComponent<Enemy>().damageToGive;
            StartCoroutine(Immunity());
            if(collision.transform.position.x > transform.position.x)
            {
                rb.AddForce(new Vector2(-knockbackForceX, knockbackForceY), ForceMode2D.Force);

            }
            else
            {
                rb.AddForce(new Vector2(knockbackForceX, knockbackForceY), ForceMode2D.Force);
            }




            if(Health <= 0)
            {
                //game over
                print("Player dead");
            }
        }
    }

    IEnumerator Immunity()
    {
        isImmune = true;
        sprite.material = material.blink;
        yield return new WaitForSeconds(ImmunityTime);
        sprite.material = material.original;
        isImmune = false;
    }
}
