using UnityEngine;
using DG.Tweening;

public class CameraFollowObject : MonoBehaviour
{
    [SerializeField] private Transform _gameObjectTransform;
    [SerializeField] private Vector3 _cameraOffset;
    private float _cameraZPosition;
    private float _cameraDampeningSpeed = 2f;

    void Start()
    {
        _cameraZPosition = this.transform.position.z;
        _cameraOffset = Vector3.zero;
    }

    void Update()
    {
        Vector3 objectPosition = GetObjectPosition();
        this.transform.DOMove(objectPosition, _cameraDampeningSpeed);
    }

    private Vector3 GetObjectPosition()
    {
        Vector3 objectPostition = _gameObjectTransform.position;
        objectPostition = new Vector3(objectPostition.x, objectPostition.y, _cameraZPosition);
        objectPostition += _cameraOffset;
        return objectPostition;
    }

    
}
