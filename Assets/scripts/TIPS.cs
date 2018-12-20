using UnityEngine;
using System.Collections;

public class TIPS : Enemy {

    public string[] tips;
    public bool isactivated;
    public string selected_text;

    Collider2D hitdet;
	// Use this for initialization
	new void Start () {
        isactivated = false;
        hitdet = transform.Find("hitdet").GetComponent<BoxCollider2D>();
	}

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Bullet")) {
            isactivated = true;
            selected_text = tips[Random.Range(0, 3)];
        }
    }

    new void Update() {
        health = 1;
    }
}
