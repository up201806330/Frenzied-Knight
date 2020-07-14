using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text scoreTxt;
    private Text highScoreTxt;

    private int score = 0; 
    private static int oldHighScore = 0;
    private int highScore = 0;

    public ScorePlus scorePlus;

    // Start is called before the first frame update
    void Start()
    {
        scoreTxt = GameObject.Find("Score").GetComponent<Text>();
        highScoreTxt = GameObject.Find("Highscore").GetComponent<Text>();
        highScore = oldHighScore;
    }

    // Update is called once per frame
    void Update()
    {
        if(score > highScore) highScore = score;

        scoreTxt.text = "score: " + score;
        highScoreTxt.text = "highscore: " + highScore;
    }

    public void AddScore(int val)
    {
        scorePlus.PlusScore(val);
        score += val;
    }

    public void UpdateHighScore()
    {
        oldHighScore = highScore;
    }

    public void ResetHighScore()
    {
        oldHighScore = 0;
    }
}