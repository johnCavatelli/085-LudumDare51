using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LMLoad : MonoBehaviour
{
    public int scene;
    // Start is called before the first frame update
    void OnEnable()
    {
        LoadNewScene(scene);    
    }

    public static void LoadNewScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public static void LoadNewScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}
