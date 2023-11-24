using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<Level> levels;

    private int startIndex =0;

    private int currentIndex;

    public GameObject vfxLevelUp;

    public GameObject WinPanel,level,level1, level2, level3, level4, level5, level6, level7, level8, level9, level10, level11, level12, level13, level14, level15, level16, level17, level18, level19;
    int n;

    private void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("level"));
    }

    private void Awake()
    {
        n = PlayerPrefs.GetInt("level");
        currentIndex = n-1;
        Debug.Log("curent value"+currentIndex);

        if (Instance == null)
        {
            Instance = this;
        }
        for (int i = 0; i < 20; i++)
        {
            levels[i].gameObject.SetActive(false);
            
        }

      //  currentIndex = startIndex;
     levels[currentIndex ].gameObject.SetActive(true);
    }

    

    public int GetCurrentIndex()
    {
        return currentIndex;
    }

    public void CheckLevelUp()
    {
        if (levels[currentIndex].gameObjects.Count == 0)
        {
            
            currentIndex += 1;
            PlayerPrefs.SetInt("level", currentIndex);
            GameObject vfx = Instantiate(vfxLevelUp, transform.position, Quaternion.identity);
            Destroy(vfx, 2f);
            
            PlayerPrefs.Save();
            StartCoroutine(LevelUp());
            Invoke(nameof(showWinPanel), 2f);
            //showWinPanel();
            
        }
        PlayerPrefs.SetInt("level", currentIndex);
    }

    public void ResetGame()
    {
        PlayerPrefs.SetInt("level", currentIndex+1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator LevelUp()
    {
        yield return new WaitForSeconds(2);

        if (currentIndex < levels.Count)
        {
            levels[currentIndex - 1].gameObject.SetActive(false);
            levels[currentIndex].gameObject.SetActive(true);
            


        }
        else
        {
            // All levels completed, you can handle this case accordingly
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void ReSetCurrentLevel()
    {
        //levels[currentIndex].AddComponents();
    }
    public void showWinPanel()
    {
        WinPanel.SetActive(true);
        AdsManager.instance?.ShowInterstitialWithoutConditions();
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
        level2.SetActive(false);
        level3.SetActive(false);
        level4.SetActive(false);
        level5.SetActive(false);
        level6.SetActive(false);
        level7.SetActive(false);
        level8.SetActive(false);

        level9.SetActive(false);
        

        
    }
    public void LoadNextLevelFromWinPanel()
    {
        // Hide the win panel
        WinPanel.SetActive(false);
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
        level2.SetActive(true);
        level3.SetActive(true);
        level4.SetActive(true);
        level5.SetActive(true);
        level6.SetActive(true);
        level7.SetActive(true);
        level8.SetActive(true);

        level9.SetActive(true);

        // Call the LevelUp coroutine to move to the next level
        StartCoroutine(LevelUp());
        
    }
    
}