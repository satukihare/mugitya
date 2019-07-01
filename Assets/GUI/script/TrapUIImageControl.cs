using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrapUIImageControl : MonoBehaviour {

    [SerializeField] Sprite on_img;
    [SerializeField] Sprite off_img;
    public int target_ui_icon = 0;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {

        Image image_component = this.GetComponent<Image>();
        
        if (target_ui_icon == 0)
            image_component.sprite = off_img;
        if (target_ui_icon == 1)
            image_component.sprite = on_img;

    }
}