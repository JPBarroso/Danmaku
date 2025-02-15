using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RadialShotSettings
{
    [Header("Base Settings")]
    public int NumberOfBullets = 5;
    public float BulletSpeed = 10f;
    public float CooldownAfterShot;
    [Header("Offsets")]
    [Range(-180f, 180f)] public float AngleOffset = 0f;
    [Range(-1f, 1f)] public float PhaseOffset = 0f;
    [Header("Mask")]
    public bool RadialMask;
    [Range(0f, 360f)] public float MaskAngle = 360f;


}
