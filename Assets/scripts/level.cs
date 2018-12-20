using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class level : MonoBehaviour {

    public float maxtimer;
    public float timer;
    public int score;

    public GameObject[] enemies;
    public int plyr_x;
    public int plyr_y;

    void Start() {
        timer = maxtimer;

    }

    public void DeleteEnemies() {
        for (int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i].gameObject);
        }
        timer = maxtimer;
    }

    void Update () {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (timer > 0) {
            timer = timer - Time.deltaTime;
        } 
	}
}
