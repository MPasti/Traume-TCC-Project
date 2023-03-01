using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private DialogueUI dialogueUI;

    public DialogueUI DialogueUI => dialogueUI;

    public IInteractible Interactible { get; set; }

    private Rigidbody2D rb;

    private void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (dialogueUI.IsOpen) return;
        if (Input.GetKeyDown(KeyCode.E))
        {

            Interactible?.Interact(this);

        }
    }
}
