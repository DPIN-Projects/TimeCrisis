using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Transform player_cam;
    Animator anim_p;

    private void Start()
    {
        player_cam = transform.Find("FirstPersonCharacter");
        anim_p = GetComponent<Animator>();
    }

    private void Update()
    {
        
        if(Input.GetKey(KeyCode.Space))
        {
            Crouch();
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            Stand();
        }
    }

    void Crouch()
    {
        anim_p.SetBool("IsCrouch", true);
    }

    void Stand()
    {
        anim_p.SetBool("IsCrouch", false);
    }
}
