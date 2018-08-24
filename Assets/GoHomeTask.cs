using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using UnityEngine.AI;

public class GoHomeTask : ActionTask {

    public BBParameter<GameObject> Cleaner;
    public BBParameter<NavMeshAgent> navMesh;
    public BBParameter<SteeringArrive> steer;
    public BBParameter<Animator> m_animator;
	public BBParameter<GameObject> GoHome;
   
    // Use this for initialization
    protected override void OnExecute()
    {

            NavMeshPath goHomePath = new NavMeshPath();
			navMesh.value.CalculatePath(GoHome.value.transform.position, goHomePath);
            Vector3[] pathCorners = new Vector3[goHomePath.corners.Length];
            goHomePath.corners.CopyTo(pathCorners, 0);
            steer.value.SetPathCorners(pathCorners);
        
        
    }

    // Update is called once per frame
    protected override void OnUpdate()
    {
		float distance2 = (GoHome.value.transform.position - Cleaner.value.transform.position).magnitude;
        if (distance2 <= 1.0f)
        {            
            m_animator.value.SetBool("movement", false);
			EndAction(false);
        }
        
    }
}
