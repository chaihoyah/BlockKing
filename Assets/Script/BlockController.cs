using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {

    public void EraseAllBlocks()
    {
        int count = transform.childCount;

        for (int i = 0; i < count; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        GameController.isRunning = true;
    }
}
