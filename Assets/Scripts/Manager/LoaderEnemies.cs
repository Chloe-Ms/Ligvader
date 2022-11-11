using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TimelinePrefab
{
    public GameObject _objectLoad;
    public float loadTime;
    [HideInInspector]
    public bool deleted;
}

public class LoaderEnemies : MonoBehaviour
{
    private static LoaderEnemies instance;
    [SerializeField] List<TimelinePrefab> _mobileEnemies;
    [SerializeField] List<GameObject> _staticEnemies;

    public static LoaderEnemies Instance {
        get { return instance; }
        private set { instance = value; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);  

        instance = this;
        LoadNewStaticEnemies();
    }
    void Update()
    {
        /*for (int i = 0; i < _mobileEnemies.Count; i++)
        {
            if (_mobileEnemies[i].loadTime <= Time.timeSinceLevelLoad && !_mobileEnemies[i].deleted)
            {
                Instantiate(_mobileEnemies[i]._objectLoad);
                _mobileEnemies[i].deleted = true;
            }
        }*/
            
    }

    public void LoadNewStaticEnemies()
    {
        if (_staticEnemies.Count == 0)
            return;
        int index = Random.Range(0, _staticEnemies.Count);

        Instantiate(_staticEnemies[index]) ;
    }
}
