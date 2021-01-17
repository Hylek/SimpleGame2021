using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float maxTime = 60f;

    [SerializeField]
    private float time = 0;

    private static bool hasWon = false;

    private void Start()
    {
        time = maxTime;
    }

    private void Update()
    {
        if(!hasWon)
        {
            time -= Time.deltaTime;
        }

        if(time <= 0)
        {
            Coin.CoinCount = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public static void Stop()
    {
        hasWon = true;
    }
}
