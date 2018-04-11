using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    public bool selected = false;
    private Renderer render;

    void Start()
    {
        render = GetComponent<Renderer>();
    }

    void Update()
    {
        if (isElementVisible() && Input.GetMouseButton(0))
        {
            var camPos = Camera.main.WorldToScreenPoint(transform.position);
            camPos.y = RectSelection.InvertMouseY(camPos.y);
            selected = RectSelection.selection.Contains(camPos);

            if (selected)
                render.material.color = Color.red;
            else
                render.material.color = Color.white;
        }

        if (selected && Input.GetMouseButtonUp(1))
        {
            var destination = GetDestination();

            if (destination != -Vector3.one)
            {
                var navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
                navMeshAgent.SetDestination(destination);
            }
        }
    }

    private bool isElementVisible()
    {
        return render.isVisible;
    }

    private Vector3 GetDestination()
    {
        RaycastHit hit;
        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(r, out hit))
        {
            return hit.point;
        }

        return -Vector3.one;
    }
}