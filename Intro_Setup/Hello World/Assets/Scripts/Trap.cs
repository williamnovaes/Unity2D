using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    public GameObject prefab;
    public Transform spawnBlocks;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag.Equals("Player")) {
            GameObject tempPrefab = Instantiate(prefab) as GameObject;
            tempPrefab.transform.position = spawnBlocks.position;
        }
    }
}
