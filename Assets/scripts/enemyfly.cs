using UnityEngine;
using System.Collections;

public class enemyfly : Enemy {

	// Use this for initialization
	new void Start () {
        score = Random.Range(4, 17);
        health = 9f;
        speed = 100f;
        base.Start();
	}
	
	// Update is called once per frame
	new void Update () {
        base.Update();

        Vector2 direct = target.transform.position;

        float deg = Mathf.Atan2(direct.y - transform.position.y, direct.x - transform.position.x) * Mathf.Rad2Deg - 360;

        direc = Quaternion.AngleAxis(deg, Vector3.forward) * Vector3.right * 90;

        dirx = target.transform.position.x > transform.position.x ? 1 : -1;
        diry = target.transform.position.y > transform.position.y ? 1 : -1;
        rbody.AddForce(new Vector2(dirx * speed, diry * speed));

        if (rbody.velocity.magnitude > 120) {
            rbody.velocity = rbody.velocity.normalized * 120;
        }
    }
}
