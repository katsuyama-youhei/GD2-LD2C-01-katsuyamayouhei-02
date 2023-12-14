using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DeleteScript : MonoBehaviour
{

    private GameObject player;
    private MoveScript playerMove;

    Transform transfom;
   // GameObject gameObject;

    // Start is called before the first frame update
    void Start()
    {

       // gameObject=GetComponent<GameObject>();
        transfom =GetComponent<Transform>();

        player = GameObject.FindGameObjectWithTag("Player");
        playerMove = player.GetComponent<MoveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMove.transform.position.x> transfom.position.x + 10f)
        {
            Debug.Log("è¡ãé");
            Destroy(gameObject);
          
        }
    }
}
