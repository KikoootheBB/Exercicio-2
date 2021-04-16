using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Capataz : MonoBehaviour
{
    private Manfios comportamento;
    public UnityEvent AlertOthers;
    private List<Patrolheiro> manfiosQuetos;
    void Start()
    {
        comportamento = GetComponent<Manfios>();
        AlertOthers = new UnityEvent();
        manfiosQuetos = FindObjectsOfType<Patrolheiro>().ToList();
        foreach (var enemy in manfiosQuetos)
        {
            AlertOthers.AddListener(enemy.AwareOfPlayer);
        }
    }

    void Update()
    {
        if (comportamento.PlayerDetected)
        {
            AlarmAll();
        }
    }

    void AlarmAll()
    {
        AlertOthers.Invoke();
    }
}
