using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public GameObject PausePannel,level, level1, level2, level3, level4, level5, level6, level7, level8, level9, level10, level11,level12, level13, level14, level15, level16, level17, level18, level19;

    public void pausepannelon()
    {
        PausePannel.SetActive(true);
        level.SetActive(false);
        level1.SetActive(false);
        level2.SetActive(false);
        level3.SetActive(false);
        level4.SetActive(false);
        level5.SetActive(false);
        level6.SetActive(false);
        level7.SetActive(false);
        level8.SetActive(false);
        level9.SetActive(false);
        level10.SetActive(false);
        level11.SetActive(false);
        level12.SetActive(false);
        level13.SetActive(false);
        level14.SetActive(false);
        level15.SetActive(false);
        level16.SetActive(false);
        level17.SetActive(false);
        level18.SetActive(false);
        level19.SetActive(false);
        AdsManager.instance?.ShowInterstitialWithoutConditions();
    }

    public void resumegame()
    {
        PausePannel.SetActive(false);
        level.SetActive(true);
        level1.SetActive(true);
        level2.SetActive(true);
        level3.SetActive(true);
        level4.SetActive(true);
        level5.SetActive(true);
        level6.SetActive(true);
        level7.SetActive(true);
        level8.SetActive(true);
        level9.SetActive(true);
        level10.SetActive(true);
        level11.SetActive(true);
        level12.SetActive(true);
        level13.SetActive(true);
        level14.SetActive(true);
        level15.SetActive(true);
        level16.SetActive(true);
        level17.SetActive(true);
        level18.SetActive(true);
        level19.SetActive(true);
    }
}
