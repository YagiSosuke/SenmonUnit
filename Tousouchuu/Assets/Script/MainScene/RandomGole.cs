using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGole : MonoBehaviour
{
    [SerializeField] private GameObject[] Goal;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i< Goal.Length; i++)
        {
            Goal[i].SetActive(false);
        }
        Goal[Random.Range(0, Goal.Length - 1)].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
