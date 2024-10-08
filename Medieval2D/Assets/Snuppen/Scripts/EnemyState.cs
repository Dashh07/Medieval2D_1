using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class EnemyState : MonoBehaviour
{
    protected EnemyStateLogic enemyScript;
    void Awake(){
        enemyScript = GetComponent<EnemyStateLogic>();
        enemyScript.AddStateToList(this);
    }
    abstract public void EnemyStateEnter();
    abstract public void EnemyStateUpdate();
    abstract public void EnemyStateExit();
    
}

