using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public bool isAlive;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        player = GameObject.FindGameObjectWithTag("Player");

        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive)
        {
            player.SetActive(false);
        }
    }
}
