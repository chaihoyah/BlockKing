using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour {

    public Transform BlockContainer;
    public Transform InGameUIContainer;
    BlockController blockController;
    InGameUIController UIController;

    public static int round = 1;
    public static int count = 0;

    private void Start()
    {
        round = 1;
        count = 0;
        blockController = BlockContainer.GetComponent<BlockController>();
        UIController = InGameUIContainer.GetComponent<InGameUIController>();
    }

    public void RoundUpCallback()
    {
        round++;
        blockController.EraseAllBlocks();
        //TODO: Insert RoundEffect
        UIController.RoundUpEffect();
    }
}
