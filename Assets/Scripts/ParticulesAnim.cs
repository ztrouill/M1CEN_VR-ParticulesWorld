using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticulesAnim : MonoBehaviour
{
    private ParticulesSound sound;
    private Pose pose;
    private Text[] timerText;
    private GameObject head;
    private GameObject particules;
    private Viseur viseur;
    private float currentTime = 0f;
    private bool play = false;

    // Start is called before the first frame update
    void Start()
    {
        viseur = GameObject.Find("Viseurs").GetComponent<Viseur>();  
        sound = GameObject.Find("Sounds").GetComponent<ParticulesSound>();
        pose = gameObject.transform.GetChild(1).gameObject.GetComponent<Pose>();
        head = GameObject.Find("Head");
        LaunchAnimation();
    }

    // Update is called once per frame
    void Update()
    {
        if (play) {
            currentTime += Time.deltaTime;
            if (currentTime >= sound.duration)
                Reset();
        }
    }

    public void LaunchAnimation()
    {
        Transform parent = gameObject.transform.parent;
        sound = GameObject.Find("Sounds").GetComponent<ParticulesSound>();
        particules = gameObject.transform.GetChild(0).gameObject;

        DisableOthersParticules();
        sound.AddParticuleAudio(gameObject.transform.name);
        particules.SetActive(true);
        if (gameObject.transform.name == "Rain")
            ResetRain();
        currentTime = 0;
        play = true;
    }

    void Reset()
    {
        pose.FadeIn();
        particules.SetActive(false);
        viseur.ResetTimer();
        viseur.FadeIn();
        head.transform.GetChild(0).gameObject.GetComponent<RaycastDetection>().enabled = true;
        EnableParticules();
        sound.RemoveParticuleAudio();
        play = false;
        Destroy(this);
    }
    
    void EnableParticules()
    {
        Transform allParticules = GameObject.Find("All_Particules").transform;

        for (var i = 0; i < allParticules.childCount; i++)
        {
            if (allParticules.GetChild(i).name == "Vortex")
                ResetVortex(allParticules.GetChild(i).gameObject);
            allParticules.GetChild(i).gameObject.SetActive(true);
        }       
    }

    void DisableOthersParticules()
    {
        Transform allParticules = GameObject.Find("All_Particules").transform;

        for (var i = 0; i < allParticules.childCount; i++)
        {
            if (allParticules.GetChild(i).gameObject != gameObject)
                allParticules.GetChild(i).gameObject.SetActive(false);
        }
    }

    void RemovePose(Transform pose, Transform parent)
    {
        Animator poseAnim = pose.gameObject.GetComponent<Animator>();

        poseAnim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("AnimationTransition/PoseFadeOut");
        if (parent.name == "Vortex")
            pose.GetChild(0).gameObject.SetActive(false);
    }

    void FadeIn()
    {
        Animator animator = particules.GetComponent<Animator>();
        animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("AnimationTransition/PoseFadeOut");
    }

    void ResetVortex(GameObject vortex)
    {
        vortex.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
    }

    void ResetRain()
    {
        Canonscript canon = GameObject.Find("Declencheur-tir-particules").GetComponent<Canonscript>();

        canon.tempsCreation = 0;
    }
}
