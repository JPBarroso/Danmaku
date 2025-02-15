using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialShotWeapon : MonoBehaviour
{
    [SerializeField] private RadialShotPattern _shotPattern;
    private bool _onShotPattern = false;

    private void Update()
    {
        if (_onShotPattern)
        {
            return;
        }
        StartCoroutine(ExecuteRadialShotPattern(_shotPattern));
    }
    private IEnumerator ExecuteRadialShotPattern(RadialShotPattern pattern)
    {
        _onShotPattern = true;
        int lap = 0;
        Vector2 aimDirection = transform.up;
        Vector2 center = transform.position;

        yield return new WaitForSeconds(pattern.StartWait);
        while(lap < pattern.Repetitions)
        {
            if(lap >0 && pattern.AngleOffsetBetweenReps != 0f)
            {
                aimDirection = aimDirection.Rotate(pattern.AngleOffsetBetweenReps);
            }
            for (int i = 0; i< pattern.PatternSettings.Length; i++)
            {
                ShotAttack.RadialShot(center, aimDirection, pattern.PatternSettings[i]);
                yield return new WaitForSeconds(pattern.PatternSettings[i].CooldownAfterShot);
            }
            lap++;
        }
        yield return new WaitForSeconds(pattern.EndWait);
        _onShotPattern = false;

    }
}
