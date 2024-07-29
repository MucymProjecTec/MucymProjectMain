using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> selected = new List<GameObject>();

    private GameManager manager;

    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        if (manager == null)
        {
            Debug.LogError("GameManager not found!");
        }
    }

    void Update()
    {
        // No specific update logic required for now
    }

    public void addSelected(GameObject add)
    {
        if (selected.Count < 2)
        {
            if (selected.Contains(add))
            {
                selected.Remove(add);
            }
            else
            {
                selected.Add(add);
            }
        }

        if (selected.Count == 2)
        {
            SwapPositions(selected[0], selected[1]);

            // Deselecting using Unity's selection system
            selected[0].GetComponent<Renderer>().material.color = Color.white;
            selected[1].GetComponent<Renderer>().material.color = Color.white;

            // Clear the selection list
            selected.Clear();

            // Check win condition after swapping positions
            manager.checkAllPositions();
        }
    }

    private void SwapPositions(GameObject obj1, GameObject obj2)
    {
        Vector3 tempTrans = obj1.transform.position;
        obj1.transform.position = obj2.transform.position;
        obj2.transform.position = tempTrans;

        Debug.Log($"Swapped positions of {obj1.name} and {obj2.name}");
    }
}
