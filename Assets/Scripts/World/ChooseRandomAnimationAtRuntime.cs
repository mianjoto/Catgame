using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class ChooseRandomAnimationAtRuntime : MonoBehaviour
{
    [Header("The list of animations to choose from at runtime")]
    [SerializeField]
    private List<AnimationClip> _animations;
    
    void Start()
    {
        string randomAnimationState = GetRandomAnimationStateName();
        this.GetComponent<Animator>().Play(randomAnimationState, 0, 0.0f);
    }

    private string GetRandomAnimationStateName()
    {
        AnimationClip randomAnimation = _animations[UnityEngine.Random.Range(0, _animations.Count)];
        string stateObjectName = randomAnimation.ToString();

        // Unity's ToString function returns the name of the state and the
        // type of GameObject, leading to the ToString function returning
        // something of the form "State_Name (UnityEngine.AnimationClip),
        // which Animator.Play cannot parse through. Below, we split up
        // the string and return only the "State_Name" string.
        string stateName = stateObjectName.Split(' ')[0];
        return stateName;
    }
}
