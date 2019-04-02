using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManagerController : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        HandleButtonInputs();
    }

    /*
    * Handles Unity's Button Inputs. 
    * This will need to be configure for every game.
     */
    private void HandleButtonInputs()
    {
        if(Input.GetButtonDown("Escape")){
            Application.Quit();
        }
    }
}
