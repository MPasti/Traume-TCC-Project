using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCdialog : MonoBehaviour
{
    public Sprite profile;
    public string[] speechTxt;
    public string actorName;

    public LayerMask playerLayer;
    public float radious;

    private DialogControl dc;
    bool onRadious;

    private void Start()
    {
        dc = FindObjectOfType<DialogControl>();
    }
    private void FixedUpdate()
    {
        Interact();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&& onRadious)
        {
            dc.Speech(profile, speechTxt, actorName);
        }
        if (Input.GetKeyDown(KeyCode.R) && onRadious)
        {
            dc.dialogueObj.SetActive(false);
        }
    }

    public void Interact()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radious, playerLayer);

        if(hit != null)
        {
            onRadious = true;
        }
        else
        {
            onRadious = false;  
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radious);
    }
}
