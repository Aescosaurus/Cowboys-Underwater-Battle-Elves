using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    public Timer( float max )
    {
        this.max = max;
    }
    public void Update()
    {
        if( cur <= max ) cur += Time.deltaTime;
    }
    public void Reset()
    {
        cur = 0.0f;
    }
    public bool IsDone()
    {
        return ( cur >= max );
    }
    public float GetPercent()
    {
        return ( cur / max );
    }
    // 
    float max;
    float cur = 0.0f;
}
