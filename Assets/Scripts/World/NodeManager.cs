using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    public List<GameObject> Nodes = new List<GameObject>();
    [SerializeField] private LayerMask nodeLayerMask;
    private float raycastLength = 8f;

    // Start is called before the first frame update
    void Start()
    {
        nodeLayerMask = LayerMask.GetMask("Node");
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
            List<GameObject> children = new List<GameObject>();
            node.layer = LayerMask.NameToLayer("Default");
            // Cast a line in cardinal directions
            Vector2 up = new Vector2(node.transform.position.x, node.transform.position.y + raycastLength);
            Vector2 down = new Vector2(node.transform.position.x, node.transform.position.y - raycastLength);
            Vector2 right = new Vector2(node.transform.position.x + raycastLength, node.transform.position.y);
            Vector2 left = new Vector2(node.transform.position.x - raycastLength, node.transform.position.y);

            RaycastHit2D upHit = Physics2D.Linecast(node.transform.position, up, nodeLayerMask);
            RaycastHit2D downHit = Physics2D.Linecast(node.transform.position, down, nodeLayerMask);
            RaycastHit2D rightHit = Physics2D.Linecast(node.transform.position, right, nodeLayerMask);
            RaycastHit2D leftHit = Physics2D.Linecast(node.transform.position, left, nodeLayerMask);

            print("");
            print("");
            print("");
            print("Up hits=" + upHit.collider);
            print("Down hits=" + downHit.collider);
            print("Right hits=" + rightHit.collider);
            print("Left hits=" + leftHit.collider);
            if (upHit.collider != null && upHit.collider.name != node.name)
            {
                children.Add(upHit.collider.gameObject);
                print(node.name + " found " + upHit.collider.name + " as a child");
            }
            if (downHit.collider != null && downHit.collider.name != node.name)
            {
                children.Add(downHit.collider.gameObject);
                print(node.name + " found " + downHit.collider.name + " as a child");
            }
            if (rightHit.collider != null && rightHit.collider.name != node.name)
            {
                children.Add(rightHit.collider.gameObject);
                print(node.name + " found " + rightHit.collider.name + " as a child");
            }
            if (leftHit.collider != null && leftHit.collider.name != node.name)
            {
                children.Add(leftHit.collider.gameObject);
                print(node.name + " found " + leftHit.collider.name + " as a child");
            }
            
            node.GetComponent<Node>().children = children;
            node.layer = LayerMask.NameToLayer("Node");

        }
    }

    void OnDrawGizmos()
    {
        foreach (GameObject node in Nodes)
        {
            foreach (GameObject child in node.GetComponent<Node>().children)
            {
                Gizmos.DrawLine(node.transform.position, child.transform.position);
            }
        }
    }
}
