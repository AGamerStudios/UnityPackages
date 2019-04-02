using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputAnimationController : MonoBehaviour
{
    public bool isHovering = false;
    public bool isShaking = false;
    public string value = " ";
    private TMP_Text valueText;
    private Animator animator;
    private Vector3 startPosition;
    private Quaternion startRotation;

    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
        animator = GetComponent<Animator>();
        valueText = GetComponentInChildren<TMP_Text>();
        valueText.text = value;
    }

    void Update()
    {
        UpdateAnimatorBools();
        
        if (isHovering)
        {
            isShaking = false;
        }
        if (isShaking)
        {
            isHovering = false;
        }

        if (!animator.GetBool("IsShaking"))
        {
            ResetEntityRotation();
        }
    }

    private void UpdateAnimatorBools()
    {
        animator.SetBool("IsHovering", isHovering);
        animator.SetBool("IsShaking", isShaking);
    }

    private void ResetEntityRotation()
    {
        transform.rotation = startRotation;
    }
}
