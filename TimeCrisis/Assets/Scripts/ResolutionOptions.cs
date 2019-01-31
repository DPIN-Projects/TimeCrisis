using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionOptions : MonoBehaviour
{
    public float width, height;

    Button b_res;

    private void Start()
    {
        b_res = GetComponent<Button>();
        b_res.onClick.AddListener(ApplyResolution);
    }

    void ApplyResolution()
    {
        Debug.Log("change");
        GraphicsMan.Instance.ChangeRes(width, height);
    }
}