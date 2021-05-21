using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackToMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void gobacktomenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-2);
        GameManager.gameover = false;
        GameManager.win = false;
        Box.cantdestroyed = 0;
        Box.cantscore = 0;
        Enemy.cantdead = 0;
        Enemy.cantscore = 0;
        Bomb.distance = 2.5f;
        Bomb.distancebomb = 1;
        UIController.scorenum = 0;
    }
}
