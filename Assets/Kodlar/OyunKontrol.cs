using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OyunKontrol : MonoBehaviour
{
    [SerializeField] private GameObject asteroid;
    [SerializeField] private Vector3 randomPos;
    [SerializeField] private float baslangicBekleme;
    [SerializeField] private float olusturmaBekleme;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private TMP_Text restartText;

    [SerializeField] private int WinScore;

    [SerializeField] private GameObject Patlama;
    
    
    int score;
    bool yenidenBaslaKontrol = false;
    bool oyunBittiKontrol = false;

    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score;
        StartCoroutine(AsteroidOlustur());
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && yenidenBaslaKontrol)
        {
            SceneManager.LoadScene("Level1");
        }
    }
    IEnumerator AsteroidOlustur()
    {
        yield return new WaitForSeconds(baslangicBekleme);
        while(true)
        {
            if(!oyunBittiKontrol)
            {
                Vector3 vec = new Vector3(Random.Range(-randomPos.x, randomPos.x), 0, randomPos.z);
                Instantiate(asteroid, vec, Quaternion.identity);
                yield return new WaitForSeconds(olusturmaBekleme);
            }

            if (oyunBittiKontrol)
            {
                restartText.text = "Press R to restart.";
                yenidenBaslaKontrol = true;
                break;
            }
        }
    }
    public void ScoreArttir (int gelenScore)
    {
        score += gelenScore;
        scoreText.text = "Score: " + score;
        if (score >= WinScore)
            Kazandin();
    }
    public void OyunBitti()
    {
        gameOverText.text = "GAME OVER!!";
        oyunBittiKontrol = true;
    }

    private void Kazandin()
    {
        gameOverText.text = "YOU WIN!!";
        oyunBittiKontrol = true;
        var clones = GameObject.FindGameObjectsWithTag("asteroid");
        foreach (var clone in clones)
        {
            Instantiate(Patlama, clone.transform.position, clone.transform.rotation);
            Destroy(clone);
        }
    }
}
