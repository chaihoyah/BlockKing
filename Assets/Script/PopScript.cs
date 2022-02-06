using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(DeletePop());
	}

    IEnumerator DeletePop()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
