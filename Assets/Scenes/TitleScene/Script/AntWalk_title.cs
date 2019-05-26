using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntWalk_title : MonoBehaviour
{
    float Movespeed;
    Vector3 TargetPos;
    // Start is called before the first frame update
    void Start()
    {
        Movespeed = 0.05f;
        TargetPos = this.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        this.transform.position = new Vector3(this.transform.position.x + TargetPos.x * Movespeed,
                                              this.transform.position.y + TargetPos.y * Movespeed,
                                              this.transform.position.z + TargetPos.z * Movespeed);

        if(this.transform.position.z<=5)
        {
            this.transform.position = new Vector3(this.transform.position.x,
                                                  this.transform.position.y,
                                                  40);
        }
    }
}
