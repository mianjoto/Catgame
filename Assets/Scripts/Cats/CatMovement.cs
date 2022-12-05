using System;
using UnityEngine;
using DG.Tweening;
using System.Collections;

[RequireComponent(typeof(Transform))]
public class CatMovement : MonoBehaviour
{
    private Transform _catTransform;
    public static Action OnCatMove;
    public static Action OnCatStopMoving;

    // Start is called before the first frame update
    void Start()
    {
        _catTransform = this.transform;
    }

    public IEnumerator MoveCat(Vector2 newPosition, float duration = 3f)
    {
        float normalizedDuration = newPosition.normalized.x * duration + newPosition.normalized.y * duration;
        _catTransform.DOMove(newPosition, duration);
        OnCatMove?.Invoke();
        yield return new WaitForSeconds(normalizedDuration);
        OnCatStopMoving?.Invoke();
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
