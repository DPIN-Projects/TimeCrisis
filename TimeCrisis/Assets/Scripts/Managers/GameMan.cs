using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMan : MonoBehaviour
{
    //public static GameMan Instance { get; private set; }

    //private void Awake()
    //{
    //    if (Instance != null)
    //        Instance = this;
    //    else
    //        Destroy(gameObject);
    //}

    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            SceneMan.Instance.LoadSceneByEnum("MainMenu");
        }
    }
}
