using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movemanager : MonoBehaviour
{
    public int move = 3;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(move == 0)
        {
            canvas.SetActive(true);
            AdsManager.instance?.ShowInterstitialWithoutConditions();
        }
    }
}
