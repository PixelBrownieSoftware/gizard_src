using UnityEngine;
using System.Collections;

public class enemybullet : Bullet {

	// Use this for initialization
	void Start () {
        speed = 40f;
	}
    void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Player") && col.gameObject != this.transform.parent) {
            col.GetComponent<Player>().Damage();
            col.GetComponent<Player>().SFX.hurt.Play() ;
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    new void Update () {
        base.Update();
	}
}
