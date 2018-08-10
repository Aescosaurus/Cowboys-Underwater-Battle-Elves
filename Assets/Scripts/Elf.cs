using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elf
    :
    MonoBehaviour
{
    void Start()
    {
        part = Utility.GetPrefabHolder().particle;
    }
    void OnCollisionEnter( Collision coll )
    {
        if( coll.gameObject.tag == "Bullet" )
        {
            Destroy( coll.gameObject );

            --hp;

            if( hp < 1 )
            {
                CreateParticles( Random.Range( 7,11 ) );
                Destroy( gameObject );
            }
        }
    }
    void CreateParticles( int amount )
    {
        for( int i = 0; i < amount; ++i )
        {
            var temp = Instantiate( part );
            temp.transform.position = transform.position;

            var scr = temp.GetComponent<Particle>();
            scr.SetColor( myPartCol );
            scr.JumpUp();
        }
    }
    // 
    int hp = 7;
    GameObject part;
    Color myPartCol = new Color( 90.0f / 255.0f,
        197.0f / 255.0f,79.0f / 255.0f );
}
