using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayView : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // ターゲットオブジェクトとの差分を求め
        Vector3 RayPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Vector3 RayTargetPos = new Vector3(Target.transform.position.x, Target.transform.position.y, Target.transform.position.z);
        Vector3 temp = RayTargetPos - RayPos;
        Ray ray = new Ray(RayPos, temp);

        Debug.DrawRay(RayPos, temp, Color.black);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            
        }


        
    }
}
