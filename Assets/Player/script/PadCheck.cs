using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadCheck : MonoBehaviour {
    private KeyBoardMove KeyboardScript;
    private move MoveScript;
    // Start is called before the first frame update
    void Start() {
        KeyboardScript = this.GetComponentInChildren<KeyBoardMove>();
        MoveScript = this.GetComponentInChildren<move>();
    }

    // Update is called once per frame
    void Update() {
        var controllerNames = Input.GetJoystickNames();

        // 一台もコントローラが接続されていなければエラー
        if(controllerNames.Length == 0) {
           KeyboardScript.enabled = true;
            MoveScript.enabled = false;
        }
        else {
            KeyboardScript.enabled = false;
            MoveScript.enabled = true;
        }
        
    }
}
