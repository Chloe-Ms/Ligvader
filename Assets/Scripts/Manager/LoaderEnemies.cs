using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
/*public class TimelinePrefab
{
    public GameObject _objectLoad;
    public float loadTime;
    [HideInInspector]
    public bool deleted;
}*/

public class LoaderEnemies : MonoBehaviour
{
    private static LoaderEnemies instance;
    [SerializeField] List<GameObject> _mobileEnemies;
    [SerializeField] List<GameObject> _ufoEnemies;
    [SerializeField] List<GameObject> _staticEnemies;
    [SerializeField] float _secBeforeRespawnMobile = 10;
    [SerializeField] float _secBeforeRespawnUFO = 40;

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

    public void CheckLoadEnemies(GameObject go)
    {
        FollowPath followScript = go.GetComponent<FollowPath>();
        if (followScript != null)
        {
            if (followScript.Loop)
            {
                //Mobile
                StartCoroutine(SpawnMobileEnemy());
            } else
            {
                //UFO
                StartCoroutine(SpawnUFOEnemy());
            }
        }
    }

    private IEnumerator SpawnMobileEnemy()
    {
        yield return new WaitForSeconds(_secBeforeRespawnMobile);
        if (_mobileEnemies.Count != 0)
        {
            int index = Random.Range(0, _mobileEnemies.Count);

            Instantiate(_mobileEnemies[index]);
        }
    }

    private IEnumerator SpawnUFOEnemy()
    {
        yield return new WaitForSeconds(_secBeforeRespawnUFO);
        if (_ufoEnemies.Count != 0)
        {
            int index = Random.Range(0, _ufoEnemies.Count);

            Instantiate(_ufoEnemies[index]);
        }
    }

    public void LoadNewStaticEnemies()
    {
        if (_staticEnemies.Count == 0)
            return;
        int index = Random.Range(0, _staticEnemies.Count);

        Instantiate(_staticEnemies[index]) ;
    }
}
