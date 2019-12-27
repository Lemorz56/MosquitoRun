using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public double score;
    public Text scoreDisplay;

    public GameObject Player;
    private Player access;

    private void Start()
    {
        access = Player.GetComponent<Player>();
    }
    private void Update()
    {
        scoreDisplay.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (access.health != 0) 
        { 
            if (collision.CompareTag("Obstacle"))
            {
                score++;
                Debug.Log(score);
            }
        }
    }
}

//https://youtu.be/ft-uk8xGOTs?t=205
