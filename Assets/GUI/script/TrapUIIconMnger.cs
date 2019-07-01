using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapUIIconMnger : MonoBehaviour {

    public int target_trap_num = 1;

    [SerializeField] TrapUIImageControl fire_obj;
    [SerializeField] TrapUIImageControl wind_obj;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.X))
            target_trap_num = 1;

        if (Input.GetKey(KeyCode.Z))
            target_trap_num = 2;

        if (target_trap_num == 1) {
            fire_obj.target_ui_icon = 1;
            wind_obj.target_ui_icon = 0;
        }

        if (target_trap_num == 2) {
            fire_obj.target_ui_icon = 0;
            wind_obj.target_ui_icon = 1;
        }
    }
}
