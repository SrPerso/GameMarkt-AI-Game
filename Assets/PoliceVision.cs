using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;

public class PoliceVision : MonoBehaviour
{

    public Camera Cone;
    private Ray ray;

    PoliceBehaviour police;
    public LayerMask mask;
   
    private List<GameObject> RobberList;
    private float prevdist=1000f;
    // Use this for initialization
    void Start()
    {
        RobberList = new List<GameObject>();
        police = GetComponent<PoliceBehaviour>();
        ray = new Ray();

    }

    // Update is called once per frame
    void Update()
    {

        Collider[] coliders = Physics.OverlapSphere(transform.position, Cone.farClipPlane, mask);
        Plane[] FrustumPlanes = GeometryUtility.CalculateFrustumPlanes(Cone);

        foreach (Collider col in coliders)
        {
            if (GeometryUtility.TestPlanesAABB(FrustumPlanes, col.bounds))
            {
                if (col.gameObject.tag == ("Robber"))
                {
                    if (RobberList.Contains(col.gameObject) == false)
                    {
                        RobberList.Add(col.gameObject);
                    }

                }
            }
        }
        if (RobberList != null)
        {
            foreach (GameObject obj in RobberList)
            {
                float distance = (obj.gameObject.transform.position - transform.position).magnitude;
                if (distance < prevdist)
                {
                    prevdist = distance;
                    if (distance <= 2.0f)
                    {
                        RobberList.Remove(obj.gameObject);
                        Destroy(obj.gameObject);
                        police.SetFollowing(false);

                    }
                    else if( distance<=Cone.farClipPlane &&distance>2.0f)
                    {
                        police.SetFollowing(true);
                        police.StartFollowing(obj.gameObject.transform.position);
                    }
                }

            }
        }
        else
        {
            police.SetFollowing(false);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Cone.farClipPlane);
    }
}

