﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : CharacterStat
{
    public override void Die()
    {
        base.Die();
        // Add ragdoll effect/ Death animation
        Destroy(gameObject);
    }
}
