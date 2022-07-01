using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    public GameObject collectBallEffect;
    public GameObject collectXBallEffect;
    public GameObject collectMonsterEffect;
    public GameObject monsterHitEffect;

    public static ParticleSpawner Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void spawnParticle(GameObject go, float destroyTime, Vector3 pos)
    {
        GameObject effect = Instantiate(go, pos, Quaternion.identity);
        Destroy(effect,destroyTime);
    }
}

