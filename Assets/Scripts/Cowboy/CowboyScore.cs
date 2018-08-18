using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class CowboyScore
    :
    MonoBehaviour
{
    void Start()
    {
        drawNumbers = Utility.FindInScene( "NumberHolder" )
            .GetComponent<NumberDrawerScript>();
        Assert.IsNotNull( drawNumbers );

        Assert.IsTrue( score == 0 );
    }
    void Update()
    {
        if( fading ) scoreStayTimer.Update();

        if( scoreStayTimer.IsDone() )
        {
            scoreStayTimer.Reset();
            fading = false;
            drawNumbers.DestroyNums();
        }
        else
        {
            drawNumbers.MoveNumsTo( GetNumPos() );
        }
    }
    public void AddScore( int amount )
    {
        fading = true;

        score += amount;
        drawNumbers.DestroyNums();
        drawNumbers.AddNums( drawNumbers.SplitToList( score ),
            GetNumPos() );
    }
    public void RemoveScore( int amount )
    {
        fading = true;

        score -= amount;
        drawNumbers.DestroyNums();
        drawNumbers.AddNums( drawNumbers.SplitToList( score ),
            GetNumPos() );
    }
    public int GetScore()
    {
        return( score );
    }
    Vector3 GetNumPos()
    {
        var pos = transform.position;
        var temp = new Vector3( pos.x,pos.y,pos.z );
        temp.y += posAdd;
        return( temp );
    }
    // 
    NumberDrawerScript drawNumbers;
    int score = 0;
    const float posAdd = 1.87f;
    Timer scoreStayTimer = new Timer( 1.7f );
    bool fading = false;
}
