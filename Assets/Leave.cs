using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using UnityEngine.AI;

public class Leave : ActionTask
{

    public BBParameter<GameObject> Robber;
    public BBParameter<GameObject> leave;
    public BBParameter<NavMeshAgent> Mesh;
    public BBParameter<SteeringArrive> steer;
    public BBParameter<Animator> m_animator;
    public BBParameter<Money> Money;

    // Use this for initialization
    protected override void OnExecute()
    {
       
        NavMeshPath StealPath = new NavMeshPath();
        Mesh.value.CalculatePath(leave.value.transform.position, StealPath);
        Vector3[] path = new Vector3[StealPath.corners.Length];
        StealPath.corners.CopyTo(path, 0);
        steer.value.SetPathCorners(path);

    }
    protected override void OnUpdate()
    {
        float distance2 = (leave.value.transform.position - Robber.value.transform.position).magnitude;
        if (distance2 <= 2.0f)
        {
            if (Robber.value.tag == "Robber")
            {
                Money.value.SubtractMoney(50.0f);
            }
            
            EndAction(true);
        }
    }
}
