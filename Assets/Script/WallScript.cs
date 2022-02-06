using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour {

    public Transform GameControllerContainer;
    GameController gameController;

    private void Start()
    {
        gameController = GameControllerContainer.GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Object") && GameController.inGame)
        {
            Vector3 vec = other.transform.position;
            int kind = other.GetComponent<BlockInfo>().Kind;
            gameController.Effect_Reward_Block(new Vector3(vec.x, vec.y, -5), kind);
            //Destroy object
            Destroy(other.gameObject);
            GameController.inGame = false;

            gameController.Finish_Game();
        }
    }
}
