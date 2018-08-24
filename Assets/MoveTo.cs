using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using UnityEngine.AI;

public class WanderTask : ActionTask {

    // Use this for initialization
    public BBParameter<GameObject> Police;
    public BBParameter<NavMeshAgent> NavMesh;  
    public BBParameter<Animator> m_animator;
    public BBParameter<float> max_move_velocity;  
    public BBParameter<SteeringArrive> steer;
    public BBParameter<Move> Move;
    private bool calc;
    private Vector3 newPosition = Vector3.zero;
    private float radius = 1.0f;
  

    protected override void OnExecute()
    {
        calc = false;

    }

    // Update is called once per frame
    protected override void OnUpdate()
    {
        
            m_animator.value.SetBool("Followig", false);
            m_animator.value.SetBool("moving", true);
            max_move_velocity.value = 1.5f;
       // if (Chasing.value==false)
        //{
            if (calc == false)
            {
                Move.value.max_mov_velocity = 1.5f;
                newPosition = Random.insideUnitSphere;
                newPosition *= radius * 15;
                newPosition += Police.value.transform.position;
                newPosition.y = Police.value.transform.position.y;               
                NavMeshPath policePath = new NavMeshPath();
                NavMesh.value.CalculatePath(newPosition, policePath);
                if (policePath.corners.Length >= 1)
                {
                    Vector3[] pathCorners = new Vector3[policePath.corners.Length];
                    policePath.corners.CopyTo(pathCorners, 0);                   
                    steer.value.SetPathCorners(pathCorners);                    
                    calc = true;
                    
                }

            }
            float distance2 = (newPosition - Police.value.transform.position).magnitude;
            if (distance2 <= 3.0f)
            {
                calc = false;
                
            }
       // }
       
       
    }
}
