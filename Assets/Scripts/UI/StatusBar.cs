using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// Base class for the status bars in the game.
/// </summary>
[RequireComponent(typeof(Image))]
public abstract class StatusBar : MonoBehaviour
{
    [SerializeField]
    private StatusBarDecayData _barData;
    private Coroutine _reduceStatusOverTime;
    private Image _imageComponent;
    private float _currentFillAmount;

    public static Action<StatusBar> OnStatusBarEmpty;

    void Start()
    {
        _currentFillAmount = _barData.MAXIMUM_FILL_AMOUNT;
        _imageComponent = GetComponent<Image>();
        _imageComponent.sprite = _barData.FillImageSprite;
        
        if (_reduceStatusOverTime != null)
            StopCoroutine(_reduceStatusOverTime);
        _reduceStatusOverTime = StartCoroutine(nameof(DecayStatus));
        
    }

    void OnEnable()
    {
        InputListener.OnAlternateInteractKeyDown += DEBUG_ReduceBarAmount;
    }
    void OnDisble()
    {
        InputListener.OnAlternateInteractKeyDown -= DEBUG_ReduceBarAmount;
    }
    
    void DEBUG_ReduceBarAmount()
    {
        _currentFillAmount -= 20;
        UpdateStatusBar(_currentFillAmount);
    }

    IEnumerator DecayStatus()
    {
        while (_currentFillAmount > 0)
        {
            yield return new WaitForSeconds(_barData.DecayWaitPeriod);
            _currentFillAmount -= _barData.ReduceAmount;
            UpdateStatusBar(_currentFillAmount);
            DecayStatus();
        }

        // Status is now <=0, stop coroutine and trigger event
        HandleEmptyBar();
    }

    public void UpdateStatusBar(float newFillAmount)
    {
        float duration = _barData.DurationScalar * (newFillAmount / _barData.MAXIMUM_FILL_AMOUNT);
        _imageComponent.DOFillAmount(newFillAmount / _barData.MAXIMUM_FILL_AMOUNT, duration);
    }

    private void HandleEmptyBar()
    {
        OnStatusBarEmpty?.Invoke(this);
        StopCoroutine(_reduceStatusOverTime);
    }
}
