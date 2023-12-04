using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GoalPlayerScript : MonoBehaviour
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
        if (playerMove.isGoal)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Initiate.Fade(loadScene, fadeColor, fadeSpeedMultiplier);
            }
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        string collidedObjectTag = collision.gameObject.tag;

        // 取得したタグを使って何かしらの処理を行う
        if (collidedObjectTag == "Goal")
        {
            Debug.Log("ゴール");
            playerMove.isGoal = true;
        }
    }
}
