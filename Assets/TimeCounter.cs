using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    public Text timeText;
    private GameController gameController;

    private void Start()
    {
        gameController = GameController.instance;
    }
    // Update is called once per frame
    void Update()
    {
       timeText.text = "TIME LEFT: "+ gameController.timeLeft.ToString("0");
       timeText.color = Color.Lerp(Color.red, Color.white, (gameController.timeLeft/60));

    }
}