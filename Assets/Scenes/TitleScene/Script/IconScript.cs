using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class IconScript : MonoBehaviour
{
    RectTransform rect; //
    public int IconPos; //
    float x;            //IconのX座標
    float y;            //IconのY座標
    bool b;             //移動回数の制御用

    // Start is called before the first frame update
    void Start()
    {
        IconPos = 0;
        b = false;
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical") * -1.0f;
        if(x==0 && y==0)
        {
            b = false;
        }
        if (Input.GetKeyDown(KeyCode.W) || y >= 1.0f && b == false)
        {
            IconPos--;
            if (IconPos < 0)
            {
                IconPos = 1;
            }
            b = true;
        }
        if (Input.GetKeyDown(KeyCode.S) || y <= -1.0f && b == false)
        {
            IconPos++;
            if(IconPos>1)
            {
                IconPos = 0;
            }
            b = true;
        }

        if (IconPos == 0) { rect.localPosition = new Vector3(-130, -35, 0); }
        if (IconPos == 1) { rect.localPosition = new Vector3(-130, -90, 0); }

        if (IconPos == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButton("B"))
            {
                FadeManager.FadeOut(1);  
            }
        }

    }
}
