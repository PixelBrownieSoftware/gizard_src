using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    protected float delay = 1f;
    protected float speed = 55f;

    public Rigidbody2D rbody2d;
    GameObject weapon;
    public GameObject parent;
    float delayBullet;

    void Start() {
    }

    // Use this for initialization
    void OnTriggerEnter2D (Collider2D col) {
        if (col.CompareTag("Enemy")) {
            col.GetComponent<characterbase>().Damage();
            col.GetComponent<Enemy>().sfx.hurtenemy.Play();
            Destroy(this.gameObject);
        }
	}
	
	// Update is called once per frame
	public void Update () {
        if (delay> 0) delay = delay - Time.deltaTime; 

        if (delay < 0.1) Destroy(this.gameObject);

    }
}
