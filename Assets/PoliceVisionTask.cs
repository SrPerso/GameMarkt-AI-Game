using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;

public class PoliceVisionTask : ActionTask
{


    public BBParameter<GameObject> Robber;
    public BBParameter<GameObject> Object;
    public BBParameter<Camera> Cone;  
    public BBParameter<LayerMask> Mask;
    

    protected override void OnExecute()
    {

    }

    protected override void OnUpdate()
    {


        Collider[] coliders = Physics.OverlapSphere(Object.value.transform.position, Cone.value.farClipPlane, Mask.value);
        Plane[] FrustumPlanes = GeometryUtility.CalculateFrustumPlanes(Cone.value);

        foreach (Collider col in coliders)
        {
            if (GeometryUtility.TestPlanesAABB(FrustumPlanes, col.bounds))
            {
                if (col.gameObject.tag == "Robber")
                {
                    if (col.gameObject != Robber.value)
                    {
                        Robber.value = col.gameObject;

                        EndAction(true);
                    }
                }

            }



        }
    }
}
