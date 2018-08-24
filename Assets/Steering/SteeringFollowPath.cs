using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;

public class SteeringFollowPath : SteeringAbstract
{

	Move move;
	SteeringArrive seek;
    PoliceBehaviour agent;
	public BGCcMath path;
	Vector3 desiredPoint;
	public float ratio = 0.1f;
	float currentRatio;
    Vector3[] pathCorners;

    // Use this for initialization
    void Start () {
		move = GetComponent<Move>();
		seek = GetComponent<SteeringArrive>();
        agent = GetComponent<PoliceBehaviour>();

		// TODO 1: Calculate the closest point in the range [0,1] from this gameobject to the path
		float startDistance;
		float distance = path.GetDistance ();
		desiredPoint = path.CalcPositionByClosestPoint(transform.position, out startDistance);
		currentRatio = startDistance / distance;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// TODO 2: Check if the tank is close enough to the desired point
		// If so, create a new point further ahead in the path
		float distance = path.GetDistance();
		Vector3 diff = desiredPoint - transform.position;
		if (diff.magnitude < 1) 
		{
			if (currentRatio >= 1) {
				currentRatio = 0;
			} 
			else 
			{
				currentRatio += ratio;
			}
			desiredPoint = path.CalcPositionByDistanceRatio(currentRatio);
            distance = (new Vector3(desiredPoint.x, desiredPoint.y, desiredPoint.z) - move.transform.position).magnitude;
            NavMeshPath nerdPath = new NavMeshPath();
            agent.police.CalculatePath(desiredPoint, nerdPath);
            pathCorners = new Vector3[nerdPath.corners.Length];

            nerdPath.corners.CopyTo(pathCorners, 0);
           
        } 
			seek.SetPathCorners(pathCorners);
	}

	void OnDrawGizmosSelected() 
	{
			// Display the explosion radius when selected
			Gizmos.color = Color.green;
			// Useful if you draw a sphere were on the closest point to the path
		Gizmos.DrawWireSphere(desiredPoint, 1.0f);

	}
}
