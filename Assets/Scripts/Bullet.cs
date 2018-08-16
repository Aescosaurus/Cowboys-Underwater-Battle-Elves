using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Bullet
    :
    MonoBehaviour
{
    void Update()
    {
        Assert.IsNotNull( destTimer );

        // if( destroying )
        {
            destTimer.Update();
        }

        if( destTimer.IsDone() )
        {
            Destroy( gameObject );
        }
    }
    // Destroy even if not invisible.
    // void OnBecameInvisible()
    // {
    //     StartDestroy();
    // }
    // void OnCollisionEnter( Collision coll )
    // {
    //     StartDestroy();
    // }
    // void StartDestroy()
    // {
    //     destroying = true;
    // }
    // 
    public Timer destTimer;
    // bool destroying = false;

    // public float speed = 10.0f;
    public float damage;
}
