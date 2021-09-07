using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastDetection : MonoBehaviour
{
    private Vector3 collision = Vector3.zero;
    private ParticulesSound sound;
    private Viseur viseur;
    private float time = 4f;
    private bool reset = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject viseurs = GameObject.Find("Viseurs");
        sound = GameObject.Find("Sounds").GetComponent<ParticulesSound>();
        viseur = viseurs.GetComponent<Viseur>();
    }

    // Update is called once per frame
    void Update()
    {
        var ray = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            collision = hit.point;
            if (time > 0) {
                time -= Time.deltaTime;
                if (time < 0)
                {
                    viseur.HideTimer();
                    StartCoroutine(SetAnimation(hit)); 
                }
                else
                    viseur.DisplayTime(time);
                    
            }
            reset = false;
        }
        else
        {
            time = 4f;
            viseur.ResetTimer();
        }
    }

    IEnumerator SetAnimation(RaycastHit hit)
    {
        GameObject parent = hit.transform.parent.transform.gameObject;
        GameObject particule = parent.transform.GetChild(0).gameObject;
        Pose pose = hit.transform.gameObject.GetComponent<Pose>();
        ParticulesAnim animParticule = null;

        pose.RemovePose(hit.transform, parent.transform);

        yield return new WaitForSeconds(3);
        
        viseur.RemoveAnimation();
        parent.AddComponent<ParticulesAnim>();
        animParticule = parent.GetComponent<ParticulesAnim>();

        animParticule.LaunchAnimation();
        this.enabled = false;
    }
}