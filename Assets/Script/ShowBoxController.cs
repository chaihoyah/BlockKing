using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBoxController : MonoBehaviour {

    public GameObject[] Boxs = new GameObject[5];

    public void ShowBox(int num)
    {
        for (int i = 0; i < 5; i++)
        {
            Boxs[i].SetActive(false);
        }

        Boxs[num - 1].SetActive(true);
    }
}
