using UnityEngine;

public class CameraMoveControl : MonoBehaviour
{

    public float panSpeed = 30f;
    public float panBorderThickness = 15f;

    public float scrollSpeed = 5f;
    public float minScrollY = 10f;
    public float maxScrollY = 80f;


    void Update()
    {
        ScreenPanManager();
        CameraScroll();
    }

    private void ScreenPanManager()
    {
        if (Input.GetKey("w") || IsMouseAtScreenTop())
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || IsMouseAtScreenBottom())
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || IsMouseAtScreenLeft())
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || IsMouseAtScreenRight())
        {
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
