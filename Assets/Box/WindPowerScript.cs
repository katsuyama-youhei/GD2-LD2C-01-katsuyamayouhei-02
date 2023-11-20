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
        // player������������v���C���[���㏸����悤��
         if (other.CompareTag("Player"))
        {
            moveScript.windPower = 0.9f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // player�����ꂽ��㏸�����Ă����ϐ���0��
        if (other.CompareTag("Player"))
        {
            moveScript.windPower = 0.0f;
        }
    }

}
