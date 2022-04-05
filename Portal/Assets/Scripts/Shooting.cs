using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    private Image Aim;
    private UserInput PlayerInput;

    void Awake()
    {
        Aim = GetComponent<Image>();
        Aim.enabled = false;
        PlayerInput = Aim.transform.parent.parent.parent.parent.parent.GetComponent<UserInput>();
    }

    void Update()
    {
        if (PlayerInput.aiming)
        {
            Aim.enabled = true;
        }
        else
        {
            Aim.enabled = false;
        }
    }
}
