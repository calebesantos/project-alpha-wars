using System.Collections.Generic;
using UnityEngine;

public class RectSelection : MonoBehaviour
{
    public static Rect selection = new Rect(0, 0, 0, 0);
    private Vector3 startClick = -Vector3.one;

    //private static Vector3 destination = Vector3.zero;
    //private static List<string> passables = new List<string>() { "Floor" };

    void Update()
    {
        CheckCamera();
    }

    private void CheckCamera()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startClick = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (selection.width < 0)
            {
                selection.x += selection.width;
                selection.width = -selection.width;
            }

            if (selection.height < 0)
            {
                selection.y += selection.height;
                selection.height = -selection.height;
            }

            startClick = -Vector3.one;
        }

        if (Input.GetMouseButton(0))
        {
            var currentPosition = Input.mousePosition;
            var width = currentPosition.x - startClick.x;
            var height = InvertMouseY(currentPosition.y) - InvertMouseY(startClick.y);
            selection = new Rect(startClick.x, InvertMouseY(startClick.y), width, height);
        }
    }

    void OnGUI()
    {
        if (startClick != -Vector3.one)
        {
            GUI.color = new Color(1, 1, 1, 0.5f);
            GUI.DrawTexture(selection, Texture2D.whiteTexture);
        }
    }

    public static float InvertMouseY(float y)
    {
        return Screen.height - y;
    }


    private void Cleanup()
    {
        //if (!Input.GetMouseButtonUp(1))
        //{
        //    destination = Vector3.zero;
        //}
    }
}