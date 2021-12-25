using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public static CheckpointController instance;
    public Checkpoint[] Checkpoints;

    public Vector3 spawnPoint;

    void Awake() {
        instance = this;
    }

    private void Start() {
        Checkpoints = FindObjectsOfType<Checkpoint>();
        spawnPoint = playerController.instance.transform.position;
    }
    // Update is called once per frame
    
    public void DeactivateCheckPoints(){
        for(int i = 0; i < Checkpoints.Length; i++) {
            Checkpoints[i].ResetCheckpoint();
        }
    }


    public void SetSpawnPoint(Vector3 newSpawnPoint) 
    {
        spawnPoint = newSpawnPoint;
    }
}
