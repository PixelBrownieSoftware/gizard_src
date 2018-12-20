using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {

    public GameObject gamemanager;
    public GameObject mainmenu;

    GameManager gmanager;

    public Text scoreTxt;
    public Text timer;
    public Text hp;

    public TIPS tips;

    void Start() {
        PlayerPrefs.GetInt("HighScore");
        gmanager = gamemanager.GetComponent<GameManager>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            gamemanager.SetActive(true);
            gmanager.Start();
            mainmenu.SetActive(false);
        }
    }

    void Update () {
        scoreTxt.text = "Highest score: " + PlayerPrefs.GetInt("HighScore");
        timer.text = "Welcome to the game!";

        if (!tips.isactivated) {
            hp.text = "Tip: " + "Shoot the logo on the left for some tips.";
        } else {
            hp.text = "Tip: " + tips.selected_text;
        }
        
	}
}
