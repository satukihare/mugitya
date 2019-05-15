using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ItemBag : MonoBehaviour
{
    int currentSceneindex;
    private gameMnger gameManager;
    // Start is called before the first frame update
    void Start()
    {
        currentSceneindex = SceneManager.GetActiveScene().buildIndex;
        gameManager = GameObject.Find("gameMnger").GetComponent<gameMnger>();
        if (currentSceneindex == 1)
        {
            SetItemNum(5, 3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetItemNum(int FireNum , int WindNum)
    {
        gameManager.setInstallationNums("fire", FireNum);
        gameManager.setInstallationNums("wind", WindNum);
    }
}


