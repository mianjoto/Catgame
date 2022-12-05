using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] [Tooltip("The direction(s) the decomposer will not raycast from when searching for nearby nodes")]
    public List<TwoDimensionalDirection> IgnoredDirections;
    public List<GameObject> NeighboringNodes = new List<GameObject>();

}
