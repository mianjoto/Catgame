using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeListener : MonoBehaviour
{
    public bool BeginListeningForNodeClick;
    private Camera _mainCamera;
    private List<GameObject> _nodes;
    private float _nodeDistanceThreshold = 1.5f;

    void Start()
    {
        _mainCamera = Camera.main;
        BeginListeningForNodeClick = true; // TODO change
        foreach (Transform child in transform)
        {
            _nodes.Add(child.gameObject);
        }
    }

    void Update()
    {
        
        if (BeginListeningForNodeClick)
        {
            bool isClickingMouse = Input.GetMouseButton(0);
            if (!isClickingMouse)
                return;
            ListenForNodeClick();
        }        
    }

    private void ListenForNodeClick()
    {
        Vector3 mousePositionInWorld = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        foreach (GameObject node in _nodes)
        {
            Vector2 nodePosition = node.transform.position;
            float distanceFromNode = Vector2.Distance(nodePosition, mousePositionInWorld);
            bool mouseInRangeOfNode = distanceFromNode < _nodeDistanceThreshold;
            if (mouseInRangeOfNode)
            {
                // TODO highlight node
                print("In range of " + node.name);
            }
        }
    }

    // void OnDrawGizmos()
    // {
    //     foreach(Transform nodeTransform in _nodesTransform)
    //     {
    //         Gizmos.DrawWireSphere(nodeTransform.position, _nodeDistanceThreshold);
    //     }
    // }
}
