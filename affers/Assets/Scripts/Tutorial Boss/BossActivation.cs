using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivation : MonoBehaviour
{

    public GameObject bossGO;

    private void Start()
    {
        bossGO.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            bossGO.SetActive(true);
            BossUI.instance.BossActivator();
            StartCoroutine(waiting());


        }
    }

    IEnumerator waiting()
    {
       
        var currentSpeed = PlayerController.instance.speed;
        PlayerController.instance.speed = 0;
        bossGO.SetActive(true);
        yield return new WaitForSeconds(3);
        PlayerController.instance.speed = currentSpeed;
        Destroy(gameObject);

    }

}
