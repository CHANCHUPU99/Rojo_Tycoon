using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;

    public AudioSource audioSourceTwo;
    public AudioClip clipTwo;
    // Start is called before the first frame update

   /* public void Awake()
    {
        PlaySound();
    }*/
    void Start()
    {
        audioSource.clip=clip;
        audioSourceTwo.clip = clipTwo;
    }

    public void PlaySound()
    {
        audioSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
