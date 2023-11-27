using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnImage : MonoBehaviour
{
     public GameObject imagePrefab;
     public GameObject imageBounds;
     public GameObject imageHounds;
     private BoundingBox bounds;
     private BoundingBox hounds;
     private int catId = 1;
     private int dogId = 1;
    // Start is called before the first frame update
    void Start()
    {
        hounds = imageHounds.GetComponent<BoundingBox>();
        bounds = imageBounds.GetComponent<BoundingBox>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump")){
            Vector3 spawnPos = bounds.getSpawnLocation();
            Debug.Log(spawnPos);
            if (spawnPos.Equals(Vector3.negativeInfinity)){
                return;
            }
            Sprite nextSprite = Resources.Load<Sprite>("Images/cat" + catId.ToString());
            GameObject image = Instantiate(imagePrefab, spawnPos, Quaternion.identity);
            SpriteRenderer mySprite = image.GetComponent<SpriteRenderer>();
            mySprite.sprite = nextSprite;
            mySprite.transform.parent = imageBounds.transform;

            catId++;
            if (catId >= 6){
                catId = 1;
            }
        }
        else if (Input.GetButtonDown("Fire3")){
            Vector3 spawnPos = hounds.getSpawnLocation();
            Debug.Log(spawnPos);
            if (spawnPos.Equals(Vector3.negativeInfinity)){
                return;
            }
            Sprite nextSprite = Resources.Load<Sprite>("Images/pup" + dogId.ToString());
            GameObject image = Instantiate(imagePrefab, spawnPos, Quaternion.identity);
            SpriteRenderer mySprite = image.GetComponent<SpriteRenderer>();
            mySprite.sprite = nextSprite;
            mySprite.transform.parent = imageHounds.transform;

            dogId++;
            if (dogId >= 6){
                dogId = 1;
            }
        }
    }
}
