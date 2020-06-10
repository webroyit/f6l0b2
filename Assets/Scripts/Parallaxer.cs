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
}
