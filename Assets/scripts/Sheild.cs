using UnityEngine;
using System.Collections;

public class Sheild : MonoBehaviour {
    Player parent;
    cameraScript cameraObj;

    public sound SFX;

    void Start () {
        parent = GameObject.Find("player").GetComponent<Player>();
        cameraObj = GameObject.Find("Main Camera").GetComponent<cameraScript>();
    }

    void OnTriggerStay2D(Collider2D col) {
        if (col.CompareTag("Enemy") || col.gameObject.name == "EnemyBullet(Clone)") {
            
            if (parent.rbody.velocity.magnitude > 40) {
                cameraObj.camerashake(12, 0.2f);
                parent.reBound(parent.mouse);
                if (col.gameObject.name != "EnemyBullet(Clone)") {
                    col.GetComponent<characterbase>().Damage(); col.GetComponent<Enemy>().reBound(); col.GetComponent<Enemy>().sfx.hurtenemy.Play();
                }
                SFX.bounce.Play();
            }
        }

    }

	// Update is called once per frame
	void Update () {
	
	}
}
