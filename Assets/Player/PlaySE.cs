using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySE : MonoBehaviour
{

    public AudioClip sound1;
    public AudioClip sound2;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("B") || Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(sound1);
        }
        if (Input.GetButtonDown("R1") || Input.GetKeyDown(KeyCode.P))
        {
            audioSource.PlayOneShot(sound2);
        }
        if (Input.GetButtonDown("L1") || Input.GetKeyDown(KeyCode.O))
        {
            audioSource.PlayOneShot(sound2);
        }
    }
}
