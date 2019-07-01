using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class back_light_img_script : MonoBehaviour {

    [SerializeField] GameObject cursor_obj;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        Vector2 pos = transform.position;
        transform.position = new Vector2(pos.x, cursor_obj.transform.position.y);
    }
}
