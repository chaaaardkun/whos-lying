using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    public Animator anim;

    public Rigidbody2D rb;
    public GameObject parent;
    public Transform child;
    public Transform inventory;
    Vector2 movement;
    public GameObject dialogbox;
    public GameObject gamemanager;
    public GameObject dialoguemanager;

    private void Start()
    {
        inventory = parent.transform.Find("Inventory");
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKeyUp("e"))
        {
            if(inventory.gameObject.activeSelf == false)
            inventory.gameObject.SetActive(true);
            else
            inventory.gameObject.SetActive(false);
        }
        if(dialogbox.activeSelf == false)
        {
            speed = 5f;
        }
        else{
            speed = 0f;
        }
        
     
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "NPC" || collision.tag == "DialogueTrigger")
        {
            dialoguemanager.GetComponent<DialogueManagerNew>().npc = collision.gameObject;
            
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        gamemanager.GetComponent<GameManager>().stay = true;
    }

   

    private void OnTriggerExit2D(Collider2D collision)
    {
        gamemanager.GetComponent<GameManager>().stay = false;
    }
}
