using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartScript : MonoBehaviour
{
    private GameObject player;
    private MoveScript playerMove;

    [SerializeField] private string loadScene;
    [SerializeField] private Color fadeColor = Color.black;
    [SerializeField] private float fadeSpeedMultiplier = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMove = player.GetComponent<MoveScript>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerMove.isAlive) {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Initiate.Fade(loadScene, fadeColor, fadeSpeedMultiplier);
            }
        }
       
    }

   
}