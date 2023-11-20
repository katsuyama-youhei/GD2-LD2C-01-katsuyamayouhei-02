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
        // playerが当たったらプレイヤーが上昇するように
         if (other.CompareTag("Player"))
        {
            moveScript.windPower = 0.9f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // playerが離れたら上昇させていた変数を0に
        if (other.CompareTag("Player"))
        {
            moveScript.windPower = 0.0f;
        }
    }

}
