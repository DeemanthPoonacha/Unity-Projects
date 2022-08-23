using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text coinScore;
    private AudioSource coinAudio;
    private int scoreCount=0;
    void Start()
    {
        coinScore = GameObject.Find("CoinText").GetComponent<Text>();
        coinAudio = GetComponent<AudioSource>();
    }

    public void ScoreUpdate(int value)
    {
        scoreCount += value;
        coinScore.text = "X " + scoreCount;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag==PreDefines.COIN_TAG)
        {
            ScoreUpdate(1);
            other.gameObject.SetActive(false);
            coinAudio.Play();
        }
    }
}
