using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Scene Switch Data")]
public class SceneSwitchData : ScriptableObject
{
    [Header("Scene that the player should switch to upon trigger")]
    [SerializeField]
    public SceneLoader.Scenes TargetScene;
    [SerializeField]
    [Header("Name of the spawn entrance point in next scene")]
    public string SceneEntranceName;
}
