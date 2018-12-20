using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int wave;
    public int score;
    private int lastwave;

    public Text scoreTxt;
    public Text timer;
    public Text hp;

    public Player player;

    public GameObject self;
    public GameObject mainmenu;

    public GameObject[] levels;
    public level leveldata;

    public void Start() {
        for (int i = 0; i < levels.Length; i++)
        {
            if (wave == i)
            {
                levels[i].SetActive(true);
                leveldata = levels[i].GetComponent<level>();
            }
            else { levels[i].SetActive(false); }
        }
        loadPlayerPos(leveldata.plyr_x, leveldata.plyr_y);
    }

    void loadPlayerPos(int x, int y) {
       
        player.health = 5;
        player.transform.position = new Vector3(x,y,22);
    }

    public void LoadLevel() {
        for (int i = 0; i < levels.Length; i++)
        {
            if (wave == i)
            {
                levels[i].SetActive(true);
                leveldata = levels[i].GetComponent<level>();
            }
            else { levels[i].SetActive(false); }
        }
    }

    public void ReloadLevel() {
        wave = 0;
        loadPlayerPos(0, -90);
        leveldata.DeleteEnemies();
        mainmenu.SetActive(true);
        self.SetActive(false);
    }


    void Update() {

        //PlayerPrefs.SetInt("HighScore" , 0);

        if (score > PlayerPrefs.GetInt("HighScore")){
            PlayerPrefs.SetInt("HighScore", score);
        }

        player = GameObject.Find("player").GetComponent<Player>();

        

          if (wave == 9) {
              timer.text = "THE END... or is it?";
            scoreTxt.text = "Game made by PrownieBrownieSoft (Hamza Salih)";
            hp.text = "Highest Score:" + PlayerPrefs.GetInt("HighScore");
        }
          else { 
        timer.text = "Timer: " + Mathf.FloorToInt(leveldata.timer);
        scoreTxt.text = "Score: " + score;
        hp.text = "HP: " + player.health;
        }

        if (leveldata.timer <= 0) {
            leveldata.DeleteEnemies();
            wave++;
            LoadLevel();
            loadPlayerPos(leveldata.plyr_x, leveldata.plyr_y);
        }
    }
}
