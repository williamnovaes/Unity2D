using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private Sprite sprite;
    private SpriteRenderer brickRenderer;
    private int hits;
    [SerializeField] private int score;

    // Start is called before the first frame update
    void Start()
    {
        brickRenderer = GetComponent<SpriteRenderer>();
        hits = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage() {
        GameManager gm = FindObjectOfType<GameManager>();
        if (gm != null) {
            gm.Goal(score);
        }
        if (hits > 1) {
            --hits;
            brickRenderer.sprite = sprite;
        } else {
            if (gm != null) {
                gm.BrickDestroy();
            }
            Destroy(gameObject);
        }
    }
}
