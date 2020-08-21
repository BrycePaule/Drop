using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafManager : MonoBehaviour
{

    [SerializeField] private float _height;
    [SerializeField] private List<GameObject> _leaves;
    [SerializeField] private Transform _leafContainer;


    private List<Vector3> _locations;
    

    private void Awake()
    {
        _locations =new List<Vector3>() {
            new Vector3(7, 0, 7),
            new Vector3(7, 0, -7),
            new Vector3(-7, 0, 7),
            new Vector3(-7, 0, -7),
        };
    }

    private void Start()
    {
        for (int i = 0; i < _height; i += 3)
        {
            GameObject chosenLeaf = _leaves[Random.Range(0, _leaves.Count)];

            GameObject newLeaf = Instantiate(chosenLeaf, _locations[Random.Range(0, _locations.Count)], Quaternion.identity);

            if (i == 0)
            {
                newLeaf.transform.position = _locations[0];
            }

            newLeaf.name = "Layer: " + i;
            newLeaf.transform.SetParent(_leafContainer);
            newLeaf.transform.position += new Vector3(0, i, 0);
        }
    }


}
