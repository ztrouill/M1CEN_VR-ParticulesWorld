using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pose : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.AddComponent<Animator>();
        animator.runtimeAnimatorController = null;
        animator.enabled = true;
    }

    public void FadeIn()
    {
        gameObject.SetActive(true);
        animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("AnimationTransition/PoseFadeIn");
    }

    public void RemovePose(Transform pose, Transform parent)
    {
        Animator poseAnim = pose.gameObject.GetComponent<Animator>();

        poseAnim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("AnimationTransition/PoseFadeOut");
        if (parent.name == "Vortex")
            pose.GetChild(0).gameObject.SetActive(false);
    }
}