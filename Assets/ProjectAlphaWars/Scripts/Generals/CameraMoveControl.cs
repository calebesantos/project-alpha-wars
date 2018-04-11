using UnityEngine;

public class CameraMoveControl : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBorderThickness = 15f;

    public float scrollSpeed = 5f;
    public float minScrollY = 10f;
    public float maxScrollY = 80f;

    public float maxPositionX = 30f;
    public float minPositionX = -30f;
    public float maxPositionZ = 10f;
    public float minPositionZ = -53f;


    void Update()
    {
        ScreenPanManager();
        CameraScroll();
    }

    private void ScreenPanManager()
    {
        if (Input.GetKey("w") || IsMouseAtScreenTop())
        {
            if (gameObject.transform.position.z <= maxPositionZ)
                transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || IsMouseAtScreenBottom())
        {
            if (gameObject.transform.position.z >= minPositionZ)
                transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || IsMouseAtScreenLeft())
        {
            if (gameObject.transform.position.x >= minPositionX)
                transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || IsMouseAtScreenRight())
        {
            if (gameObject.transform.position.x <= maxPositionX)
                transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
    }

    private bool IsMouseAtScreenRight()
    {
        return (Input.mousePosition.x >= Screen.width - panBorderThickness);
    }

    private bool IsMouseAtScreenLeft()
    {
        return (Input.mousePosition.x <= panBorderThickness);
    }

    private bool IsMouseAtScreenBottom()
    {
        return (Input.mousePosition.y <= panBorderThickness);
    }

    private bool IsMouseAtScreenTop()
    {
        return (Input.mousePosition.y >= Screen.height - panBorderThickness);
    }

    private void CameraScroll()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minScrollY, maxScrollY);

        transform.position = pos;
    }
}
