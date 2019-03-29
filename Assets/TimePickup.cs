using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePickup : MonoBehaviour
{

    private GameController gameController;
    private bool entered = false;
    public AudioSource pickupSound;
    public float extendTimeBy = 20f;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameController.instance;

    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (!entered)
        {
            entered = true;
            gameController.timeLeft += extendTimeBy;
            Destroy(gameObject,0.5f);
            pickupSound.Play();
        }
    }
}
