using UnityEngine;


public class CameraComtroller : MonoBehaviour {

    public float panSpeeD = 20f;
    public float panBorderThickness = 10f;

    public Vector2 panLimitTop;
    public Vector2 panLimitDown;

    public float scrollSpeed = 2f;
    public float minY = 20f;
    public float maxY = 50f;

    // Update is called once per frame

    void Update ()
    {

        Vector3 pos = transform.position;

        if (Input.GetKey("w")||Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.x -= panSpeeD * Time.deltaTime;
        }


        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            pos.x += panSpeeD * Time.deltaTime;
        }


        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.z += panSpeeD * Time.deltaTime;
        }


        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            pos.z -= panSpeeD * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        pos.y -= scroll * scrollSpeed * 100f *Time.deltaTime;


        pos.x = Mathf.Clamp(pos.x, -panLimitTop.x, panLimitDown.x);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, -panLimitTop.y, panLimitDown.y);

        transform.position = pos;

	}
}
