using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class CowboyMove
    :
    MonoBehaviour
{
    void Start()
    {
        body = GetComponent<Rigidbody>();
        camMove = Camera.main.GetComponent<CameraMove>();
    }
    void Update()
    {
        Assert.IsNotNull( body );
        Assert.IsNotNull( camMove );

        float up = Input.GetAxis( "Move Up" );
        float down = Input.GetAxis( "Move Down" );
        float left = Input.GetAxis( "Move Left" );
        float right = Input.GetAxis( "Move Right" );

        Vector2 move = new
            Vector2( right - left,up - down );

        // Pretty important if you want accurate mvmt.
        move.Normalize();

        Vector3 move3D = new Vector3( move.x,0.0f,move.y );

        if( move.x != 0.0f || move.y != 0.0f )
        {
            if( Input.GetAxis( "Turn Around" ) > 0.0f )
            {
                transform.rotation = Quaternion
                    .RotateTowards( transform.rotation,
                    Quaternion.LookRotation( -move3D ),
                    rotSpeed );
                // transform.rotation = Quaternion.LookRotation( -move3D );
            }
            else
            {
                transform.rotation = Quaternion
                    .RotateTowards( transform.rotation,
                    Quaternion.LookRotation( move3D ),
                    rotSpeed );
            }
        }

        if( Input.GetKey( KeyCode.LeftShift ) )
        {
            body.AddForce( move3D * speed * 7,
                ForceMode.Impulse );
        }
        else
        {
            body.AddForce( move3D * speed,
                ForceMode.Impulse );
        }

        Vector3 temp = body.velocity;
        temp.x = 0.0f;
        temp.z = 0.0f;
        body.velocity = temp;

        camMove.MoveBy( transform.position );

        // This prevents you from spinning in circles randomly.
        body.angularVelocity = Vector3.zero;
    }
    // 
    Rigidbody body;
    const float speed = 4.4f;
    const float rotSpeed = 7.5f;
    CameraMove camMove;
}
