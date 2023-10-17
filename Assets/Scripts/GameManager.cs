using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{   
    public GameObject hazardPrefab;
    public int maxHazards = 3;
    public TMPro.TextMeshPro scoreText;
    public Image backgrundMenu;
    public GameObject player;
    
    private int score = 0;
    private float timer;
    private Coroutine hazardsCoroutine;
    private  bool gameOver;
    private static GameManager instance;
    public static GameManager Instance => instance;
    public GameObject gameOverMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
    }

    private void OnEnable() {
        player.SetActive(true);
        gameOver = false;
        score = 0;
        timer = 0;
        hazardsCoroutine = StartCoroutine(SpawnHazards());
    }
    public void Enable(){
        gameObject.SetActive(true);
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
           PausarJogo();
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
    public  void GameOver(){
        StopCoroutine(hazardsCoroutine);
        gameOver = true;
        gameObject.SetActive(false);
        gameOverMenu.SetActive(true);
        
        
    }
    
    public void PausarJogo(){
        if(Time.timeScale == 1){
            Time.timeScale = 0;
            backgrundMenu.gameObject.SetActive(true);
        }else{
            Time.timeScale = 1;
            backgrundMenu.gameObject.SetActive(false);
        }
    }
    
    
}
