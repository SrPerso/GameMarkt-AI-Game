using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using UnityEngine.AI;

public class GoSteal : ActionTask {

    public BBParameter<GameObject> Robber;
    public BBParameter<GameObject> GameToSteal;
    public BBParameter<NavMeshAgent> Mesh;
    public BBParameter<SteeringArrive> steer;
    public BBParameter<Animator> m_animator;
    public BBParameter<Move> Move;
   

    //private float TimeSteal=5.0f;
    protected override void OnExecute()
    {
              
        NavMeshPath StealPath = new NavMeshPath();
        Mesh.value.CalculatePath(GameToSteal.value.transform.position, StealPath);
        Vector3[] path = new Vector3[StealPath.corners.Length];
        StealPath.corners.CopyTo(path, 0);
        steer.value.SetPathCorners(path);
    }           

    // Update is called once per frame

    protected override void OnUpdate()
    {
        float distance2 = (GameToSteal.value.transform.position - Robber.value.transform.position).magnitude;
        if (distance2 <= 2.0f)
        {
            float RandNUm = Random.Range(0, 2);
            if (RandNUm == 0)
            {
                m_animator.value.SetBool("Arrive", false);
                m_animator.value.SetBool("Steal", true);
                Move.value.max_mov_velocity = 3.0f;
                Robber.value.tag = ("Robber");
                
            }

            EndAction(true);
        }
    }
}
