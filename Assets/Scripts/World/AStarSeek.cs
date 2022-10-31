using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarSeek : MonoBehaviour
{
    private List<GameObject> _nodes;
    [SerializeField] private NodeManager _nodeManager;

    void Start()
    {
        _nodes = _nodeManager.Nodes;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(3))
        {
            GameObject startingNode = _nodes[UnityEngine.Random.Range(0, _nodes.Count)];
            GameObject goalNode = _nodes[UnityEngine.Random.Range(0, _nodes.Count)];
            // AStarSolve(startingNode, goalNode);
        }
    }

    // LinkedList<GameObject> AStarSolve(GameObject startingNode, GameObject goalNode)
    // {
    //     LinkedList<GameObject> openList = new LinkedList<GameObject>();
	// 	LinkedList<GameObject> closedList = new LinkedList<GameObject>();
	// 	LinkedList<GameObject> aStarPath = new LinkedList<GameObject>();
	// 	GameObject currentNode = startingNode;

	// 	// Add starting node to open list
	// 	openList.AddFirst(startingNode);

	// 	// Loop while the open list has nodes
	// 	while (openList.Count != 0) {	
	// 		// If open list only has one node, set current node to the only node
	// 		currentNode = openList.Last.Value;
	// 		if (openList.Count == 1) {
	// 			currentNode = openList.Last.Value;
	// 		}
	// 		// Else set the current node to the node with the lowest F value
	// 		else {
	// 			float lowestFValue = 99999;
	// 			foreach (GameObject node in openList) {
	// 				float fValue = getF(startingNode, currentNode, goalNode);
	// 				if (fValue < lowestFValue) {
	// 					lowestFValue = fValue;
	// 					currentNode = node;
	// 				}
	// 			}
	// 		}
	// 		// Remove current node from open list (going to search)
	// 		openList.Remove(currentNode);

	// 		// Check if current node is goal node
	// 		if (currentNode.transform.position == goalNode.transform.position) {
	// 			aStarPath = traceBackFromGoal(currentNode, startingNode);
	// 			return aStarPath;
	// 		}

	// 		// Generate children of the current node
	// 		List<GameObject> childrenOfCurrentNode = world.getChildren(currentNode);
	// 		foreach (GameObject child in childrenOfCurrentNode) {
	// 			// Explore only if not in closed list
	// 			bool childInClosedList = false;
	// 			foreach (GameObject closedListNode in closedList) {
	// 				if (closedListNode.transform.position == child.transform.position) {
	// 					childInClosedList = true;
	// 				}
	// 			}
	// 			if (!childInClosedList) {
	// 				// Generate F, G, and H values
	// 				int g = getG(startingNode, child);
	// 				int h = getH(child, goalNode);
	// 				int f = g + h;

	// 				// store values in the node object
	// 				child.setG(g);
	// 				child.setH(h);
	// 				child.setF();

	// 				// If child in open list, ignore if has higher h value
	// 				if (openList.Contains(child)) {
	// 						foreach (GameObject node in openList) {
	// 							if (child.getRow == node.getRow && child.getCol == node.getCol) {
	// 								if (child.getH() < node.getH()) {
	// 									openList.AddFirst(child);
	// 								}
	// 							}
	// 						}
	// 				} else {
	// 					openList.AddFirst(child);
	// 				}
					
					
	// 			}
	// 		}

	// 		// Add the current node to the closed list
	// 		closedList.AddFirst(currentNode);
			
	// 	}

	// 	Console.WriteLine("A solution was not found. The goal is unpathable.");
    // }

    // public static LinkedList<GameObject> traceBackFromGoal(GameObject goalNode, GameObject startNode) {
	// 	LinkedList<GameObject> path = new LinkedList<GameObject>();
	// 	GameObject currentNode = goalNode.getParent();
	// 	GameObject parent;
	
	// 	// get parent of current position until reach the starting node
	// 	while (!currentNode.equals(startNode)) {
	// 		path.AddLast(currentNode);
	// 		currentNode = currentNode.getParent();			
	// 	}

	// 	return path;
	// }

    // F = G + H
	public static float getF(GameObject startingNode, GameObject currentNode, GameObject goalNode) {
		return getG(startingNode, currentNode) + getH(currentNode, goalNode);
	}

	// G is distance between current node and the start node
	public static float getG(GameObject currentNode, GameObject startingNode) {
		return Vector2.Distance(currentNode.transform.position, startingNode.transform.position);
	}
	
	// H is estimated distance from current node to end node
	public static float getH(GameObject currentNode, GameObject goalNode) {
		// irrespective of obstacles
		return Vector2.Distance(currentNode.transform.position, goalNode.transform.position);
	}

}
