using UnityEngine;
using System.Collections;

public class KinematicWander : MonoBehaviour {

	public float max_angle = 0.5f;

	Move move;
    SteeringArrive seek;
    private Vector3[] pathCorners;
    private int pathCount;

    // Use this for initialization
    void Start () {
		move = GetComponent<Move>();
        seek=GetComponent<SteeringArrive>();
	}

	// number [-1,1] values around 0 more likely
	public float RandomBinominal()
	{
		return Random.value * Random.value;
	}

    private void Update()
    {
        if (pathCorners != null)
        {
            if (pathCorners.Length > 0 && pathCount < pathCorners.Length)
            {
                Wander(pathCorners[pathCount]);
            }
            else
            {
                move.SetMovementVelocity(Vector3.zero);
            }
        }
    }

    // Update is called once per frame
    void Wander (Vector3 target) 
	{        
        move.SetMovementVelocity (target);
	}

    public void SetPathCorners(Vector3[] path)
    {
        pathCorners = path;
        pathCount = 0;
    }
}
