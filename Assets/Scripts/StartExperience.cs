using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartExperience : MonoBehaviour
{
    private GameObject startText;
    private GameObject viseurs;
    private GameObject particules;
    private GameObject head;

    // Start is called before the first frame update
    void Start()
    {
        startText = GameObject.Find("Start_Text");
        viseurs = GameObject.Find("Viseurs");
        particules = GameObject.Find("All_Particules");
        head = GameObject.Find("Head");

        startText.SetActive(true);
        particules.SetActive(false);
        viseurs.SetActive(false);
        StartCoroutine(PlayExperience());
    }

    IEnumerator PlayExperience()
    {
        yield return new WaitForSeconds(5);

        viseurs.SetActive(true);
        particules.SetActive(true);
        startText.SetActive(false);

        AddViseursScript();
        AddPoseParticulesScript();
        head.transform.GetChild(0).gameObject.AddComponent<RaycastDetection>();
    }

    void AddPoseParticulesScript()
    {
        GameObject[] particules = GameObject.FindGameObjectsWithTag("Particules");

        foreach (GameObject particule in particules)
        {
            GameObject pose = particule.transform.GetChild(1).gameObject;
            pose.AddComponent<Pose>();    
        }
    }

    void AddViseursScript()
    {
        GameObject viseurs = GameObject.Find("Viseurs");
       
        viseurs.AddComponent<Viseur>();
    }
}
