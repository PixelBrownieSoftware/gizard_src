using UnityEngine;
using System.Collections;

public class characterbase : MonoBehaviour {

    public Rigidbody2D rbody;
    public float health;
    public float speed;

    protected bool canBeDestoryed;
    protected bool invincibility;

	// Use this for initialization
	public void Start () {
        rbody = GetComponent<Rigidbody2D>();
        canBeDestoryed = true;
        invincibility = false;
    }
	
	// Update is called once per frame
	public void Update () {
        if (health <= 0 && canBeDestoryed) {
            health = 0;
            Destroy(this.gameObject);
        }
	}

    public void Damage() {
        if (!invincibility) { health--; }
    }

}
