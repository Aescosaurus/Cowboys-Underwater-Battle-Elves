using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol
    :
    _GunBase
{
    void Start()
    {
        Initialize();
    }
    public void UpdateTimer( Quaternion rot,bool firing )
    {
        shotTimer.Update();

        if( firing )
        {
            shotTimer.Reset();

            var bull = Instantiate( bullet );
            bull.transform.position = barrelPos;
            bull.transform.rotation = rot;
        }
    }
}
