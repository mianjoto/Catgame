using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DrawPath : MonoBehaviour
{
    private LineRenderer _lr;

    void OnEnable()
    {
        NodeListener.OnAddNodeToPath += UpdatePointsAndDrawPath;
    }
    void OnDisable()
    {
        NodeListener.OnAddNodeToPath -= UpdatePointsAndDrawPath;
    }

    void Start()
    {
        _lr = GetComponent<LineRenderer>();
    }

    void UpdatePointsAndDrawPath(LinkedList<GameObject> path)
    {
        List<Vector3> nodePositions = new List<Vector3>();
        foreach (GameObject node in path)
        {
            nodePositions.Add(node.transform.position);
        }
        _lr.positionCount = nodePositions.Count;
        _lr.SetPositions(nodePositions.ToArray());
    }
}