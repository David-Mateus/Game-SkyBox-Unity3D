using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    public GameObject hazardPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnHazards());
    }

    private IEnumerator SpawnHazards()
    {
        var x = Random.Range(-7, 7);
        Instantiate(hazardPrefab, new Vector3(x,11,0), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        yield return SpawnHazards();
    }
}
