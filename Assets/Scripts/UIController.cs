using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] public Player player;
    [SerializeField] public TMPro.TMP_Text lives;
    [SerializeField] public TMPro.TMP_Text bombsactive;
    [SerializeField] public TMPro.TMP_Text score;
    [SerializeField] public TMPro.TMP_Text boxesDestroyed;
    [SerializeField] public TMPro.TMP_Text cantenemies;
    [SerializeField] public TMPro.TMP_Text cantdirections;
    [SerializeField] public TMPro.TMP_Text timertext;
    public float Timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer();
        lives.text = player.lives.ToString();
        bombsactive.text = player.cantBombs.ToString();
        score.text = Box.cantscore.ToString();
        boxesDestroyed.text = Box.cantdestroyed.ToString();
        cantenemies.text = Enemy.cantdead.ToString();
    }

    void timer()
    {
        Timer += Time.deltaTime;
        int minutes = Mathf.FloorToInt(Timer / 60f);
        int seconds = Mathf.FloorToInt(Timer % 60f);
        int milliseconds = Mathf.FloorToInt((Timer * 100f) % 100f);
        timertext.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
    }
}
