using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadingFlower : MonoBehaviour {

    [SerializeField] float angele_num = 0.1f;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        angele_num += 0.1f;

        Vector3 axis = new Vector3(0f, 0f, 1f); // 回転軸
        float angle = 90f * Time.deltaTime; // 回転の角度
        Quaternion q = Quaternion.AngleAxis(angle, axis);

        transform.rotation = q * this.transform.rotation;//new Quaternion(angele_num, 0f, 0f, 0f);
    }
}