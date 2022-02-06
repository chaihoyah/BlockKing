using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillObject : MonoBehaviour {

    InGameUIController UIController;
    GameController gameController;

	// Use this for initialization
	void Start () {
        UIController = GameObject.Find("UIController").GetComponent<InGameUIController>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        GameObject.Find("SoundManager").GetComponent<SoundManager>().Thunder_Sound();
        StartCoroutine(Move());
	}

    IEnumerator Move()
    {
        Vector3 vec = new Vector3(0,-0.03f,0);
        while (true)
        {
            transform.position += vec;
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Object"))
        {
            //When this object  is collided  with other objects
            Vector3 vec = other.transform.position;
            int kind = other.GetComponent<BlockInfo>().Kind;
            gameController.Effect_Reward_Block(new Vector3(vec.x ,vec.y, -5), kind);
            //Destroy object
            Destroy(other.gameObject);
            //Get score and            
        }
        else if (other.tag.Equals("floor"))
        {
            GameController.isRunning = true;
            Destroy (this.gameObject);
        }
    }

}
