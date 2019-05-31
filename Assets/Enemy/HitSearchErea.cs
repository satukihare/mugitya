using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSearchErea : MonoBehaviour
{
    private bool bInErea;                   //中に入っている際
    private bool bTouchErea;                //触れた際
    [SerializeField] string[] nameStr;      //タグの配列
    string tagName;
    Vector3 pos;

    void Start()
    {
        bInErea = false;
        bTouchErea = false;
    }
    

    void Update()
    {

    }

    // 情報を親へ渡すためのGetter
    public bool getEreaEnable()
    {
        if(!bInErea && bTouchErea)
        {
            bInErea = true;
            return bTouchErea;
        }
        return false;
    }

    public bool getInErea()
    {
        return bInErea;
        
    }
    
    //　エリアに侵入
    private void OnTriggerEnter(Collider other)
    {
        foreach (string _name in nameStr)
        {
            if (other.tag == _name)
            {
                bTouchErea = true;
                tagName = _name;
                pos = other.ClosestPointOnBounds(this.transform.position);
                return;
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        
    }

    //エリアから脱出
    private void OnTriggerExit(Collider other)
    {
        bTouchErea = false;
        bInErea = false;
    }

    public string getTagName()
    {
        if(bTouchErea)
        {
            return tagName;
        }
        return "Noting";
    }

    public Vector3 getHitPos()
    {
        return pos;
    }
}
