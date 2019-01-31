using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

/// <summary>
/// Used for the two sliders handling the volume options. As both have little differences with each other, only one script was created instead of two. 
/// This class was made to get access to data stored in a persistent singleton created in another scene.
/// This class is given to the object that has access to the data required in the fewest steps possible in the hierarchy.
/// The class inherits from "IPointerUpHandler" to receive events when the mouse button is lifted from the slider.
/// </summary>
public class VolumeSlider : MonoBehaviour, IPointerUpHandler
{
    /// <summary>
    /// Type of the slider object to handle specific data
    /// </summary>
    public enum VolumeType
    {
        Music,
        SFX
    }
    public VolumeType vol_type;

    /// <summary>
    /// Slider object
    /// </summary>
    Slider vol_slider;
    /// <summary>
    /// Text field to show slider value in screen
    /// </summary>
    TextMeshProUGUI value_t;
    /// <summary>
    /// Sound to be played when sfx slider value is changed
    /// </summary>
    AudioSource sfx_effect;
    
	void Start ()
    {
        vol_slider = GetComponent<Slider>();

        // Make sliders display the value given by default
        vol_slider.maxValue = 100.0f;
        switch (vol_type)
        {
            case VolumeType.Music:
                vol_slider.value = AudioMan.Instance.bckgrnd_music_volume * vol_slider.maxValue;
                break;
            case VolumeType.SFX:
                vol_slider.value = AudioMan.Instance.sfx_volume * vol_slider.maxValue;
                break;
            default:
                break;
        }
        vol_slider.onValueChanged.AddListener(ExcuteOnChange);

        value_t = transform.Find("Volume_T").GetComponent<TextMeshProUGUI>();
        value_t.text = Mathf.RoundToInt(vol_slider.value).ToString();

        sfx_effect = GetComponent<AudioSource>();
	}

    /// <summary>
    /// To be executed when Slider "onValueChanged" event is thrown
    /// Change audioman volume value by slider value
    /// </summary>
    /// <param name="n_val"></param>
    void ExcuteOnChange(float n_val)
    {
        switch (vol_type)
        {
            case VolumeType.Music:
                AudioMan.Instance.bckgrnd_music_volume = n_val / vol_slider.maxValue;
                break;
            case VolumeType.SFX:
                AudioMan.Instance.sfx_volume = n_val / vol_slider.maxValue;
                break;
            default:
                break;
        }

        // Print the result
        value_t.text = Mathf.RoundToInt(vol_slider.value).ToString();
    }
    
    /// <summary>
    /// Event thrown when mouse button is lifted from slider.
    /// Play a sound at selected volume to show player feedback of his choice
    /// </summary>
    /// <param name="p_data"></param>
    public void OnPointerUp(PointerEventData p_data)
    {
        // Make sure only the SFX slider will play a sound
        if(vol_type == VolumeType.SFX)
        {
            if(sfx_effect != null)
            {
                sfx_effect.Stop();
                sfx_effect.volume = vol_slider.value / vol_slider.maxValue;
                sfx_effect.Play();
            }
        }
    }
}
