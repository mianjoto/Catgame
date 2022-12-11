using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Scriptable Object/Status Bar Decay Data")]
public class StatusBarDecayData : ScriptableObject
{
    public Sprite FillImageSprite;
    public float MAXIMUM_FILL_AMOUNT = 100f;
    public float DecayWaitPeriod = 2f;
    public float ReduceAmount = 1f;
    public float DurationScalar = 0.75f;
}