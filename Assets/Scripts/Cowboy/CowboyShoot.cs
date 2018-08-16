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

        // bulletSpawnPos = transform.GetChild( 0 );
        handPos = transform.GetChild( 0 );

        gunTypes = Utility.GetGunTypeHolder();

        curGun = Instantiate( Utility.GetPrefabHolder()
            .starterGun );
        curGunScr = curGun.GetComponent<GunScript>();
        curGunStats = gunTypes.GetStats( curGunScr.myType );

        refire = new Timer( curGunStats.reloadTime );

        Assert.IsNotNull( bullet );
        Assert.IsNotNull( gunTypes );
        Assert.IsNotNull( curGun );
        Assert.IsNotNull( curGunScr );
    }
    void Update()
    {
        refire.Update();

        if( refire.IsDone() &&
            Input.GetAxis( "Attack" ) > 0.0f )
        {
            refire.Reset();

            for( int i = 0; i < curGunStats.nBullets; ++i )
            {
                GameObject tBull = Instantiate( bullet );
                var tBullScr = tBull.GetComponent<Bullet>();
                var bPos = tBull.transform;

                tBullScr.destTimer = new Timer( curGunStats.lifetime );
                // tBullScr.speed = curGunStats.speed;

                bPos.position = curGun.transform
                    .GetChild( 1 ).position;

                bPos.rotation = transform.rotation;
                var dev = curGunStats.spread;
                // Rotation for x, y, z axes.
                // bPos.Rotate( Vector3.left,Random.Range( -dev,dev ) ); // x
                bPos.Rotate( Vector3.up,Random.Range( -dev,dev ) ); // y
                // bPos.Rotate( Vector3.forward,Random.Range( -dev,dev ) ); // z

                tBull.GetComponent<Rigidbody>()
                    .AddForce( bPos.forward * curGunStats.speed,
                    ForceMode.Impulse );
            }
        }

        // curGun.transform.position = handPos.position;
        curGun.transform.position = handPos.position;
        curGun.transform.rotation = transform.rotation;
        curGun.transform.Rotate( Vector3.up,90.0f );
    }
    // 
    GameObject bullet;
    // const float bulletSpeed = Bullet.speed;
    // Vector3 bullFireOffset = new Vector3( 3.5f,3.0f,3.5f );
    // Transform bulletSpawnPos;
    Timer refire;
    const float accDev = 6.34f; // Degrees :(
    GunTypeHolder gunTypes;
    GameObject curGun;
    GunScript curGunScr;
    GunTypeHolder.GunStats curGunStats;
    Transform handPos;
}
