using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet
    :
    MonoBehaviour
{
    void Update()
    {
        if( destroying ) destTimer.Update();
        if( destTimer.IsDone() )
        {
            Destroy( gameObject );
        }
    }
    void OnBecameInvisible()
    {
        StartDestroy();
    }
    void OnCollisionEnter( Collision coll )
    {
        StartDestroy();
    }
    void StartDestroy()
    {
        destroying = true;
    }
    // 
    Timer destTimer = new Timer( 1.0f );
    bool destroying = false;
}
