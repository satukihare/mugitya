﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerGUIControl : MonoBehaviour {

    public float RotSpeed;
    // Start is called before the first frame update
    void Start() {
        RotSpeed = 1.0f;
    }

    // Update is called once per frame
    void Update() {

        transform.Rotate(new Vector3(0,0, -RotSpeed * Time.deltaTime));
    }
}
