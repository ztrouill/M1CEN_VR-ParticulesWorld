using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticulesSound : MonoBehaviour
{
    public float duration;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddParticuleAudio(string source)
    {
        GameObject audioSource = new GameObject();
        AudioSource sound = audioSource.AddComponent<AudioSource>();

        audioSource.name = "SoundParticule";
        sound.clip = Resources.Load<AudioClip>($"Sounds/{source}");
        sound.loop = false;
        audioSource.transform.parent = this.transform;
        sound.Play();
        duration = sound.clip.length;
    }

    public void RemoveParticuleAudio()
    {
        Destroy(GameObject.Find("SoundParticule"));
    }  
}
