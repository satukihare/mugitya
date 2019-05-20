using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_obj_child : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

        this.transform.localScale = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update() {

        Vector3 temp = transform.position;
        transform.position = new Vector3(temp.x, temp.y, temp.z + 0.02f);
    }
}
