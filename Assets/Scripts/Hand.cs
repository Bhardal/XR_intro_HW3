using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Hand : MonoBehaviour
{
    // Animation stuff
    public float animationSpeed;
    Animator animator;
    SkinnedMeshRenderer mesh;
    private float gripTarget;
    private float triggerTarget;
    private float pressTarget;
    private float gripCurrent;
    private float triggerCurrent;
    private float pressCurrent;
    private string animatorGripParam = "Grip";
    private string animatorTriggerParam = "Trigger";
    private string animatorPressParam = "Press";

    void Start()
    {
        // Animation stuff
        animator = GetComponent<Animator>();
        mesh = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    void Update()
    {
        AnimateHand();
    }

    internal void SetGrip(float v)
    {
        gripTarget = v;
    }

    internal void SetTrigger(float v)
    {
        triggerTarget = v;
    }

    internal void SetPress(float v)
    {
        pressTarget = v;
    }

    void AnimateHand()
    {
        if (gripCurrent != gripTarget)
        {
            gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime * animationSpeed);
            animator.SetFloat(animatorGripParam, gripCurrent);
        }
        if (triggerCurrent != triggerTarget)
        {
            triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime * animationSpeed);
            animator.SetFloat(animatorTriggerParam, triggerCurrent);
        }
        if (pressCurrent != pressTarget)
        {
            pressCurrent = Mathf.MoveTowards(pressCurrent, pressTarget, Time.deltaTime * animationSpeed);
            animator.SetFloat(animatorPressParam, pressCurrent);
        }
    }

//     public void ToggleVisibility()
//     {
//         mesh.enabled = !mesh.enabled;
//     }
}
