using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBehavior : MonoBehaviour
{
    public Transform[] transforms;
    public GameObject flame;

    public float timeToShoot, countdown;
    public float timeToTP, countdownToTP;

    public float bossHealth, currentHealth;
    public Image healthImg;
    private void Start()
    {
        var initialPosition = Random.Range(0, transforms.Length);
        transform.position = transforms[initialPosition].position;
        countdown = timeToShoot;
        countdownToTP = timeToTP;
    }

    private void Update()
    {

        Countdowns();
        DamageBoss();
        BossScale();
    }

    public void Countdowns()
    {
        countdown -= Time.deltaTime;
        countdownToTP -= Time.deltaTime;
        if (countdown <= 0f)
        {
            ShootPlayer();
            countdown = timeToShoot;

        }

        if (countdownToTP <= 0f)
        {
            countdownToTP = timeToTP;
            Teleport();

        }
    }

    public void ShootPlayer()
    {
        
            GameObject spell = Instantiate(flame, transform.position, Quaternion.identity);
        
    }
    public void Teleport()
    {
        var initialPosition = Random.Range(0, transforms.Length);
        transform.position = transforms[initialPosition].position;
    }
   
    public void DamageBoss()
    {
        currentHealth = GetComponent<Enemy>().healthPoints;
        healthImg.fillAmount = currentHealth / bossHealth;
    }
    private void OnDestroy()
    {
        BossUI.instance.BossDesactivator();
    }
    public void BossScale()
    {
        if(transform.position.x > PlayerController.instance.transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
