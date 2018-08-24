using System.Collections;
using UnityEngine;

public class ReStart : MonoBehaviour
{
    public void reStart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
