using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elf
    :
    MonoBehaviour
{
    void OnCollisionEnter( Collision coll )
    {
        if( coll.gameObject.tag == "Bullet" )
        {
            Destroy( coll.gameObject );

            --hp;

            if( hp < 1 ) Destroy( gameObject );
        }
    }
    // 
    int hp = 7;
}
