using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] [Tooltip("The direction(s) the decomposer will not raycast from when searching for nearby nodes")]
    public List<TwoDimensionalDirection> IgnoredDirections;
    public List<GameObject> NeighboringNodes = new List<GameObject>();

    public float g;
    public float f;
    public float h;
    public Node PathParent;
}
