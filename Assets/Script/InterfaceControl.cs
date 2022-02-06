using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceControl : MonoBehaviour {


    float width, height;
    float size;
    public Camera camera;

    private void Awake()
    {
        width = Screen.width;
        height = Screen.height;
        float temp = (height / width);

        if (temp >= 1.778f)
        {
            size = (temp / 1.778f) * 5;
        }
        else
        {
            GameObject.Find("Canvas").GetComponent<CanvasScaler>().matchWidthOrHeight = 1;
            size = 5;
        }

        

        camera.orthographicSize = size;
    }
}
