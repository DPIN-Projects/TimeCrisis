using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevPreLoad : MonoBehaviour
{
    private void Awake()
    {
        GameObject check = GameObject.Find("__app");

        if(check == null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Preload");
        }
    }
}
