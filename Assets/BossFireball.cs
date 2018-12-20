using UnityEngine;
using System.Collections;

public class BossFireball : Bullet {

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && col.gameObject != this.transform.parent)
        {
            col.GetComponent<characterbase>().Damage();
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    new void Update () {
        base.Update();
	}
}
