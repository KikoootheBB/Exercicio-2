using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Panda;
using UnityEngine.AI;

public class Patrolheiro : MonoBehaviour
{
    private Manfios comportamento;
    private List<Capataz> capatazes;
    private Transform pTransform;
    public Transform[] locations;
    public NavMeshAgent agent;

    void Start()
    {
        comportamento = GetComponent<Manfios>();
        pTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

   
    public void AwareOfPlayer()
    {
        comportamento.GlobalDetection = true;
        comportamento.Alerted = true;
        comportamento.ultimaPlayerPos = pTransform.position;
    }
    [Task] 
    void MoveTo(int locationIndex)
    {
        if (Task.current.isStarting)
        {
            agent.destination = locations[locationIndex].position;
        }
        else
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            Task.current.Succeed();
        }
    }
}
 
