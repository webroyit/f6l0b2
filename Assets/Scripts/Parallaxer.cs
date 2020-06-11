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

    // Spawn the pipe random on the y-axis
    [System.Serializable]
    public struct YSpawnRange
    {
        public float min;
        public float max;
    }

    public GameObject Prefab;           // Type of prefab
    public int poolSize;
    public float shiftSpeed;
    public float spawnRate;

    public YSpawnRange ySpawnRange;
    public Vector3 defaultSpawnPos;
    public bool spawnImmediate;
    public Vector3 immediateSpawnPos;
    public Vector2 targetAspectRatio;         // Check for screen ratios

    float spawnTimer;
    float targetAspect;

    PoolObject[] poolObjects;
    GameManager game;                // Refer to the game manager

    void Awake()
    {
        Configure();
    }

    // Subscribe these event
    void OnEnable()
    {
        GameManager.OnGameOverConfirmed += OnGameOverConfirmed;
    }

    void OnDisable()
    {
        GameManager.OnGameOverConfirmed -= OnGameOverConfirmed;
    }

    void Start()
    {
        game = GameManager.Instance;
    }

    void OnGameOverConfirmed()
    {
        Configure();
    }

    void Configure()
    {

    }

    void CheckDisposeObject(PoolObject poolObject)
    {
        // - for negative direction or off screen
        if(poolObject.transform.position.x < -defaultSpawnPos.x)
        {
            poolObject.Dispose();

            // Move the pool object off the screen
            poolObject.transform.postiion = Vector3.one * 1000;
        }
    }

    // Get the available pool object
    Transform GetPoolObject()
    {
        // Get the first available pool object
        for(int i = 0; i < poolObjects.Length; i++)
        {
            if(!poolObjects[i].inUse)
            {
                // Make sure to not use pool object when it goes off the screen
                poolObjects[i].Use();

                return poolObjects[i].transform;
            }
        }

        return null;
    }
}
