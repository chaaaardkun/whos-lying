using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    public Rigidbody2D rb;
    public GameObject parent;
    public Transform child;
    public Transform inventory;
    Vector2 movement;
    public GameObject dialogbox;

    private void Start()
    {
        inventory = parent.transform.Find("Inventory");
            if (Input.GetKeyUp("f"))
        {        
            print("Hello");
        }
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    
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
        if(collision.tag == "NPC")
        {
            //Debug.Log("Yo whadup");
            //child = parent.transform.Find("Text");
            //child.gameObject.SetActive(true);
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "NPC")
        {
           // child = parent.transform.Find("Text");
           // child.gameObject.SetActive(false);
        }
    }
}
