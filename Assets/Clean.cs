using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using UnityEngine.AI;
public class Clean : ActionTask {

    public BBParameter<GameObject> Cleaner;    
    public BBParameter<NavMeshAgent> Path;
    public BBParameter<GameObject> Closest;
    public BBParameter<SteeringArrive> seek;
    public BBParameter<Animator> m_animator;
    

    // Use this for initialization

    private float distance = 1000.0f;
    private bool calc = false;
    private float CleanTime = 3.0f;

    protected override void OnExecute()
    {
        
            NavMeshPath rubbishPath = new NavMeshPath();
            Path.value.CalculatePath(Closest.value.transform.position, rubbishPath);
            Vector3[] pathCorners = new Vector3[rubbishPath.corners.Length];
            rubbishPath.corners.CopyTo(pathCorners, 0);
            seek.value.SetPathCorners(pathCorners);
        

    }


    // Update is called once per frame
    protected override void OnUpdate()
    {
        float distance = (Closest.value.transform.position - Cleaner.value.transform.position).magnitude;
        if (distance <= 2.0f)
        {
            m_animator.value.SetBool("clean", true); 
            
            
            EndAction(true);             
            
        }
        else
        {
            m_animator.value.SetBool("clean", false);
            m_animator.value.SetBool("movement", true);
            
        }
    }
}
      
 
