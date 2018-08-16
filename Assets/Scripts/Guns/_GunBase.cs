using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class _GunBase
    :
    MonoBehaviour
{
    protected void Initialize()
    {
        Assert.IsNotNull( transform.GetChild( 0 ) );
        Assert.IsNotNull( transform.GetChild( 1 ) );

        handlePos = transform.GetChild( 0 ).position;
        barrelPos = transform.GetChild( 1 ).position;

        bullet = Utility.GetPrefabHolder().playerBullet;
        Assert.IsNotNull( bullet );
    }
    // 
    protected Vector3 handlePos;
    protected Vector3 barrelPos;
    protected Timer shotTimer = new Timer( 1.0f );
    protected GameObject bullet;

}
