using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class double_speed_script : MonoBehaviour {

    //倍速テクスチャ
    [ SerializeField ] Sprite x1_speed_img;
    [ SerializeField ] Sprite x2_speed_img;
    [ SerializeField ] Sprite x3_speed_img;
    [SerializeField] int target_speed_num = 1;


    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {

        float time = Time.timeScale;
        if ((int)time == (int)1) target_speed_num = 1;
        if ((int)time == (int)2) target_speed_num = 2;
        if ((int)time == (int)3) target_speed_num = 3;

        Image image_component = this.GetComponent<Image>();
        

        switch (target_speed_num) {
            case 1:
                image_component.sprite = x1_speed_img;
                break;
            case 2:
                image_component.sprite = x2_speed_img;
                break;

            case 3:
                image_component.sprite = x3_speed_img;
                break;
            default:
                image_component.sprite = x1_speed_img;
                target_speed_num = 1;
                break;
        }

    }
}
