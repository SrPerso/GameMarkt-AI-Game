using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.AI;

public class MoveToMouseClick : MonoBehaviour {

	public LayerMask mask;
	public int mouse_button = 0;


	// Update is called once per frame
	void Update ()
	{



		if (Input.GetMouseButton (mouse_button)) {
			RaycastHit hit;
			Ray r = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (r, out hit, 10000.0f, mask) == true) {
				object[] obj = GameObject.FindSceneObjectsOfType (typeof(GameObject));
        
				foreach (object o in obj) {
					GameObject g = (GameObject)o;
					if (g.GetComponents<NavMeshAgent> () != null) {
						object[] agent = g.GetComponents<NavMeshAgent>() ;
						foreach (NavMeshAgent p in agent)
						{
							NavMeshAgent agent2 = (NavMeshAgent)p;
							agent2.destination = hit.point;
						}

					} else {
						transform.position = hit.point;
					}
				}				
					
					
						

				
			}
		}

	}
}
