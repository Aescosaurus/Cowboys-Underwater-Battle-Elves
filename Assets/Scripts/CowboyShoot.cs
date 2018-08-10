using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class CowboyShoot
    :
    MonoBehaviour
{
    void Start()
    {
        bullet = Utility.GetPrefabHolder().playerBullet;

        bulletSpawnPos = transform.GetChild( 0 );
    }
    void Update()
    {
        Assert.IsNotNull( bullet );

        refire.Update();

        if( refire.IsDone() &&
            Input.GetAxis( "Attack" ) > 0.0f )
        {
            refire.Reset();

            GameObject tBull = Instantiate( bullet );

            Quaternion rot = transform.rotation;
            tBull.transform.position = bulletSpawnPos.position;

            tBull.transform.rotation = transform.rotation;

            tBull.GetComponent<Rigidbody>()
                .AddForce( transform.forward * bulletSpeed,
                ForceMode.Impulse );
        }
    }
    // 
    GameObject bullet;
    const float bulletSpeed = 10.0f;
    // Vector3 bullFireOffset = new Vector3( 3.5f,3.0f,3.5f );
    Transform bulletSpawnPos;
    Timer refire = new Timer( 0.2f );
}
