using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour
{
    //////////////////////////////////////////////////////
    // Singleton architecture
    public static SceneMan Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //////////////////////////////////////////////////////
    // Scene Handling

    public void LoadSceneByName(string scene_name)
    {
        if (SceneManager.GetSceneByName(scene_name) != null)
            SceneManager.LoadScene(scene_name);
        else
            Debug.Log("Could not load " + scene_name + " scene.");
    }

    void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
