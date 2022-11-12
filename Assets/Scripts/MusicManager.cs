using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private int num;
    public AudioClip Track1; //<---drag mp3 into the inspector here
    public AudioClip Track2;
    public AudioClip Track3; //<---drag  mp3#2 into the inspector here
    private AudioSource audio;
    

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        int nume = Random.Range(1, 4);
        Debug.Log("Track n°" + nume); 
        num = nume;
        musicKicksin();
    }

    void musicKicksin()
    {
        if (num == 1)
        {
            audio.clip = Track1;
            audio.Play();
        }
        if (num == 2)
        {
            audio.clip = Track2;
            audio.Play();
        }
        if (num == 3)
        {
            audio.clip = Track3;
            audio.Play();
        }
        else
        {
            Debug.Log("Nope");  
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
