using UnityEngine;
using System.Collections;

public class enemynorm : Enemy {

    public enum enemyStates { moving, jumping };
    public enemyStates enemyActionStates;
    Collider2D groundCheck;
    GameObject attack;
    public LayerMask layer;

	// Use this for initialization
	new void Start () {
        score = Random.Range(1,5);
        health = 4f;
        base.Start();
        groundCheck = transform.Find("hitdet").GetComponent<BoxCollider2D>();
        attack = transform.Find("attack").gameObject;
    }
	
	// Update is called once per frame
	new void Update () {
        base.Update();

        switch (enemyActionStates) {

            case enemyStates.moving:
                
                if (Mathf.Abs(target.transform.position.x - transform.position.x) < 80 && Mathf.Abs(target.transform.position.y - transform.position.y) > 30 && groundCheck.IsTouchingLayers(512)) {
                    enemyActionStates = enemyStates.jumping;
                }
                else {
                    Vector2 direct = target.transform.position;

                    float deg = Mathf.Atan2(direct.y - transform.position.y, direct.x - transform.position.x) * Mathf.Rad2Deg - 360;

                    direc = Quaternion.AngleAxis(deg, Vector3.forward) * Vector3.right * 90;

                    dirx = target.transform.position.x > transform.position.x ? 1 : -1;
                    rbody.AddForce(new Vector2(dirx * speed, rbody.velocity.y));
                }

                break;

            case enemyStates.jumping:
                StartCoroutine(jump());
                break;
        }
    }

    public IEnumerator jump() {
        rbody.AddForce(new Vector2(rbody.velocity.x, 100 + speed * 3.4f));
        yield return new WaitForSeconds(0.5f);
        
        enemyActionStates = enemyStates.moving;
    }
}
