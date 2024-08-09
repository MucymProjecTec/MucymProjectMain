using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField]    private List<GameObject> pieces;
    [SerializeField] private Collider coll;
    private UI_Manager4E _uiManager4E;
    public AudioSource audioFelicidades;
    public Animator _victoryAnimator;

    // Start is called before the first frame update
    void Start()
    {
        _uiManager4E = GameObject.Find("Canvas").GetComponent<UI_Manager4E>();
        
        _victoryAnimator = GameObject.Find("VictoryPanel").GetComponent<Animator>(); //Victory Panel Calling
        if (_uiManager4E != null) {
            _uiManager4E.StartTimer();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //To show victory screen
    public void ShowVictoryScreen()
    {
        _victoryAnimator.SetBool("ShowVictory", true);
        
    }

    //To check victory conditions
    private void OnTriggerStay(Collider other)
    {
        //To add the object to the count
        if(!(pieces.Contains(other.gameObject)) && FullyContains(other, coll))
        {
            pieces.Add(other.gameObject);

        }

        //To Remove the object from the count
        else if((pieces.Contains(other.gameObject)) && !FullyContains(other, coll))
        {
            pieces.Remove(other.gameObject);
        }

        //Victory Condition
        if (pieces.Count == 4) {                   
            _uiManager4E.StopTimer();
            ShowVictoryScreen();
        }
    }

    //To check if the piece is in the correct position to add to the count
    bool FullyContains(Collider resident, Collider zone, float tolerance = .01f)
    {
        if (zone == null)
        {
            return false;
        }

        //To Expand the zone bounds by the tolerance value
        Bounds expandedBounds = new Bounds(zone.bounds.center, zone.bounds.size + Vector3.one * tolerance);

        //To check if the expanded bounds contain the resident collider's bounds
        return expandedBounds.Contains(resident.bounds.min) &&
               expandedBounds.Contains(resident.bounds.max) &&
               expandedBounds.Contains(resident.bounds.center);
    }
}
