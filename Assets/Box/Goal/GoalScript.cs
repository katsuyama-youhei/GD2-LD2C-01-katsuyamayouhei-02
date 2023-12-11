using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
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
   

    

    private void OnCollisionEnter(Collision collision)
    {
        string collidedObjectTag = collision.gameObject.tag;

        // 取得したタグを使って何かしらの処理を行う
        if (collidedObjectTag == "Player")
        {
           // float newPosition = Random.Range(-1f, 1f);
            //Vector3 pos = new Vector3(player.gameObject.transform.position.x+ newPosition, player.gameObject.transform.position.y, player.gameObject.transform.position.z - 0.5f);
            for (int i = 0; i < 30; i++)
            {
                float newPosition = Random.Range(-1f, 1f);
                Vector3 pos = new Vector3(player.gameObject.transform.position.x + newPosition, player.gameObject.transform.position.y, player.gameObject.transform.position.z - 0.5f);
                Instantiate(particlePrehub, pos, Quaternion.identity);
            }
        }
    }
}
