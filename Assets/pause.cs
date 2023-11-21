using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public GameObject PausePannel;

    public void pausepannelon()
    {
        PausePannel.SetActive(true);
    }

    public void resumegame()
    {
        PausePannel.SetActive(false);
    }
}
