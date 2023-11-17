using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<Level> levels;

    private int startIndex = 0;

    private int currentIndex;

    public GameObject vfxLevelUp;

    public GameObject WinPanel;
    int n;

    private void Start()
    {
      
    }

    private void Awake()
    {
        n = PlayerPrefs.GetInt("level");
        currentIndex = n;
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
      if(currentIndex!=0)

        levels[currentIndex-1].gameObject.SetActive(true);
      else
            levels[currentIndex].gameObject.SetActive(true);
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

            GameObject vfx = Instantiate(vfxLevelUp, transform.position, Quaternion.identity);
            Destroy(vfx, 2f);

            StartCoroutine(LevelUp());
            showWinPanel();
        }
        PlayerPrefs.SetInt("level", currentIndex);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator LevelUp()
    {
        yield return new WaitForSeconds(2);

        levels[currentIndex-1].gameObject.SetActive(false);

        if (currentIndex >= levels.Count)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            currentIndex = 0;
        }

        levels[currentIndex].gameObject.SetActive(true);
    }

    public void ReSetCurrentLevel()
    {
        //levels[currentIndex].AddComponents();
    }
    public void showWinPanel()
    {
        WinPanel.SetActive(true);
    }
    public void LoadNextLevelFromWinPanel()
    {
        // Hide the win panel
        WinPanel.SetActive(false);

        // Call the LevelUp coroutine to move to the next level
        StartCoroutine(LevelUp());
    }
    
}