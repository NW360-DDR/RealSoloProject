using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public enum BulletType { Straight, Spin, Random }
    [Header("Bullet Attributes")]
    public GameObject bullet;
    public float bulletTimer = 5f;
    public float speed = 1f;

    [Header("Spawner Attributes")]
    [SerializeField] public BulletType bulletType;
    [SerializeField] public float FireRate = 0.8f;
    [SerializeField] public bool targetPlayer = false;

    private GameObject Spawned;
    private float timer = 0f;

    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Hitbox");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        // Unless we're shitting bullets in a straight line we probably want to do this.
        if (targetPlayer)
            transform.up = (player.transform.position - transform.position) * -1;
        else if (bulletType == BulletType.Spin) 
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + 1f);
        else if (bulletType == BulletType.Random) 
            transform.eulerAngles = new Vector3(0, 0, Random.Range(0.0f, 360.0f));
        
        if (timer > FireRate)
        {
            Fire();
            timer = 0;
        }
    }

    private void Fire()
    {
        if (bullet)
        {
            Spawned = Instantiate(bullet, transform.position, Quaternion.identity);
            Spawned.GetComponent<Bullet>().speed= speed;
            Spawned.GetComponent<Bullet>().timer = bulletTimer;
            if (targetPlayer)
            {
                Vector2 v = player.transform.position - transform.position;
                float a = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
                Spawned.transform.eulerAngles = new Vector3(0, 0, a);
            }
        }
    }
}
