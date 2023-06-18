using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryGameMode : GameMode
{
    public override void StartNewWave()
    {
        
    }

    protected override void IncrementCountKilled()
    {
        _countKilledEnemyForWave++;
        Progress.SaveIncrementSumKill();
    }
}
