using UnityEngine;
using System.Collections;

public class enemyattack : Bullet {

    // Use this for initialization
    void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Player") )
        {
            col.GetComponent<Player>().SFX.hurt.Play();
            col.GetComponent<Player>().Damage();
        }
    }

    new void Update() {
        delay = 3f;
    }
}
