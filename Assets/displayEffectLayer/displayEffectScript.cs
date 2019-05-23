using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayEffectScript : MonoBehaviour {

    public Camera camera = null;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        Vector3 camera_pos = camera.transform.position;

        transform.position = new Vector3(camera_pos.x, 15, camera_pos.z);

    }
}
