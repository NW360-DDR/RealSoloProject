using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float HP = 1000;
    float startingHP;
    public BulletSpawner[] Spawners;

    public Slider HPBar;
    // Start is called before the first frame update
    void Start()
    {
        startingHP = HP;
        
    }

    // Update is called once per frame
    void Update()
    {
        // If we hit certain thresholds, we should change phases


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            HP -= 1;
            Destroy(other.gameObject);
            HPBar.value = HP;
            if (HP <= 0)
            {
                Destroy(this.gameObject);
            }

        }
    }

    private void PhaseChange(int phase)
    {
        switch (phase)
        {
            case 0:
                Spawners[0].bulletType = BulletSpawner.BulletType.Straight;
                Spawners[0].FireRate = 0.2f;
                Spawners[0].targetPlayer = true;
                break;
        }
    }
}
