using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableComponet : MonoBehaviour {

    private DayNightController dncontrol;

    // Use this for initialization
    void Start ()
    {
        dncontrol = GetComponent<DayNightController>();

    }
	public void EnableCompDN()
    {
        dncontrol.enabled = !dncontrol.enabled;
    }
}
