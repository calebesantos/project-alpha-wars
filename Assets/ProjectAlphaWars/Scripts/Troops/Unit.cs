using Complete;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    public bool selected = false;
    public Color m_SelectedColor;
    public Color m_DefaultColor;

    private MeshRenderer[] renderers;
    private StateController stateController;

    void Start()
    {
        renderers = GetComponentsInChildren<MeshRenderer>();
        stateController = GetComponent<StateController>();
        if (stateController)
        {
            stateController.SetupAI(true, new List<Transform>());
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var camPos = Camera.main.WorldToScreenPoint(transform.position);
            camPos.y = RectSelection.InvertMouseY(camPos.y);
            selected = RectSelection.selection.Contains(camPos);

            Color playerColor = selected ? m_SelectedColor : m_DefaultColor;

            for (int i = 0; i < renderers.Length; i++)
                renderers[i].material.color = playerColor;
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