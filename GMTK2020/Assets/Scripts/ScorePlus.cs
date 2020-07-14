using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePlus : MonoBehaviour
{
    private Text scoreTxt;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        scoreTxt = this.GetComponent<Text>();
        anim = this.GetComponent<Animator>();
    }

    public void PlusScore(int score)
    {
        scoreTxt.text = "+" + score;
        anim.Play("++scoreTxtAnim");
    }
}