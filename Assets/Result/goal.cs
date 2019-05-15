using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
    [SerializeField]
    //　ポーズした時に表示するUIのプレハブ
    private GameObject pauseUIPrefab;
    //　ポーズUIのインスタンス
    private GameObject pauseUIInstance;
    int goal_bee;
    // Start is called before the first frame update
    void Start()
    {
        goal_bee = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="bee")
        {
            pauseUIInstance = GameObject.Instantiate(pauseUIPrefab) as GameObject;
            GameObject.Find("gameUI").SetActive(false);
            Time.timeScale = 0f;
        }
    }
}
