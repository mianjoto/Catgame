using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AStar : MonoBehaviour
{
    [SerializeField]
    private LayerMask _nodeLayerMask;
    [SerializeField]
    private Node _startingNode;
    [SerializeField]
    private Node _goalNode;
    [SerializeField]
    private LinkedList<Node> _aStarPath;
    private NodeListener _nodeListener;
    [SerializeField]
    private WorldNodeDecomposer _nodeManager;
    private Node _oldGoalNode;
    private Vector3 _newGoalNode;
    private Coroutine doAnimateAStarPath;

    void Start()
    {
        _nodeListener = GetComponent<NodeListener>();
    }

    void OnEnable()
    {
        InputListener.OnRightClickDown += UpdateNewGoalPosition;
        InputListener.OnAlternateInteractKeyDown += AnimateAStar;
    }

    void OnDisable()
    {
        InputListener.OnRightClickDown -= UpdateNewGoalPosition;
        InputListener.OnAlternateInteractKeyDown -= AnimateAStar;
    }

    private void UpdateNewGoalPosition()
    {
        if (_oldGoalNode == null)
            _oldGoalNode = _nodeManager.Nodes[0].GetComponent<Node>();
        
        GameObject newGoalNode = _nodeListener.GetNodeAtMousePosition();

        _startingNode = _oldGoalNode;
        _goalNode = newGoalNode.GetComponent<Node>();
    }

    void StopCoroutineIfNotNull(Coroutine coroutine)
    {
        if (coroutine != null)
            StopCoroutine(coroutine);
    }

    private void AnimateAStar()
    {
        _aStarPath = GetAStarPath();
        StopCoroutineIfNotNull(doAnimateAStarPath);
        doAnimateAStarPath = StartCoroutine(nameof(GraduallyDrawAStarPath));
    }

    private IEnumerator GraduallyDrawAStarPath()
    {
        LinkedListNode<Node> head = _aStarPath.First;
        LinkedList<GameObject> path = new LinkedList<GameObject>();
        // add first to list
        path.AddFirst(head.Value.gameObject);
        NodeListener.OnAddNodeToPath?.Invoke(path);

        while (head.Next != null)
        {
            Node currentNode = head.Value;
            path.AddFirst(currentNode.gameObject);
            NodeListener.OnAddNodeToPath?.Invoke(path);
            head = head.Next;
            yield return new WaitForSeconds(0.5f);
        }

        // add goal node to list
        path.AddFirst(head.Value.gameObject);
        NodeListener.OnAddNodeToPath?.Invoke(path);
    }

    LinkedList<Node> GetAStarPath()
    {
        // Initialize paths
        List<Node> openList = new List<Node>();
		List<Node> closedList = new List<Node>();
        
		Node currentNode = null;

		// Add starting node to open list
		openList.Insert(0, _startingNode);

		// Loop while the open list has nodes
		while (openList.Count != 0) {	
            currentNode = openList.Last();
			// If open list only has one node, set current node to the only node
			if (openList.Count == 1) {
				currentNode = openList.Last();
			}
			// Else set the current node to the node with the lowest F value
			else {
				float lowestFValue = 99999;
				foreach (Node node in openList) {
					float fValue = node.f;
					if (fValue < lowestFValue) {
						lowestFValue = fValue;
						currentNode = node;
					}
				}
			}
			// Remove current node from open list (going to search)
			openList.Remove(currentNode);

			// Check if current node is goal node
			if (currentNode.Equals(_goalNode)) {
				_aStarPath = TraceBackFromGoal(currentNode);
                PrintAStarPath();

				return _aStarPath;
			}

			// Generate children of the current node
			List<GameObject> childrenOfCurrentNode = GetUniqueChildren(currentNode, closedList, openList);
			foreach (GameObject child in childrenOfCurrentNode) {
                child.GetComponent<Node>().PathParent = currentNode;
				// Explore only if not in closed list
				bool childInClosedList = false;
				foreach (Node closedListNode in closedList) {
					if (closedListNode.Equals(child)) {
						childInClosedList = true;
					}
				}
				if (!childInClosedList) {
                    Vector2 childPosition = new Vector2(
                        child.transform.position.x,
                        child.transform.position.z);
					// Generate F, G, and H values
                    Vector2 startingNodePosition = new Vector2(
                        _startingNode.transform.position.x,
                        _startingNode.transform.position.z);
                    Vector2 goalNodePosition = new Vector2(
                        _goalNode.transform.position.x,
                        _goalNode.transform.position.z);
					float g = getG(startingNodePosition, childPosition);
					float h = getH(childPosition, goalNodePosition);
					float f = g + h;

					// store values in the node object
					child.GetComponent<Node>().h = h;
					child.GetComponent<Node>().g = g;
					child.GetComponent<Node>().f = f;

					// If child in open list, ignore if has higher h value
					if (openList.Contains(child.GetComponent<Node>())) {
                        foreach (Node node in openList.ToList()) {
                            if (child.transform.position.Equals(node.transform.position)) {
                                if (child.GetComponent<Node>().h < node.GetComponent<Node>().h) {
                                    openList.Insert(0, child.GetComponent<Node>());
                                }
                            }
                        }
					} else {
						openList.Insert(0, child.GetComponent<Node>());
					}
					
					
				}
			}

			// Add the current node to the closed list
			closedList.Insert(0, currentNode);
			
		}

		Debug.Log("<color=red>A solution was not found. The goal is unpathable.</color>");
        return null;
    }

    private List<GameObject> GetUniqueChildren(Node currentNode, List<Node> closedList, List<Node> openList)
    {
        List<GameObject> uniqueChildren = new List<GameObject>();
        foreach (GameObject child in currentNode.NeighboringNodes)
        {
            if (!closedList.Contains(child.GetComponent<Node>()) && !openList.Contains(child.GetComponent<Node>()))
            {
                uniqueChildren.Add(child);
            }
        }
        return uniqueChildren;
    }

    private LinkedList<Node> TraceBackFromGoal(Node currentNodeAtGoal) {
		Node currentNode = currentNodeAtGoal;
		LinkedList<Node> path = new LinkedList<Node>();

        int numIterations = 0;

		// get parent of current position until reach the starting node
		while (currentNode != null && currentNode.PathParent != null && numIterations < 100) {
			path.AddFirst(currentNode);
			currentNode = currentNode.PathParent;
            numIterations++;		
		}

		return path;
	}

    // F = G + H
	private static float getF(Vector2 startPos, Vector2 currentPos, Vector2 goalPos) {
		return getG(startPos, currentPos) + getH(currentPos, goalPos);
	}

	// G is distance between current node and the start node
	private static float getG(Vector2 startPos, Vector2 currentPos) {
        
		return Mathf.Abs(Distance(startPos, currentPos));
	}
	
	// H is estimated distance from current node to end node
	private static float getH(Vector2 currentPos, Vector2 goalPos) {
		// irrespective of obstacles
		return Mathf.Abs(Distance(currentPos, goalPos));
	}
    
    private static float Distance(Vector2 coordinate1, Vector2 coordinate2)
    {
        float distance = Mathf.Sqrt(Mathf.Pow(coordinate1.x - coordinate2.x, 2) + Mathf.Pow(coordinate1.y - coordinate2.y, 2));
        return distance;
    }

    void PrintAStarPath()
    {
        StringBuilder str = new StringBuilder();
        str.Append("A* path=");
        LinkedListNode<Node> head = _aStarPath.First;
        while (head.Next != null)
        {
            str.Append(head.Value.ToString());
            str.Append(" -> ");
            head = head.Next;
        }
        Debug.Log(str.ToString());
    }


}