using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeLeaf : MonoBehaviour {

    Color32 alphaZero = new Color32(0xff, 0xff, 0xff, 0x00);
    Color32 alphaOne = new Color32(0xff, 0xff, 0xff, 0xff);
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void NoImage() {
        this.gameObject.SetActive(false);
    }
}
