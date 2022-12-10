using System;
using UnityEngine;
using DG.Tweening;
using System.Collections;

[RequireComponent(typeof(Transform))]
public class CatMovement : MonoBehaviour
{
    private Transform _catTransform;
    private Vector2 _previousPosition;
    public static Action<Vector3, Vector3> OnCatMove;
    public bool IsMoving;
    [SerializeField]
    private BoxCollider2D _pathableArea;

    // Start is called before the first frame update
    void Start()
    {
        _catTransform = this.transform;
        _previousPosition = (Vector2) transform.position;
    }

    void FixedUpdate()
    {
        IsMoving = IsCatMoving();
        _previousPosition = (Vector2)transform.position;
    }

    private bool IsCatMoving()
    {
        if (!_previousPosition.Equals(transform.position))
            return true;
        else
            return false;
    }

    public void MoveCatToRandomPointInPathableArea(float duration = 3f)
    {
        Vector3 randomPointInPathableArea = GetRandomPointInPathableArea();
        MoveCat(randomPointInPathableArea, duration);
    }

    private Vector3 GetRandomPointInPathableArea()
    {
        Vector3 extents = _pathableArea.size / 2f;
        Vector3 point = new Vector3(
            UnityEngine.Random.Range( -extents.x, extents.x ),
            UnityEngine.Random.Range( -extents.y, extents.y ),
            UnityEngine.Random.Range( -extents.z, extents.z )
        );
    
        return _pathableArea.transform.TransformPoint( point );
    }

    public void MoveCat(Vector2 newPosition, float duration = 3f)
    {
        float normalizedDuration = newPosition.normalized.x * duration + newPosition.normalized.y * duration;
        OnCatMove?.Invoke(this.transform.position, newPosition);
        _catTransform.DOMove(newPosition, duration);
    }

    void OnEnable()
    {
        InputListener.OnInteractKeyDown += MoveCatToUnitCircle;
    }
    void OnDisable()
    {
        InputListener.OnInteractKeyDown += MoveCatToUnitCircle;
    }

    private void MoveCatToUnitCircle()
    {
        MoveCat(UnityEngine.Random.insideUnitCircle * 3, 3);
    }
}
