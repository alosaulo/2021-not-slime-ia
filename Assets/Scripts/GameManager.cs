using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject Player;

    public Transform[] Waypoints;

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

    public Transform GetWaypoint(int i) {
        return Waypoints[i];
    }

    public Transform GetWaypointPerto(Vector2 position) {
        float distancia = float.MaxValue;
        float distanciaAux;
        Transform waypoint = Waypoints[0];
        for (int i = 0; i < Waypoints.Length; i++)
        {
            distanciaAux = Vector2.Distance(position, Waypoints[i].position);
            if (distancia > distanciaAux) {
                distancia = distanciaAux;
                waypoint = Waypoints[i];
            }
        }
        return waypoint;
    }

    public Transform GetWaypointSeguinte(Transform waypointAtual) {
        for (int i = 0; i < Waypoints.Length; i++)
        {
            if (Waypoints[i] == waypointAtual) 
            {
                if (i < Waypoints.Length - 1)
                    return Waypoints[i + 1];
                else
                    return Waypoints[0];
            }
        }
        return waypointAtual;
    }


}
