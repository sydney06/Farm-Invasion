using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    public Text highscore;

    // Start is called before the first frame update
    void Start()
    {
        highscore.text = PlayerPrefs.GetInt("points").ToString();
    }
}
