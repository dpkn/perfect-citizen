using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class Finish: MonoBehaviour
{

    private FirstPersonController player;
    private bool entered = false;
    private GameController gameController;

    public AudioSource finishSound;
    public string scene;
    public bool turnedOn = false;
    public Material turnedOnMaterial;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerManager.instance.player.GetComponent<FirstPersonController>();
        gameController = GameController.instance;

    }

    private void Update()
    {
        if(!turnedOn && gameController.killCount >= gameController.minKillCount)
        {
            turnedOn = true;
            Debug.Log("TUrned oN BITCH");
            gameObject.GetComponent<MeshRenderer>().material = turnedOnMaterial;
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(scene);

    }

    void OnTriggerEnter(Collider other)
        {
            if (!entered && turnedOn)
            {
                entered = true;
                player.enabled = false;
                Invoke("LoadNextScene", 2f);
                finishSound.Play();
            }
        }
}
