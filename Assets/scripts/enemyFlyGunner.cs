using UnityEngine;
using System.Collections;

public class enemyFlyGunner : Enemy {

    public enum enemyStates { moving, shooting };
    public enemyStates enemyActionStates;
    float deg;
    float delayBullet;

    void weapoonPoint() {
        target = GameObject.Find("player");
        Vector2 direct = target.transform.position;

        deg = Mathf.Atan2(direct.y - transform.position.y, direct.x - transform.position.x) * Mathf.Rad2Deg - 360;

        weapon.transform.rotation = Quaternion.AngleAxis(deg, new Vector3(0, 0, transform.position.z));

        direc = Quaternion.AngleAxis(deg, Vector3.forward) * Vector3.right * 90;
        dirx = target.transform.position.x > transform.position.x ? 1 : -1;
        diry = target.transform.position.y > transform.position.y ? 1 : -1;

    }
    
    new void Start () {
        score = Random.Range(9, 16);
        health = 6;
        base.Start();
        weapon = transform.Find("gun");
    }
	
	// Update is called once per frame
	new void Update () {
        gmanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (delayBullet > 0) { delayBullet = delayBullet - Time.deltaTime; }
        weapoonPoint();
        base.Update();
        rbody.AddForce(new Vector2(dirx * speed, diry * speed));
        switch (enemyActionStates)
        {
            case enemyStates.moving:

                if (Mathf.Abs(target.transform.position.x - transform.position.x) < 300 && Mathf.Abs(target.transform.position.y - transform.position.y) < 300) {
                    enemyActionStates = enemyStates.shooting;
                }

                break;

            case enemyStates.shooting:
                Shoot();
                break;
        }
    }

    public void Shoot()
    {
        if (delayBullet < 0.1) {
            Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, deg - 90));
            delayBullet = 0.2f;
        }
        enemyActionStates = enemyStates.moving;
    }
}
