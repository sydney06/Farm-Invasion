using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crops : MonoBehaviour
{
    public static int points = 0;

    public GameObject onGamePanel;

    public GameObject gameOverPanel;

    public List<GameObject> crops = new List<GameObject>();

    public Slider cropsLeft;

    public Text cropsLeftText;

    public Text scorePoints;

    public GameObject scoreSystemManager;

    void Start()
    {

        foreach (GameObject crop in GameObject.FindGameObjectsWithTag("Destroy"))
        {
            crops.Add(crop);
        }
    }

    // Update is called once per frame
    void Update()
    {
        cropsLeft.value = crops.Count;

        cropsLeftText.text = crops.Count.ToString();

        scorePoints.text = points.ToString();

        CheckHighScore();

        foreach (GameObject crop in crops)
        {
            if (crop.GetComponent<ScoreSystemManager>().triggered)
            {
                //crops.Remove(crop);

                cropsLeft.value--;

                cropsLeftText.text = cropsLeft.value.ToString();

                if(cropsLeft.value == 0)
                {
                    GameOver();
                }

                crop.SetActive(false);
            }
        }
    }

    void GameOver()
    {
        onGamePanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    void CheckHighScore()
    {
        if(PlayerPrefs.GetInt("points") <= points)
        {
            PlayerPrefs.SetInt("points", points);
        }
    }
}
