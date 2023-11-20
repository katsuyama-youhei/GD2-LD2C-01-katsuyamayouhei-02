using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WindPowerScript : MonoBehaviour
{
    private GameObject player;
    private MoveScript moveScript;
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            return;
        }

        moveScript = player.GetComponent<MoveScript>();
        if(moveScript == null)
        {
            return;
        }
        playerRb=player.GetComponent<Rigidbody>();
        {
            if(playerRb==null)
            {
                return;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   private void OnTriggerEnter(Collider other)
    {
        // player‚ª“–‚½‚Á‚½‚çƒvƒŒƒCƒ„[‚ªã¸‚·‚é‚æ‚¤‚É
         if (other.CompareTag("Player"))
        {
            moveScript.windPower = 0.9f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // player‚ª—£‚ê‚½‚çã¸‚³‚¹‚Ä‚¢‚½•Ï”‚ğ0‚É
        if (other.CompareTag("Player"))
        {
            moveScript.windPower = 0.0f;
        }
    }

}
