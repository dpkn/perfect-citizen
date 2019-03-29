using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    #region singleton
    public static GameController instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    private bool pressStart;
    private FirstPersonController player;
    public Animator startAnimation;
    public Animator gameOverAnimation;
    public int killCount;
    public int minKillCount;
    public float timeLeft;
    public float maxTime;


    // Start is called before the first frame update
    void Start()
    {
        player = PlayerManager.instance.player.GetComponent<FirstPersonController>();
        killCount = 0;
        int qualityLevel = QualitySettings.GetQualityLevel();
        Debug.Log("Quality" + qualityLevel.ToString());
    }

    // Update is called once per frame
    void Update()
    {   
        
        pressStart = CrossPlatformInputManager.GetButtonDown("Jump");

        if (pressStart && !player.enabled)
        {
            player.enabled = true;
            startAnimation.SetBool("startFadeOut", true);
        }

        if (player.enabled)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft > maxTime)
            {
                timeLeft = maxTime;
            }else if(timeLeft < 0)
            {
                EndGame();
            }

        }

    }

    // EndGame is called when the player runs out of time, or falls of a platform
    public void EndGame()
    {
        player.enabled = false;
  
        gameOverAnimation.SetBool("gameOver", true);
        Invoke("ReloadScene", 1f);
    }

    void ReloadScene()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
