using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Main menu manager. Created as singleton as only one instance is needed in its scene.
/// Did not grouped with other managers as it should only be accessible in menu scene only.
/// </summary>
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

    //////////////////////////////////////////////////////
    // Menu panels
    public GameObject main_panel;       // Main menu
    public GameObject options_panel;    // Options menu

    //////////////////////////////////////////////////////
    // Animation
    public float to_visible_dur, to_invisible_dur;  // Times of fading animation

    /////////////////////////////////////////////////////////////////////////
    // Load Panels
    /// <summary>
    /// Go to main menu from options menu.
    /// </summary>
    public void LoadMain()
    {
        StartCoroutine(UnDisplay(options_panel));
        StartCoroutine(Display(main_panel));
    }

    /// <summary>
    /// Go to options menu from main menu.
    /// </summary>
    public void LoadOptions()
    {
        StartCoroutine(UnDisplay(main_panel));
        StartCoroutine(Display(options_panel));
    }

    /// <summary>
    /// Load game scene
    /// </summary>
    public void LoadStart()
    {
        SceneMan.Instance.LoadSceneByName("Game");
    }

    /////////////////////////////////////////////////////////////////////////
    // Fading Animations

    /// <summary>
    /// Use to fade in a specified object within a time period
    /// </summary>
    /// <param name="panel"> Object to be faded in</param>
    /// <returns></returns>
    IEnumerator Display(GameObject panel)
    {
        bool do_loop = true;
        float elapsed_time = 0.0f;

        panel.SetActive(true);  // Activate object in the scene
        while (do_loop)
        {
            panel.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(0, 1, elapsed_time / to_visible_dur);
            elapsed_time += Time.deltaTime;

            // End of animation
            if (panel.GetComponent<CanvasGroup>().alpha == 1)
            {
                // Don't allow the object to be interactuable until end of animation
                panel.GetComponent<CanvasGroup>().interactable = true; 
                do_loop = false;
            }

            yield return null;
        }
    }

    /// <summary>
    /// Use to fade out a specified object within a time period from the current alpha value to zero.
    /// </summary>
    /// <param name="panel">Object to be faded out.</param>
    /// <returns></returns>
    IEnumerator UnDisplay(GameObject panel)
    {
        bool do_loop = true;
        float elapsed_time = 0.0f;
        float start_alpha = panel.GetComponent<CanvasGroup>().alpha; // Start with the current alpha value of object in case has not alpha 1

        panel.GetComponent<CanvasGroup>().interactable = false;     // Don't allow object be interactable during animation
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
