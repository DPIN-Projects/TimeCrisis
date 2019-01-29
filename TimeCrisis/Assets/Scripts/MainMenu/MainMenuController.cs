using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    //////////////////////////////////////////////////////
    // Singleton architecture
    public static MainMenuController Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    /*******************************************************
    *  Variables                                           *
    *******************************************************/

    //////////////////////////////////////////////////////
    // Menu panels
    public GameObject main_panel;
    public GameObject options_panel;

    //////////////////////////////////////////////////////
    // Animation
    public float to_visible_dur, to_invisible_dur;

    /*******************************************************
    *  Functions                                           *
    *******************************************************/

    /////////////////////////////////////////////////////////////////////////
    // Load Panels
    public void LoadMain()
    {
        StartCoroutine(UnDisplay(options_panel));
        StartCoroutine(Display(main_panel));
    }

    public void LoadOptions()
    {
        StartCoroutine(UnDisplay(main_panel));
        StartCoroutine(Display(options_panel));
    }

    public void LoadStart()
    {
        SceneMan.Instance.LoadSceneByName("Game");
    }

    /////////////////////////////////////////////////////////////////////////
    // Fading Animations
    IEnumerator Display(GameObject panel)
    {
        bool do_loop = true;
        float elapsed_time = 0.0001f;

        panel.SetActive(true);
        while (do_loop)
        {
            panel.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(0, 1, elapsed_time / to_visible_dur);

            elapsed_time += Time.deltaTime;

            if (panel.GetComponent<CanvasGroup>().alpha == 1)
            {
                panel.GetComponent<CanvasGroup>().interactable = true;
                do_loop = false;
            }

            yield return null;
        }
    }

    IEnumerator UnDisplay(GameObject panel)
    {
        bool do_loop = true;
        float elapsed_time = 0.0f;
        float start_alpha = panel.GetComponent<CanvasGroup>().alpha;

        panel.GetComponent<CanvasGroup>().interactable = false;
        while (do_loop)
        {
            panel.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(start_alpha, 0, elapsed_time / to_invisible_dur);

            elapsed_time += Time.deltaTime;

            if (panel.GetComponent<CanvasGroup>().alpha == 0)
            {
                panel.SetActive(false);
                do_loop = false;
            }

            yield return null;
        }
    }
}
