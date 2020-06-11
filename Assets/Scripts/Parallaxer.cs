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
}
