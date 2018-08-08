using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove
    :
    MonoBehaviour
{
    void Start()
    {
        var pos = transform.position;
        origPos.Set( pos.x,pos.y,pos.z );
    }
    public void MoveBy( Vector3 delta )
    {
        transform.position = origPos + delta;
    }
    // 
    Vector3 origPos = new Vector3( 0.0f,0.0f,0.0f );
}
