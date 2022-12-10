using UnityEngine;

/// <summary>
/// Flips an GameObject's X scale if the GameObject is moving 
/// to the right and facing left, and vice versa.
/// </summary>
public class Flip : MonoBehaviour
{
    [SerializeField]
    [Header("Set to true if the sprite is facing left when the scene starts")]
    private bool _isFacingLeft;
    private Vector3 _previousPosition;

    void Start()
    {
        _previousPosition = this.transform.position;
    }

    void FixedUpdate()
    {
        if (_previousPosition == this.transform.position)
            return;

        if (FacingWrongDirection())
            FlipTransform();

        _previousPosition = this.transform.position;
    }


    private bool FacingWrongDirection()
    {
        bool movingRight = transform.position.x > _previousPosition.x;
        bool movingLeft = transform.position.x < _previousPosition.x;
        bool movingRightAndFacingLeft = movingRight && _isFacingLeft;
        bool movingLeftAndFacingRight = movingLeft && !_isFacingLeft;

        if (movingLeftAndFacingRight || movingRightAndFacingLeft)
            return true;
        else
            return false;
    }

    private void FlipTransform()
    {
        Vector3 currentScale = this.gameObject.transform.localScale;
        currentScale.x *= -1;
        this.gameObject.transform.localScale = currentScale;
        _isFacingLeft = !_isFacingLeft;
    }
}
