using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxer : MonoBehaviour
{
    // Keeps track of clouds and pipes
    class PoolObject
    {
        public Transform transform;
        public bool inUse;
        public PoolObject(Transform t) { transform = t; }
        
        public void Use() { inUse = true; }

        public void Dispose() { inUse = false; }
    }

    public GameObject Prefab;           // Type of prefab
    public int poolSize;
    public float shiftSpeed;
    public float spawnRate;

    public Vector3 defaultSpawnPos;
    public bool spawnImmediate;
    public Vector3 immediateSpawnPos;
    public Vector2 targetAspect;         // Check for screen ratios
}
