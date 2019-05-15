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
    public int goal_ant;
    public int goal_bee;
    public int goal_spider;
    // Start is called before the first frame update
    void Start()
    {
        goal_ant = 0;
        goal_bee = 0;
        goal_spider = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bee")
        {
            goal_bee++;
            pauseUIInstance = GameObject.Instantiate(pauseUIPrefab) as GameObject;
            GameObject.Find("gameUI").SetActive(false);
            Time.timeScale = 0f;
        }
        if (collision.gameObject.tag == "ant")
        {
            goal_bee++;
            pauseUIInstance = GameObject.Instantiate(pauseUIPrefab) as GameObject;
            GameObject.Find("gameUI").SetActive(false);
            Time.timeScale = 0f;
        }
        if (collision.gameObject.tag == "spider")
        {
            goal_bee++;
            pauseUIInstance = GameObject.Instantiate(pauseUIPrefab) as GameObject;
            GameObject.Find("gameUI").SetActive(false);
            Time.timeScale = 0f;
        }
    }
}
