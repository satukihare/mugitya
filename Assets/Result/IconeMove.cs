using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class IconeMove : MonoBehaviour
{
    RectTransform rect; //
    public int IconPos; //
    float x;            //IconのX座標
    float y;            //IconのY座標
    public bool b;      //移動回数の制御用

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
        if (x == 0 && y == 0)
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
            if (IconPos > 1)
            {
                IconPos = 0;
            }
            b = true;
        }

        if (IconPos == 0) { rect.localPosition = new Vector3(150, -60, 0); }
        if (IconPos == 1) { rect.localPosition = new Vector3(150, -220, 0); }

        int currentSceneindex = SceneManager.GetActiveScene().buildIndex+1;//現在のシーン番号を取得
        
        Debug.Log(currentSceneindex);
        if (IconPos == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButton("B"))
            {
                Time.timeScale = 1f;
                if (currentSceneindex > 4)
                {
                    gameMnger.setNextSceneNumber(currentSceneindex);
                    FadeManager.FadeOut(5);
                }
                else
                {
                    gameMnger.setNextSceneNumber(currentSceneindex);
                    FadeManager.FadeOut(5);//現在のシーン番号を取得＋１(次のステージにFade)
                }
            }
        }

        if (IconPos == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButton("B"))
            {
                Time.timeScale = 1f;
                gameMnger.setNextSceneNumber(currentSceneindex);
                FadeManager.FadeOut(5);
            }
        }
    }
}
