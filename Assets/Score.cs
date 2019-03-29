using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    private GameController gameController;

    private void Start()
    {
        gameController = GameController.instance;
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = "KILLED: "+ gameController.killCount.ToString("0") + "/" + gameController.minKillCount.ToString("0");
    }
}
