using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSearchMark : MonoBehaviour
{
    private Transform Mark;
    bool IsUseMark;
    int Timer;
    // Start is called before the first frame update
    void Start()
    {
        Timer = 0;
        IsUseMark = false;
        Mark= this.transform.Find("SearchMark");
    }

    // Update is called once per frame
    void Update()
    {
        if(IsUseMark==true)
        {
            Timer++;
        }
        if(Timer>=120)
        {
            Timer = 0;
            IsUseMark = false;
            Mark.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="fire" && IsUseMark==false)
        {
            IsUseMark = true;
            Mark.gameObject.SetActive(true);
        }
    }
}
