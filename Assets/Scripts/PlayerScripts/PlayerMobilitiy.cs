using UnityEngine;
using System.Collections;
using System;

public class PlayerMobilitiy : MonoBehaviour
{
    private const float MoveSpeed = 2.0f;
    private int _verticalKey;
    private int _horizontalKey;
    private Animator _playerMovementController;

    // Use this for initialization
	void Start ()
	{
	    _playerMovementController = GetComponent<Animator>();
	    _verticalKey = Animator.StringToHash("moveVertical");
	    _horizontalKey = Animator.StringToHash("moveHorizontal");

        currentVector = new Vector3(transform.position.x, transform.position.y + -0.5f);
	}
	
    void FixedUpdate()
    {
        var moveX = Input.GetAxisRaw("Horizontal");
        var moveY = Input.GetAxisRaw("Vertical");

        // Set motion vector
        rigidbody2D.velocity = new Vector2(moveX * MoveSpeed, moveY * MoveSpeed);

        // Update animations
        _playerMovementController.SetInteger(_verticalKey, (int)moveY);
        _playerMovementController.SetInteger(_horizontalKey, (int)moveX);

        // debug code
        //drawDebugDirection();
    }

    private Vector3 currentVector;
    private const float angle = 25f * (Mathf.PI / 180f);

    private void drawDebugDirection()
    {
        var playerPosition = transform.position;
        var xAxis = Input.GetAxisRaw("Horizontal");
        var yAxis = Input.GetAxisRaw("Vertical");

        if (Math.Abs(xAxis - 0f) > float.Epsilon || Math.Abs(yAxis - 0f) > float.Epsilon)
        {
            currentVector = new Vector3(playerPosition.x + (xAxis*.5f), playerPosition.y + (yAxis*.5f));
        }
        // Origin line
        Debug.DrawLine(playerPosition, currentVector, Color.red);

        // Left vision line
        var yellowVector = new Vector3(getXRotation(angle, playerPosition, currentVector),
                                       getYRotation(angle, playerPosition, currentVector));
        Debug.DrawLine(playerPosition, yellowVector, Color.yellow);

        // Right vision line
        var blueVector =
            new Vector3(getXRotation(-angle, playerPosition, currentVector),
                        getYRotation(-angle, playerPosition, currentVector));
        Debug.DrawLine(playerPosition, blueVector, Color.cyan);
    }

    private float getXRotation(float angle, Vector3 origin, Vector3 point)
    {
        return Mathf.Cos(angle)*(point.x - origin.x) - Mathf.Sin(angle)*(point.y - origin.y) + origin.x;
    }

    private float getYRotation(float angle, Vector3 origin, Vector3 point)
    {
        return Mathf.Sin(angle) * (point.x - origin.x) + Mathf.Cos(angle) * (point.y - origin.y) + origin.y;
    }
}
