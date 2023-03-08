using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnObjects : MonoBehaviour {
    public GameObject[] spawnables = new GameObject[0];

    public Vector2 gridDimensions = new Vector2(10f, 10f);
    public Vector2Int gridCount = new Vector2Int(10, 10);
    
    public float offsetRadius = 0.5f;
    public Vector2 scaleRange = new Vector2(1.0f, 1.0f);
    public Vector2 rotateRange = Vector2.zero;

    public void Spawn() {
        if (!ValidParams()) {
            return;
        }

        Clear();

        float dx = gridDimensions.x / (gridCount.x - 1);
        float dz = gridDimensions.y / (gridCount.y - 1);

        Vector3 startPos = -0.5f*gridDimensions;
        startPos = Swizzle(startPos);

        for (int x = 0; x < gridCount.x; x++) {
            for (int z = 0; z < gridCount.y; z++) { // watch the swizzle
                GameObject spawnobject = spawnables[Random.Range(0, spawnables.Length)];

                GameObject inst = Instantiate(
                    spawnobject,
                    startPos
                        + new Vector3(x*dx, transform.position.y, z*dz)
                        + Swizzle(offsetRadius * Random.insideUnitCircle),
                    Quaternion.AngleAxis(Random.Range(rotateRange.x, rotateRange.y), Vector3.up),
                    transform);

                inst.transform.localScale *= Random.Range(scaleRange.x, scaleRange.y);
            }
        }
    }

    public void Clear() {
        List<GameObject> children = new List<GameObject>();

        foreach(Transform child in transform) {
            children.Add(child.gameObject);
        }

        foreach(GameObject child in children) {
#if UNITY_EDITOR
            DestroyImmediate(child.gameObject);
#else
            Destroy(child);
#endif
        }
    }

    bool ValidParams() {
        // note: behaves unpretty with x or y == 1
        return gridCount.x > 1 && gridCount.y > 1;
    }

    // we're in a y up system here :,)
    Vector3 Swizzle(Vector3 v) {
        return new Vector3(v.x, v.z, v.y);
    }
}
