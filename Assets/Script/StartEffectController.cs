using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartEffectController : MonoBehaviour {

    public GameObject ControllerContainer;
    public Transform StartImage;

    private GameController GameController;
	// Use this for initialization
	void OnEnable () {
        //StartSetting
        GameController = ControllerContainer.GetComponent<GameController>();
        StartImage.localScale = new Vector3(0, 0, 0);
        //Effect
        StartCoroutine(StartEffect());
        //GameStart Callback
        
	}

    IEnumerator StartEffect()
    {
        Vector3 size = new Vector3(0.01f, 0.01f, 0.01f);
        for (int i = 0; i < 100; i++)
        {
            StartImage.localScale += size;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.3f);

        GameController.StartGame();
        this.gameObject.SetActive(false);
    }
	
	
}
