using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterDoor : MonoBehaviour
{
    public Transform player;
    public float x,y;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.transform.position = new Vector2(x,y);
    }
}