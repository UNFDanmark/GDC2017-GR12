using UnityEngine;
using System.Collections;

public class ObjectiveSpawnerScript : MonoBehaviour {

    public MeshRenderer objectiveSpawner;
    public SphereCollider sphereCollider;
    public bool decider = false;

	// Use this for initialization
	void Start () {
        objectiveSpawner = GetComponent<MeshRenderer>();
        sphereCollider = GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
	void Update () {
        if (decider)
        {
            objectiveSpawner.enabled = true;
            sphereCollider.enabled = true;
            decider = false;
        }
	}
}