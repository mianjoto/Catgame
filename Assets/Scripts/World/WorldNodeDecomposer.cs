using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldNodeDecomposer : MonoBehaviour
{
    public List<GameObject> Nodes = new List<GameObject>();
    [SerializeField] private LayerMask nodeLayerMask;
    private float linecastLength = 8f;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            Nodes.Add(child.gameObject);
        }
        GetChildren(Nodes);
    }

    void GetChildren(List<GameObject> nodeList)
    {
        foreach (GameObject node in nodeList)
        {
            List<GameObject> neighboringNodes = new List<GameObject>();
            Node nodeComponent = node.GetComponent<Node>();

            // Temporarily change layer to avoid linecasting itself
            node.layer = LayerMask.NameToLayer("Default");

            // Cast a line in cardinal directions
            Vector2 up = new Vector2(node.transform.position.x, node.transform.position.y + linecastLength);
            Vector2 down = new Vector2(node.transform.position.x, node.transform.position.y - linecastLength);
            Vector2 right = new Vector2(node.transform.position.x + linecastLength, node.transform.position.y);
            Vector2 left = new Vector2(node.transform.position.x - linecastLength, node.transform.position.y);

            RaycastHit2D upHit = Physics2D.Linecast(node.transform.position, up, nodeLayerMask);
            RaycastHit2D downHit = Physics2D.Linecast(node.transform.position, down, nodeLayerMask);
            RaycastHit2D rightHit = Physics2D.Linecast(node.transform.position, right, nodeLayerMask);
            RaycastHit2D leftHit = Physics2D.Linecast(node.transform.position, left, nodeLayerMask);

            if (upHit.collider != null && upHit.collider.name != node.name && IsNotIgnoredDirection(TwoDimensionalDirection.UP, nodeComponent))
            {
                neighboringNodes.Add(upHit.collider.gameObject);
            }
            if (downHit.collider != null && downHit.collider.name != node.name && IsNotIgnoredDirection(TwoDimensionalDirection.DOWN, nodeComponent))
            {
                neighboringNodes.Add(downHit.collider.gameObject);
            }
            if (rightHit.collider != null && rightHit.collider.name != node.name && IsNotIgnoredDirection(TwoDimensionalDirection.RIGHT, nodeComponent))
            {
                neighboringNodes.Add(rightHit.collider.gameObject);
            }
            if (leftHit.collider != null && leftHit.collider.name != node.name && IsNotIgnoredDirection(TwoDimensionalDirection.LEFT, nodeComponent))
            {
                neighboringNodes.Add(leftHit.collider.gameObject);
            }
            
            // Reassign layer back to Node layer
            node.layer = LayerMask.NameToLayer("Node");

            nodeComponent.NeighboringNodes = neighboringNodes;
        }
    }

    bool IsNotIgnoredDirection(TwoDimensionalDirection linecastDirection, Node nodeComponent)
    {
        if (nodeComponent.IgnoredDirections == null)
            return true;
        
        if (!nodeComponent.IgnoredDirections.Contains(linecastDirection))
            return true;
        return false;
    }

    void OnDrawGizmos()
    {
        foreach (GameObject node in Nodes)
        {
            foreach (GameObject child in node.GetComponent<Node>().NeighboringNodes)
            {
                Gizmos.DrawLine(node.transform.position, child.transform.position);
            }
        }
    }
}

public enum TwoDimensionalDirection
{
    UP,
    RIGHT,
    DOWN,
    LEFT
}
