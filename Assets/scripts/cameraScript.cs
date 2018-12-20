using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour {

    public GameObject player;

    float camshakeTime;
    float movtime;
    float speed;

    int shakepow;
	// Use this for initialization
	void Start () {
        speed = 2f;
        movtime = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (movtime < speed) {
            movtime = +Time.deltaTime;
            float s = movtime / speed;
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0) ;
            //Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, 0), s * 5.5f);
        }

        if (camshakeTime > 0) {
            int shake_pos = Random.Range(-shakepow, shakepow);
            transform.position = new Vector3(transform.position.x + shake_pos, transform.position.y + shake_pos);
            camshakeTime = camshakeTime - Time.deltaTime;
        }
    }

    public void camerashake(int shake , float dur) {
        shakepow = shake;
        camshakeTime = dur;
        
    }

}
