using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafManager : MonoBehaviour
{

    [SerializeField] private float _height;
    [SerializeField] private List<GameObject> _leafPrefabs;
    [SerializeField] private Transform _leafContainer;
    [SerializeField] private Vector2 _leafTiltRange;
    [SerializeField] private Vector2 _leafRotationRange;

    private List<Vector3> _leafLocations;
    private GameEventManager _gameEventManager;
    

    private void Awake()
    {
        _gameEventManager = GameEventManager.Instance;

        _leafLocations =new List<Vector3>() {
            new Vector3(7, 0, 7),
            new Vector3(7, 0, -7),
            new Vector3(-7, 0, 7),
            new Vector3(-7, 0, -7),
        };
    }

    private void OnEnable() 
    {
        _gameEventManager.onPlayerReset += OnPlayerReset;
    }

    void OnDisable()
    {
        _gameEventManager.onPlayerReset -= OnPlayerReset;
    }

    private void Start()
    {
        for (int i = 0; i < _height; i ++)
        {
            GameObject newLeaf = CreateLeaf();
            SetupLeaf(newLeaf, i);
        }
    }

    private GameObject CreateLeaf()
    {
        GameObject chosenLeaf = _leafPrefabs[Random.Range(0, _leafPrefabs.Count)];
        GameObject newLeaf = Instantiate(chosenLeaf, _leafLocations[Random.Range(0, _leafLocations.Count)], Quaternion.identity);

        return newLeaf;
    }

    private void SetupLeaf(GameObject leaf, int i)
    {
        leaf.name = "Leaf: " + i;
        leaf.transform.SetParent(_leafContainer);
        leaf.transform.position += new Vector3(0, i, 0);

        float tiltFactor = Random.Range(_leafTiltRange.x, _leafTiltRange.y + 1);

        // NE
        if (leaf.transform.position.x > 0 && leaf.transform.position.z > 0)
        {
            leaf.transform.rotation = Quaternion.Euler(-tiltFactor, Random.Range(_leafRotationRange.x, _leafRotationRange.y), tiltFactor);
        }

        // NW
        if (leaf.transform.position.x < 0 && leaf.transform.position.z > 0)
        {
            leaf.transform.rotation = Quaternion.Euler(-tiltFactor, Random.Range(_leafRotationRange.x, _leafRotationRange.y), -tiltFactor);
        }

        // SE
        if (leaf.transform.position.x > 0 && leaf.transform.position.z < 0)
        {
            leaf.transform.rotation = Quaternion.Euler(tiltFactor, Random.Range(_leafRotationRange.x, _leafRotationRange.y), tiltFactor);
        }

        // SW
        if (leaf.transform.position.x < 0 && leaf.transform.position.z < 0)
        {
            leaf.transform.rotation = Quaternion.Euler(tiltFactor, Random.Range(_leafRotationRange.x, _leafRotationRange.y), -tiltFactor);
        }
    }


    private void OnPlayerReset()
    {
        foreach (Transform leaf in _leafContainer.GetComponentInChildren<Transform>(true))
        {
            leaf.gameObject.SetActive(true);
        }
    }

}
