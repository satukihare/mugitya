using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class FollewPlayer : MonoBehaviour
{
    private NavMeshAgent Agent;
    // 追いかけるキャラクター
    [SerializeField] private GameObject Player;
    [SerializeField] private Animator Animator;
    //　到着したとする距離
    [SerializeField]private float ArrivedDistance = 0.5f;
    //　追いかけ始める距離
    [SerializeField]private float FollowDistance = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Agent.SetDestination(Player.transform.position);

        //　到着していない時
        if (Agent.remainingDistance < ArrivedDistance)
        {
            Agent.Stop();
            //　Unity5.6バージョン以降の停止
            //			agent.isStopped = true;
            Animator.SetFloat("Speed", 0f);
            //　到着している時
        }
        else if (Agent.remainingDistance > FollowDistance)
        {
            Agent.Resume();
            //　Unity5.6バージョン以降の再開
            //			agent.isStopped = false;
            Animator.SetFloat("Speed", Agent.desiredVelocity.magnitude);
        }
    }


    void OnAnimatorIK()
    {

        var weight = Vector3.Dot(transform.forward, Player.transform.position - transform.position);

        if (weight < 0)
        {
            weight = 0;
        }
        Animator.SetLookAtWeight(weight, 0f, 1f, 0f, 0f);
        Animator.SetLookAtPosition(Player.transform.position + Vector3.up * 1.5f);
    }
}
