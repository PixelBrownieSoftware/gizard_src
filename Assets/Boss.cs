using UnityEngine;
using System.Collections;

public class Boss : Enemy {

    public enum BOSSSTATEMACHINES { idle, summmon, fireball, stunned };
    public BOSSSTATEMACHINES bossActionState;

    public GameObject[] enemies;
    float deg;
    float delayBullet;

    public GameObject weaponThing;

    // Use this for initialization
    new void Start () {
        health = 10;
        base.Start();
        weapon = transform.Find("weapon");
    }

    void pointToPlayer() {
        target = GameObject.Find("player");
        Vector2 direct = target.transform.position;

        deg = Mathf.Atan2(direct.y - transform.position.y, direct.x - transform.position.x) * Mathf.Rad2Deg - 360;

        weapon.transform.rotation = Quaternion.AngleAxis(deg, new Vector3(0, 0, transform.position.z));

        direc = Quaternion.AngleAxis(deg, Vector3.forward) * Vector3.right * 90;
    }


	// Update is called once per frame
	new void Update () {

        pointToPlayer();
        if (delayBullet > 0) { delayBullet = delayBullet - Time.deltaTime; }
        int state;

        switch (bossActionState) {
            case BOSSSTATEMACHINES.idle:

                state = Random.Range(0,2);
                if (delayBullet < 0) { bossActionState = BOSSSTATEMACHINES.summmon; }
                
                break;
            case BOSSSTATEMACHINES.summmon:
                int enemy = Random.Range(1,3);
                Instantiate(enemies[enemy], weaponThing.transform.position, Quaternion.identity);
                delayBullet = 3f;
                bossActionState = BOSSSTATEMACHINES.idle;
                break;

            case BOSSSTATEMACHINES.fireball:
                
                Shoot(target.transform.position - transform.position);
                delayBullet = 3f;
                bossActionState = BOSSSTATEMACHINES.idle;
                break;
        }
	}


    void Shoot(Vector3 dir) {
        GameObject bullet = (GameObject)Instantiate(this.bullet, weaponThing.transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().rbody2d.AddForce(Vector3.ClampMagnitude(dir, 1) * 4f * Time.deltaTime, ForceMode2D.Impulse);
    }
}
