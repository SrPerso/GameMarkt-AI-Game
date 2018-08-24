using System.Collections;
using UnityEngine;

public class UIDebug : MonoBehaviour{

    public GameObject spawner;

    public void spawn(GameObject GoToSpawn)
    {
        Instantiate(GoToSpawn, spawner.transform.position/* + transform.TransformPoint(0, 0, 0)*/, GoToSpawn.transform.rotation);
    }

}
