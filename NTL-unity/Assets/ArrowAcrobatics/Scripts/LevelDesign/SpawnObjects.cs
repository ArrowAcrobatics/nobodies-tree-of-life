using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject[] spawnables = new GameObject[0];

    public Vector2 gridDimensions = new Vector2(10f, 10f);
    public Vector2Int gridCount = new Vector2Int(10, 10);
    public float offsetRadius = 0.5f;

    public void Spawn() {
        Debug.Log("hi");

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
                // public static Object Instantiate(Object original, Vector3 position, Quaternion rotation, Transform parent);
                Instantiate(
                    spawnables[Random.Range(0, spawnables.Length)], 
                    startPos + new Vector3(x*dx, transform.position.y, z*dz), 
                    Quaternion.identity, 
                    transform);
            }
        }
    }

    public void Clear() {
        // oops iterates while modifying itself...
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
