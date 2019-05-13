using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindVector : MonoBehaviour
{
    private ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        particle = this.GetComponent<ParticleSystem>();
        //パーティクルスピード(風の強弱に従って調整)
        particle.startSpeed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
