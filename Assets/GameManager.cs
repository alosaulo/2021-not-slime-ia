using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject Player;
    
    [SerializeField]
    GameObject TelaGameOver;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtivarTelaGameOver()
    {
        TelaGameOver.SetActive(true);
    }

    public void DesativarTelaGameOver() {
        TelaGameOver.SetActive(false);
    }

}
