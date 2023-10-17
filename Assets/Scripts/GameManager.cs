using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    public GameObject hazardPrefab;
    public int maxHazards = 3;
    public TMPro.TextMeshPro scoreText;
    
    private int score = 0;
    private float timer;
    private static bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnHazards());
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
           PausarJogo();
        }
        if(Input.GetKeyDown(KeyCode.R)){
           ReniciarJogo();
        }
        if(gameOver){
            return;
        }
        timer += Time.deltaTime;
       if(timer >= 1f){
           score++;
           scoreText.text = score.ToString();
           timer = 0;
       }
    }

    private IEnumerator SpawnHazards()
    {
        var hazardToSpawn = Random.Range(1, maxHazards);
        for(int i = 0; i < hazardToSpawn; i++){
            var x = Random.Range(-7, 7);
            var drag = Random.Range(0f, 2f);

            var hazard = Instantiate(hazardPrefab, new Vector3(x,11,0), Quaternion.identity);
            hazard.GetComponent<Rigidbody>().drag = drag;
        }
        
        yield return new WaitForSeconds(1f);
        yield return SpawnHazards();
    }
    public static void GameOver(){
        gameOver = true;
    }
    
    public void PausarJogo(){
        if(Time.timeScale == 1){
            Time.timeScale = 0;
        }else{
            Time.timeScale = 1;
        }
    }
    public  void ReniciarJogo(){
        Application.LoadLevel(Application.loadedLevel);
        score++;
    }
    
}
