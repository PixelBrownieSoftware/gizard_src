using UnityEngine;
using System.Collections;

public class EnemyGunner : Enemy {

    public enum enemyStates { moving, shooting };
    public enemyStates enemyActionStates;
    float deg;
    float delayBullet;

    // Use this for initialization
    new void Start () {
        score = Random.Range(3, 11);
        health = 4f;
        base.Start();
        weapon = transform.Find("gun");
    }

    void weapoonPoint() {
        Vector2 direct = target.transform.position;

        deg = Mathf.Atan2(direct.y - transform.position.y, direct.x - transform.position.x) * Mathf.Rad2Deg - 360;

        weapon.transform.rotation = Quaternion.AngleAxis(deg, new Vector3(0, 0, transform.position.z));

        direc = Quaternion.AngleAxis(deg, Vector3.forward) * Vector3.right * 90;
        dirx = target.transform.position.x > transform.position.x ? 1 : -1;

    }

	// Update is called once per frame
	new void Update () {
        base.Update();
        
        if (delayBullet > 0) { delayBullet = delayBullet - Time.deltaTime; }
        weapoonPoint();

        switch (enemyActionStates) {
            case enemyStates.moving:

                if (Mathf.Abs(target.transform.position.x - transform.position.x) < 300 && Mathf.Abs(target.transform.position.y - transform.position.y) < 300 )
                {
                    enemyActionStates = enemyStates.shooting;
                }
                else {
                    rbody.AddForce(new Vector2(dirx * speed, rbody.velocity.y));
                }

                break;

            case enemyStates.shooting:
                Shoot(target.transform.position - transform.position);
                break;
        }
    }

    public void Shoot(Vector3 dir)
    {
        if (delayBullet < 0.1) {
            GameObject bullet = (GameObject)Instantiate(this.bullet, weapon.transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().rbody2d.AddForce(Vector3.ClampMagnitude(dir, 1) * 4f * Time.deltaTime, ForceMode2D.Impulse);
            delayBullet = 0.5f;
        }
        enemyActionStates = enemyStates.moving;
    }

}
