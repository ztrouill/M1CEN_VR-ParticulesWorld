using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canonscript : MonoBehaviour
{
    public GameObject canonball;
    public float shootforce = 0f;
    public float delaiCreation = 4f;
    public float derniereCreation = 4.1f;
    public int nombreDeTirs = 1;
    public float tempsCreation = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        tempsCreation += Time.deltaTime;
        if(tempsCreation >= delaiCreation && tempsCreation < derniereCreation)
        {
            for (int i=0; i <= nombreDeTirs; i++)
            {
                GameObject projectile = (GameObject)Instantiate(canonball,
                    transform.position, transform.rotation);
                projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * shootforce);
            }
        }
    }
}
