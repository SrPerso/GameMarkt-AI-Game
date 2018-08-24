using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PoliceBehaviour : MonoBehaviour
{

    Move move;
    SteeringArrive seek;
    SteeringSeek steer;
    public Animator m_animator;
    public NavMeshAgent police;
    public float distance;  
    //Wander
    private float radius = 1.0f;
  
    bool following = false;

    Vector3 newPosition = Vector3.zero;
    bool calc = false;
  

    void Start()
    {
        move = GetComponent<Move>();
        seek = GetComponent<SteeringArrive>();
        steer = GetComponent<SteeringSeek>();
        police = GetComponent<NavMeshAgent>();
        m_animator = GetComponent<Animator>();
       

    }

    // Update is called once per frame
    void Update()
    {
        if (following == false)
        {            
            m_animator.SetBool("Followig", false);
            m_animator.SetBool("moving", true);
            move.max_mov_velocity = 1.5f;
            if (calc == false)
            {
                newPosition = Random.insideUnitSphere;
                newPosition *= radius * 15;
                newPosition += transform.position;
                newPosition.y = transform.position.y;
                distance = (new Vector3(newPosition.x, newPosition.y, newPosition.z) - transform.position).magnitude;
                NavMeshPath policePath = new NavMeshPath();
                police.CalculatePath(newPosition, policePath);
                if (policePath.corners.Length >= 1)
                {
                    Vector3[] pathCorners = new Vector3[policePath.corners.Length];
                    policePath.corners.CopyTo(pathCorners, 0);
                    seek.SetPathCorners(pathCorners);
                    calc = true;
                }
            }


            float distance2 = (newPosition - transform.position).magnitude;
            if (distance2 <= 3.0f)
            {

                calc = false;
            }
        }
       
    }
    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        //Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(newPosition, 0.2f);
    }

    public void StartFollowing(Vector3 position)
    {
        m_animator.SetBool("Followig", true);
        move.max_mov_velocity = 3.5f;
        distance = (position - transform.position).magnitude;
        NavMeshPath nerdPath = new NavMeshPath();
        police.CalculatePath(position, nerdPath);
        Vector3[] pathCorners = new Vector3[nerdPath.corners.Length];
        nerdPath.corners.CopyTo(pathCorners, 0);
        seek.SetPathCorners(pathCorners);

    }
    public void SetFollowing(bool ret)
    {
        following = ret;
    }
}