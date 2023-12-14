using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleWindScript : MonoBehaviour
{

    private GameObject player;
    private PlayerTitleMoveScript playerMove;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMove = player.GetComponent<PlayerTitleMoveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerMove.isCollision = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerMove.isCollision = false;

        }
    }
}
