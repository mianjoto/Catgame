using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeListener : MonoBehaviour
{
    public bool BeginListeningForNodeClick;
    private Camera _mainCamera;
    [SerializeField]
    public LinkedList<GameObject> Path;
    public static Action<LinkedList<GameObject>> OnAddNodeToPath;
    private float _nodeDistanceThreshold = 1.5f;
    private WorldNodeDecomposer _nodeManager;
    private LinkedList<GameObject> _emptyLinkedList = new LinkedList<GameObject>();

    void Start()
    {
        _mainCamera = Camera.main;
        BeginListeningForNodeClick = false;
        Path = _emptyLinkedList;
        _nodeManager = this.GetComponent<WorldNodeDecomposer>();
    }

    void Update()
    {
        // print(Input.GetMouseButton(0));
        if (Input.GetMouseButton(0))
        {
            ListenAndDrawNodePath();
        }
        else if (Path.Count != 0)
        {
            Path.Clear();
        }
    }

    private void ListenAndDrawNodePath()
    {
        GameObject node = ListenForNodeClick();
        if (!Path.Contains(node) && node != null)
        {
            print("got " + node.name);
            Path.AddLast(node);
            OnAddNodeToPath?.Invoke(Path);
        }
    }

    private GameObject ListenForNodeClick()
    {
        Vector3 mousePositionInWorld = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        foreach (GameObject node in _nodeManager.Nodes)
        {
            Vector2 nodePosition = node.transform.position;
            float distanceFromNode = Vector2.Distance(nodePosition, mousePositionInWorld);
            bool mouseInRangeOfNode = distanceFromNode < _nodeDistanceThreshold;
            if (mouseInRangeOfNode)
            {
                return node;
            }
        }
        return null;
    }

    private void printCurrentPath()
    {
        print("in printcurrentpath");
        var sb = new System.Text.StringBuilder();
        foreach (GameObject node in Path)
        {
            sb.Append(node.name + " -> ");
        }
        Debug.Log(sb.ToString());
    }

    private bool pathIsEmpty()
    {
        if (Path == _emptyLinkedList)
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