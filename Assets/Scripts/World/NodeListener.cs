using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeListener : MonoBehaviour
{
    public bool BeginListeningForNodeClick;
    private Camera _mainCamera;
    [SerializeField] private LinkedList<GameObject> _currentPath;
    private float _nodeDistanceThreshold = 1.5f;
    private WorldNodeDecomposer _nodeManager;
    private LinkedList<GameObject> _emptyLinkedList = new LinkedList<GameObject>();

    void Start()
    {
        _mainCamera = Camera.main;
        BeginListeningForNodeClick = true; // TODO change
        _currentPath = _emptyLinkedList;
        _nodeManager = this.GetComponent<WorldNodeDecomposer>();
    }

    void Update()
    {
        if (BeginListeningForNodeClick)
        {
            bool isClickingMouse = Input.GetMouseButton(0);
            if (isClickingMouse)
                ListenForNodeClick();
        }
    }

    private void ListenForNodeClick()
    {
        Vector3 mousePositionInWorld = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        foreach (GameObject node in _nodeManager.Nodes)
        {
            Vector2 nodePosition = node.transform.position;
            float distanceFromNode = Vector2.Distance(nodePosition, mousePositionInWorld);
            bool mouseInRangeOfNode = distanceFromNode < _nodeDistanceThreshold;
            if (mouseInRangeOfNode)
            {
                // TODO highlight node
                if (!_currentPath.Contains(node))
                {
                    _currentPath.AddLast(node);
                }
            }
        }
    }

    private void printCurrentPath()
    {
        print("in printcurrentpath");
        var sb = new System.Text.StringBuilder();
        foreach (GameObject node in _currentPath)
        {
            sb.Append(node.name + " -> ");
        }
        Debug.Log(sb.ToString());
    }

    private bool pathIsEmpty()
    {
        if (_currentPath == _emptyLinkedList)
        {
            return true;
        }
        else
        {
            return false;
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
