using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFollowPlayer : MonoBehaviour
{
    private Transform _playerTransform;
    private float _cameraZPosition;
    private float _cameraDampeningSpeed = 1f;

    void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _cameraZPosition = this.transform.position.z;
    }

    void Update()
    {
        Vector3 playerPosition = GetPlayerPosition();
        this.transform.DOMove(playerPosition, _cameraDampeningSpeed);
    }

    private Vector3 GetPlayerPosition()
    {
        Vector3 _playerPosition = _playerTransform.position;
        _playerPosition = new Vector3(_playerPosition.x, _playerPosition.y, _cameraZPosition);
        return _playerPosition;
    }
}
