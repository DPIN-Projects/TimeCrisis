using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player related operations
/// </summary>
public class PlayerController : MonoBehaviour
{
    Transform cam_p;
    Animator anim_p;
    GunController gun_p;

    private void Start()
    {
        cam_p = transform.Find("FirstPersonCharacter");
        anim_p = GetComponent<Animator>();
        gun_p = GetComponent<GunController>();
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

        if (Input.GetMouseButtonDown(0))
        {
            gun_p.FireWeapon();
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
