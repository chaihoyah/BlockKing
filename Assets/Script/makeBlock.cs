using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeBlock : MonoBehaviour {

	public GameObject block1;
	public GameObject block2;
	public GameObject block3;
	public GameObject block4;
    public GameObject block5;
    public GameObject Drill;

	public float a = 0.005f;

    public GameObject uiContainer;
    private InGameUIController UIController;
    public Transform BlockContainer;
    public Transform GameControllerContainer;
    private GameController gameController;
    public Transform ShowBoxContainer;
    private ShowBoxController ShowBoxController;
    int number;

    public GameObject SoundContainer;
    SoundManager soundManager;


    private void Start()
    {
        UIController = uiContainer.GetComponent<InGameUIController>();
        gameController = GameControllerContainer.GetComponent<GameController>();
        ShowBoxController = ShowBoxContainer.GetComponent<ShowBoxController>();
        SoundContainer = GameObject.Find("SoundManager").gameObject;
        soundManager = SoundContainer.GetComponent<SoundManager>();
        number = Random.Range(1, RoundController.round + 2);

        ShowBoxController.ShowBox(number);
      
    }

    public void click1(){
        CreateObject(new Vector2(-330 * a, 500 * a));
    }

    public void click2(){
        CreateObject(new Vector2(-300 * a, 500 * a));
    }

    public void click3(){
        CreateObject(new Vector2(-270 * a, 500 * a));
    }

    public void click4(){
        CreateObject( new Vector2(-240 * a, 500 * a));
    }

    public void click5(){
        CreateObject(new Vector2(-210 * a, 500 * a));
    }

    public void click6(){
        CreateObject(new Vector2(-180 * a, 500 * a));
    }

    public void click7(){
        CreateObject(new Vector2(-120 * a, 500 * a));
    }

    public void click8(){
        CreateObject(new Vector2(-120 * a, 500 * a));
	}

	public void click9(){
        CreateObject(new Vector2(-90 * a, 500 * a));
	}

	public void click10(){
        CreateObject(new Vector2(-60 * a, 500 * a));
	}
	public void click11(){
        CreateObject(new Vector2(-30* a, 500 * a));
	}
	public void click12(){
        CreateObject(new Vector2(0 * a, 500 * a));
	}
	public void click23(){
        CreateObject(new Vector2(330 * a, 500 * a));
	}

	public void click22(){
        CreateObject(new Vector2(300 * a, 500 * a));
	}

	public void click21(){
        CreateObject(new Vector2(270 * a, 500 * a));
	}

	public void click20(){
        CreateObject(new Vector2(240 * a, 500 * a));
	}

	public void click19(){
        CreateObject(new Vector2(210 * a, 500 * a));
	}

	public void click18(){
        CreateObject(new Vector2(180 * a, 500 * a));
	}

	public void click17(){
        CreateObject(new Vector2(150 * a, 500 * a));
	}

	public void click16(){
        CreateObject(new Vector2(120 * a, 500 * a));
	}

	public void click15(){
        CreateObject(new Vector2(90 * a, 500 * a));
	}

	public void click14(){
        CreateObject(new Vector2(60 * a, 500 * a));
	}

	public void click13(){
        CreateObject(new Vector2(30 * a, 500 * a));
	}

    void CreateObject(Vector2 vec)
    {
        if (GameController.isRunning)
        {
            GameController.isRunning = false;

            soundManager.Drop_Sound();
            
            switch (number)
            {
                case 1:
                    Instantiate(block1, vec, Quaternion.identity, BlockContainer); StartCoroutine(gameController.GoToNext());
                    break;
                case 2:
                    Instantiate(block2, vec, Quaternion.identity, BlockContainer); StartCoroutine(gameController.GoToNext());
                    break;
                case 3:
                    Instantiate(block3, vec, Quaternion.identity, BlockContainer); StartCoroutine(gameController.GoToNext());
                    break;
                case 4:
                    Instantiate(block4, vec, Quaternion.identity, BlockContainer); StartCoroutine(gameController.GoToNext());
                    break;
                case 5:
                    Instantiate(block5, vec, Quaternion.identity, BlockContainer); StartCoroutine(gameController.GoToNext());
                    break;
            }

            number = Random.Range(1, RoundController.round + 2);

            ShowBoxController.ShowBox(number);
        }
    }

    public void RewardBlock()
    {
        Instantiate(Drill, new Vector2(0, 500 *a), Quaternion.identity, BlockContainer);
        if(GameController.adcount == 0)
            UIController.Ad.gameObject.SetActive(false);
    }
}
