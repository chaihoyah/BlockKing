using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectForReward : MonoBehaviour {

    public GameObject obj;

    public IEnumerator Twinkle()
    {
        yield return new WaitForSeconds(1);
        obj.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        obj.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        obj.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        obj.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        yield return new WaitForSeconds(1);
        obj.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        obj.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        obj.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        obj.SetActive(false);
        yield return new WaitForSeconds(0.3f);
    }
}
