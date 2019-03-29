using UnityEngine;
using System.Collections;

public class NewMonoBehaviour : MonoBehaviour
{

    public float battery = 100f;
    public float decreaseSpeed = 1f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        battery = battery - decreaseSpeed * Time.deltaTime;

        switch (battery)
        {
            case 100:
             //   lightLevel = 100;
                break;

        }

    }
}
