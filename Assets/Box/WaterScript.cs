using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{

    private GameObject player;
    private MoveScript playerMove;
    public GameObject particlePrehub;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMove = player.GetComponent<MoveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     /* private void OnTriggerStay(Collider other)
      {
          if (other.CompareTag("Player"))
          {
             // Debug.Log("水にあたった");
              //playerMove.isAlive = false;
            for(int i = 0; i < 50; i++)
              {
                  Vector3 pos = new Vector3(player.gameObject.transform.position.x, player.gameObject.transform.position.y, player.gameObject.transform.position.z-0.6f);
                  Instantiate(particlePrehub,pos, Quaternion.identity);
              }
          }
      }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("水にあたった");
            playerMove.isAlive = false;
            Vector3 pos = new Vector3(player.gameObject.transform.position.x, player.gameObject.transform.position.y, player.gameObject.transform.position.z - 0.5f);
            for (int i = 0; i < 30; i++)
            {
                
                Instantiate(particlePrehub,pos, Quaternion.identity);
            }
            Vector3 pos2 = new Vector3(player.gameObject.transform.position.x+0.3f, player.gameObject.transform.position.y, player.gameObject.transform.position.z - 0.5f);
            for (int i = 0; i < 20; i++)
            {
                Instantiate(particlePrehub, pos2, Quaternion.identity);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        string collidedObjectTag = collision.gameObject.tag;

        // 取得したタグを使って何かしらの処理を行う
        if (collidedObjectTag == "Player")
        {
            Debug.Log("水にあたった");
            playerMove.isAlive = false;
        }
    }

}
