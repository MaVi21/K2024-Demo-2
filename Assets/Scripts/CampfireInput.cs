using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampfireInput : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject campfire;

    // Start is called before the first frame update
    void Start()
    {
        this.enabled = false;    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            print("F key was pressed");
            Transform FPSCharacter = GameObject.Find("PlayerCapsule").transform;
            Vector3 pos = FPSCharacter.position + FPSCharacter.forward * 2;
            pos.y = Terrain.activeTerrain.SampleHeight(pos) + Terrain.activeTerrain.transform.position.y;
            Instantiate(campfire, pos, Quaternion.identity);
        }
    }
}
