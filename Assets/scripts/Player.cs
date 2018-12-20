using UnityEngine;
using System.Collections;

public class Player : characterbase {

    public enum playerStates {idle, Sheilded, Pushed };
    public playerStates playerActionStates;
    public GameObject weapon;
    public GameObject sphere;
    public GameObject sheild;

    Transform groundcheck;
    
    Vector2 direc;

    public sound SFX;

    cameraScript cameraObj;
    public GameManager gmanager;

    public GameObject bullet;
    float delayBullet;
    float sheildTimer;

    // Use this for initialization
    new void Start () {
        base.Start();
        health = 69;
        speed = 80f;
        cameraObj = GameObject.Find("Main Camera").GetComponent<cameraScript>();
        sheild.SetActive(false);
        canBeDestoryed = false;
    }
   public Vector3 mouse;
    // Update is called once per frame

    new void Update() {
        base.Update();
        if (health <= 0) {
            gmanager.ReloadLevel();
        }
    }

	void FixedUpdate () {

        if (delayBullet > 0) { delayBullet = delayBullet - Time.deltaTime; }
        if (sheildTimer > 0) { sheildTimer = sheildTimer - Time.deltaTime; }

        mouse = new Vector3(Camera.main.ScreenPointToRay(Input.mousePosition).origin.x, Camera.main.ScreenPointToRay(Input.mousePosition).origin.y, 0);

        // for push force thingy
        sphere.transform.LookAt(mouse);

      /*  if (Input.GetMouseButton(0)) {
            shoot(mouse  -this.transform.position);
        }*/
        switch (playerActionStates) {

            case playerStates.idle:
                weapon.SetActive(true);
                if (Input.GetMouseButton(0)) {
                    playerActionStates = playerStates.Pushed;
                }
                if (Input.GetMouseButtonDown(1)) {
                    weapon.SetActive(false);
                    sheildTimer = 0.9f;
                    playerActionStates = playerStates.Sheilded;
                }

                break;

            case playerStates.Sheilded:
                
                sheild.SetActive(true);
                if (!Input.GetMouseButton(1) || sheildTimer < 0.1) {
                    sheild.SetActive(false);
                    playerActionStates = playerStates.idle;
                }
                break;

            case playerStates.Pushed:
                
                if (delayBullet < 0.1) {
                    cameraObj.camerashake(5, 0.2f);
                    SFX.gun.Play();
                    shoot(mouse - this.transform.position);
                    delayBullet = 0.2f; }
                
                
                if (!Input.GetMouseButton(0))
                { playerActionStates = playerStates.idle; }
                    break;
        }

        if (rbody.velocity.magnitude > 280) {
            rbody.velocity = rbody.velocity.normalized * 280;
        } 
    }

    public void shoot(Vector3 dir) {
        reBound(dir);
        GameObject bullet = (GameObject)Instantiate(this.bullet, weapon.transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().rbody2d.AddForce(Vector3.ClampMagnitude( dir, 1) * 4f * Time.deltaTime, ForceMode2D.Impulse);
    }

    public void reBound( Vector3 direction) {
        print("laaah");
        rbody.AddForce((direction / direction.magnitude) * -speed * 4 , ForceMode2D.Impulse);
    }
}
