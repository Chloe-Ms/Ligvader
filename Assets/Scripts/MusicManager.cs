using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private int num;
    [SerializeField] private int TrackNumber = 3;
    public AudioClip Track1; //<---drag mp3 into the inspector here
    public AudioClip Track2;
    public AudioClip Track3; //<---drag  mp3#2 into the inspector here
    private AudioSource audio;
    [SerializeField] List<AudioClip> _SoundTracks;




    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        TrackNumber += 1;
        musicRandom();
    }

    void musicRandom()
    {
        int nume = Random.Range(1, TrackNumber);
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
            Debug.Log("Je trouve pas la track man");
        }
    }
}