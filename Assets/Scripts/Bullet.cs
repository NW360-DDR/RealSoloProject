using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1f;
    public float timer = 5f; // We will count down our timers.



    // Update is called once per frame
    void Update()
    {
        if (timer < 0.0f) Destroy(gameObject); // Hey if our clock runs out we should kill ourselves. Good advice tbh.
        timer -= Time.deltaTime;
        transform.Translate(transform.up * speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
