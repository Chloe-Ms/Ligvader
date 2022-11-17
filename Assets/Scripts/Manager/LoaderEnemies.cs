using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderEnemies : MonoBehaviour
{
    private static LoaderEnemies instance;
    [SerializeField] List<GameObject> _mobileEnemies;
    [SerializeField] float _secBeforeRespawnMobile = 10;
    [SerializeField] float _secBeforeFirstSpawnMobile = 1;
    [SerializeField] List<GameObject> _ufoEnemies;
    [SerializeField] float _secBeforeRespawnUFO = 40;
    [SerializeField] float _secBeforeFirstSpawnUFO = 2;
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

    public void Start()
    {
        StartCoroutine(SpawnMobileEnemy(_secBeforeFirstSpawnMobile));
        StartCoroutine(SpawnUFOEnemy(_secBeforeFirstSpawnUFO));
    }

    public void CheckLoadMobileEnemies(GameObject go)
    {
        FollowPath followScript = go.GetComponent<FollowPath>();
        if (followScript != null) //If the enemy move, it has the follow enemy script
        {
            if (followScript.Loop)
            {
                //Mobile
                StartCoroutine(SpawnMobileEnemy(_secBeforeRespawnMobile));
            } else
            {
                //UFO
                StartCoroutine(SpawnUFOEnemy(_secBeforeRespawnUFO));
            }
        }
    }

    private IEnumerator SpawnMobileEnemy(float secToWait)
    {
        //Debug.Log("Before spawn Mobile");
        yield return new WaitForSeconds(secToWait);
        //Debug.Log("After spawn Mobile");
        if (_mobileEnemies.Count != 0)
        {
            int index = Random.Range(0, _mobileEnemies.Count);

            Instantiate(_mobileEnemies[index]);
        }
    }

    private IEnumerator SpawnUFOEnemy(float secToWait)
    {
        //Debug.Log("Before spawn UFO");
        yield return new WaitForSeconds(secToWait);
        //Debug.Log("After spawn UFO");
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
