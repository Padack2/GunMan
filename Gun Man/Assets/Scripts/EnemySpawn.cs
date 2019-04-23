using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject enemyprefab;
    private int maxMonster = 10;
    public Transform enemyspawn;
    private float createTime=3f;
    private bool startgame = true;//failed= 패배, 게임끝 
    // Start is called before the first frame update
    void Start()
    {


        StartCoroutine(CreateMonster());


    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CreateMonster()
    {

        //현재 생성된 몬스터 개수 산출


        //몬스터의 생성 주기 시간만큼 대기
        yield return new WaitForSeconds(createTime);

        //몬스터의 동적 생성
        Instantiate(enemyprefab, enemyspawn.position, enemyspawn.rotation);
            


    }

}
