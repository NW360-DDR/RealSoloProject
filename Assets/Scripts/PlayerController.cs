using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float slowMult;
    [SerializeField] GameObject hitbox;
    [SerializeField] GameObject playerBullet;
    [SerializeField] float fireRate = 0.2f;

    float moveX, moveY;
    bool slowmove = false;
    float timer = 0.0f;

    public float BulletSpeed = 15.0f;

    GameObject tempBullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        slowmove = (Input.GetKey(KeyCode.LeftShift));
        Vector2 moveTotal = new Vector2(moveX, moveY).normalized * (slowmove ? moveSpeed * slowMult : moveSpeed) * Time.deltaTime;
        transform.Translate(moveTotal);

        timer += Time.deltaTime;

        if (Input.GetKey(KeyCode.Z) && timer > fireRate)
        {
            tempBullet = Instantiate(playerBullet, transform.position, Quaternion.identity);
            tempBullet.transform.right = Vector2.right;
            tempBullet.GetComponent<Bullet>().speed = BulletSpeed;
            timer = 0.0f;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("TODO: Finish Implementing Lives counter.");
        }
    }
}
