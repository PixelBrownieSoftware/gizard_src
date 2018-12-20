using UnityEngine;
using System.Collections;

public class bouncer : Enemy {

	// Use this for initialization
	new void Start () {
        health = 2;
        base.Start();
	}
	
	// Update is called once per frame
	new void Update () {
        health = 2;
	}
}
