using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callnextcar : MonoBehaviour
{
    public GameObject car,currentcar;
    public Deliver nextcar;
    public GameObject winpannel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!currentcar.activeSelf)
        {
            Debug.LogError("hy");
            if (nextcar != null)
            {
                car.SetActive(true);
                nextcar.canGoToStandPos = true;
            }
            else
            {
                winpannel.SetActive(true);
            }
        }
    }
}
