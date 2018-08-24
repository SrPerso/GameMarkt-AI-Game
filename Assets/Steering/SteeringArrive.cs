using UnityEngine;
using System.Collections;

public class SteeringArrive : SteeringAbstract
{

	public float min_distance = 0.5f;
	public float slow_distance = 5.0f;
	public float time_to_target = 0.1f;

    private Vector3[] pathCorners;
    private int pathCount;
    Move move;

	// Use this for initialization
	void Start ()
    { 

		move = GetComponent<Move>();       

    }

	// Update is called once per frame
	void Update () 
	{
        if (pathCorners != null)
        {
            if (pathCorners.Length > 0 && pathCount < pathCorners.Length)
            {
                Steer(pathCorners[pathCount]);
            }
            else
            {
                move.SetMovementVelocity(Vector3.zero);
            }
        }
	}

	public void Steer(Vector3 target)
	{
		if(!move)
			move = GetComponent<Move>();

		// Velocity we are trying to match
		float ideal_velocity = 0.0f;
		Vector3 diff = target - transform.position;

        if (diff.magnitude < min_distance)
        {
            if (pathCount == (pathCorners.Length-1))
            {
                move.SetMovementVelocity(Vector3.zero);
            }
            pathCount++;
            return;
        }
		// Decide wich would be our ideal velocity
		if(diff.magnitude > slow_distance || pathCount !=(pathCorners.Length-1))
			ideal_velocity = move.max_mov_velocity;
		else
			ideal_velocity = move.max_mov_velocity * diff.magnitude / slow_distance;

		// Create a vector that describes the ideal velocity
		Vector3 ideal_movement = diff.normalized * ideal_velocity;

		// Calculate acceleration needed to match that velocity
		Vector3 acceleration = ideal_movement - move.movement;
		acceleration /= time_to_target;

		// Cap acceleration
		if(acceleration.magnitude > move.max_mov_acceleration)
		{
			acceleration.Normalize();
			acceleration *= move.max_mov_acceleration;
		}

		move.AccelerateMovement(acceleration);
	}

    public void SetPathCorners(Vector3 [] corners)
    {
        pathCorners = corners;
        pathCount = 0;
    }

    void OnDrawGizmosSelected() 
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position, min_distance);

		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, slow_distance);

		if (pathCount > 0) 
		{
			//Gizmos.color = Color.red;
			//Gizmos.DrawWireSphere (pathCorners [pathCount],0.5f);
		}
	}
}
