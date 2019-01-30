using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class VolumeSlider : MonoBehaviour, IPointerUpHandler
{
    public enum VolumeType
    {
        Music,
        SFX
    }
    public VolumeType vol_type;

    Slider vol_slider;
    TextMeshProUGUI value_t;

    AudioSource sfx_effect;
    
	void Start ()
    {
        vol_slider = GetComponent<Slider>();
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


        value_t.text = Mathf.RoundToInt(vol_slider.value).ToString();
    }
    

    public void OnPointerUp(PointerEventData p_data)
    {
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
