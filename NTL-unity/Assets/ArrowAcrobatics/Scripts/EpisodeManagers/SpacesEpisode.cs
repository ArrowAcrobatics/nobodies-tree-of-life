using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class SpacesEpisode : GenericEpisode
{
    private Animator animator;
    private const string AnimActive = "isActive";

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("no animator assigned to spaces scene" + gameObject.name);
        }
    }

    // Episode is launched by the episode manager
    public override void OnLaunch()
    {
        Debug.Log("SpacesEpisode.OnLaunch " + gameObject.name);
        animator.SetBool(AnimActive, true);
        animator.SetFloat("myFloat", 1.23f);
    }

    // Episode is stopped by the episode manager
    public override void OnStop()
    {
        Debug.Log("SpacesEpisode.OnStop " + gameObject.name);
        animator.SetBool(AnimActive, false);
        animator.SetFloat("myFloat", -987.0f);
    }
}
