using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameInterface : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(cor());
    }

    IEnumerator cor()
    {
        yield return new WaitForEndOfFrame();
    }
}
