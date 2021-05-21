using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.win)
            GetComponent<TMPro.TMP_Text>().text = "You Win!";
        else
        {
            GetComponent<TMPro.TMP_Text>().text = "You Lose!";
        }
    }
}
