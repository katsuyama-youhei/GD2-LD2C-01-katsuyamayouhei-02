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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("水にあたった");
            playerMove.isAlive = false;
            for(int i = 0; i < 20; i++)
            {
                Vector3 pos = new Vector3(player.gameObject.transform.position.x, player.gameObject.transform.position.y, player.gameObject.transform.position.z);
                Instantiate(particlePrehub,pos, Quaternion.identity);
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
