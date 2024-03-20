using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1f;
    public float timer = 5f; // We will count down our timers.
    public Vector2 moveDir;
    public string Move;
    GameObject hitbox;
    private void Start()
    {
         SetMode(Move);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 0.0f) Destroy(gameObject); // Hey if our clock runs out we should kill ourselves. Good advice tbh.
        timer -= Time.deltaTime;
        transform.Translate(moveDir * speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    public void SetMode(string yee)// If we want to go towards the player, Run this.
    {
        hitbox = GameObject.Find("Hitbox");
        Move = yee;
        switch (Move)
        {
            case "Track":
                moveDir = hitbox.transform.position - transform.position;
                moveDir = moveDir.normalized;
                break;
            case "Player":
                moveDir = transform.up;
                break;
            default:
                moveDir = transform.up * -1;
                break;
        }
    }
}
