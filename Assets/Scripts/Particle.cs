using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Particle
    :
    MonoBehaviour
{
    void Start()
    {
        // SetColor( Color.blue );
        // JumpUp();
    }
    void Update()
    {
        if( destroying )
        {
            dest.Update();
            if( dest.IsDone() ) Destroy( gameObject );
        }
    }
    public void SetColor( Color col )
    {
        GetComponent<Renderer>().material.color = col;
    }
    public void JumpUp()
    {
        Rigidbody body = GetComponent<Rigidbody>();

        Assert.IsNotNull( body );

        var forceVec = new
            Vector3( Random.Range( -maxMove,maxMove ),
            Random.Range( minJump,maxJump ),
            Random.Range( -maxMove,maxMove ) );

        body.AddForce( forceVec,ForceMode.Impulse );
    }
    void OnTriggerEnter( Collider other )
    {
        if( other.tag != "Elf" )
        {
            destroying = true;
        }
    }
    // 
    const float maxMove = 1.2f;
    const float minJump = 8.4f;
    const float maxJump = 12.2f;
    Timer dest = new Timer( 1.0f );
    bool destroying = false;
    // Rigidbody body;
}
