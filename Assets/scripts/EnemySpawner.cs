using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

    GameManager gamemanager;
    public GameObject[] enemies;
    public GameObject enemy;
    float spawndelay;
    // Use this for initialization

	void Start() {
    }

    void Update() {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (spawndelay <= 0) {
            Spawn();
        }
        if (spawndelay >= 0) { spawndelay = spawndelay - Time.deltaTime; }
    }

    

    public void Spawn() {
        if (enemies.Length < 20) { Instantiate(enemy, transform.position, Quaternion.identity); spawndelay = 3f; }
        
    }

}
