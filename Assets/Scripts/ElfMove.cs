using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ElfMove
    :
    MonoBehaviour
{
    void Start()
    {
        player = Utility.FindInScene( "Cowboy" );

        body = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Assert.IsNotNull( player );
        Assert.IsNotNull( body );

        var target = player.transform.position;
        var diff = target - transform.position;
        diff.Normalize();

        var move3D = new Vector3( diff.x,0.0f,diff.z );

        transform.rotation = Quaternion.LookRotation( -move3D );

        body.AddForce( move3D * speed,
                ForceMode.Impulse );

        Vector3 temp = body.velocity;
        temp.x = 0.0f;
        temp.z = 0.0f;
        body.velocity = temp;
    }
    // 
    GameObject player;
    const float speed = 2.4f;
    Rigidbody body;
}
