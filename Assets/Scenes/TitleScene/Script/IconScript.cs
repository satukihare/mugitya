using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class IconScript : MonoBehaviour
{
    RectTransform rect;
    public int IconPos;

    // Start is called before the first frame update
    void Start()
    {
        IconPos = 0;
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            IconPos--;
            if (IconPos < 0)
            {
                IconPos = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            IconPos++;
            if(IconPos>1)
            {
                IconPos = 0;
            }
        }

        if (IconPos == 0) { rect.localPosition = new Vector3(-130, -35, 0); }
        if (IconPos == 1) { rect.localPosition = new Vector3(-130, -90, 0); }

        if (IconPos == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Game");
            }
        }

    }
}
