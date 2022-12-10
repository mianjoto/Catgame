using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStates {
    Idling,
    Walking
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerStates CurrentPlayerState { get; set; }
    [HideInInspector] public Vector2 Movement;

    private Rigidbody2D _rb;
    private Transform _trans;
    [SerializeField] private float _walkSpeed = 2f;

    void Start()
    {
        _rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    public void MoveCharacter() {
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");

        if (Movement.sqrMagnitude == 0)
        {
            CurrentPlayerState = PlayerStates.Idling;
            return;
        }

        bool movingRight = Movement.x > 0;
        bool movingLeft = Movement.x < 0;
        bool movingUp = Movement.y > 0;
        bool movingDown = Movement.y < 0;
        
        if (movingRight)
        {
            _rb.transform.Translate(Vector2.right * _walkSpeed * Time.deltaTime, Space.World);
        }
        if (movingLeft) 
        {
            _rb.transform.Translate(Vector2.left * _walkSpeed * Time.deltaTime, Space.World);
        }
        if (movingDown)
        {
            _rb.transform.Translate(Vector2.down * _walkSpeed * Time.deltaTime, Space.World);
        } 
        if (movingUp)
        {
            _rb.transform.Translate(Vector2.up * _walkSpeed * Time.deltaTime, Space.World);
        }

        CurrentPlayerState = PlayerStates.Walking;
    }
}
