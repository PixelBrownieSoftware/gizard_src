using UnityEngine;
using System.Collections;

public class Enemy : characterbase {

    public Transform weapon;
    protected int diry;
    protected int dirx;
    protected GameObject target;
    protected Vector2 direc;

    public sound sfx;

    public GameObject bullet;
    public GameManager gmanager;
    protected int score;
    // Use this for initialization
    public new void Start () {

        speed = 75f;
        base.Start();
    }
	
	// Update is called once per frame
	public new void Update () {
        if (gmanager == null) { gmanager = GameObject.Find("GameManager").GetComponent<GameManager>(); }
        sfx = GameObject.Find("sound").GetComponent<sound>();
        target = GameObject.Find("player");
        base.Update();
        if (health == 0) {
            gmanager.score += score;
        }
    }

    public void reBound() {
        rbody.AddRelativeForce(-direc * 40 * 3);
    }

}
