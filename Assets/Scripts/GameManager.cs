using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject result;
    public TMPro.TMP_Text wintext; 
    public static bool win;
    public static bool gameover = false;
    private static GameManager instance;
    public static GameManager Get()
    {
        return instance;
    }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public static bool GameOver()
    {
        if (gameover)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void NextScene()
    {
        result.SetActive(true);
        if (win)
        {
            wintext.text = "You Win!";
            wintext.color = Color.green;
        }
        else
        {
            wintext.text = "You Lose!";
            wintext.color = Color.red;
        }
    }
}
