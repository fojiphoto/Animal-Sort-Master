using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    
    public void LoadNextScene()
    {
        // Load the next scene based on the build settings
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void GoToHomeScene()
    {
        // Load the scene with index 0 (assuming 0 is your home scene)
        SceneManager.LoadScene(1);
    }
}
