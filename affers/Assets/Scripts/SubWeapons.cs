using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubWeapons : MonoBehaviour
{

    public int ArrowCost;

    public GameObject arrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        useSubWeapons();
    }
    public void useSubWeapons()
    {
        if (Input.GetButtonDown("Fire2") && ArrowCost <= Arrow.Instance.ArrowAmount)
        {
            Arrow.Instance.SubItems(-ArrowCost);
            AudioManager.instance.PlayAudio(AudioManager.instance.arrow);
            GameObject subItem = Instantiate(arrow, transform.position, Quaternion.identity);
            

            if(transform.localScale.x < 0)
            {
                subItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(-800f, 0), ForceMode2D.Force);
                subItem.transform.localScale = new Vector2(-1, 1);
            }
            else
            {
                subItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(800f, 0), ForceMode2D.Force);
            }

            
        }
    }
}
