using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStateLogic : MonoBehaviour
{
    [SerializeField] protected List<EnemyState> enemyStates = new();
    protected EnemyState currentEnemyState;
    
    void Start(){
        
        //AddStateToList(GetComponent<EnemyPatrolBehaviour>());
        //ChangeState<EnemyPatrolBehaviour>();
    }
    

    public void AddStateToList(EnemyState aState){
        foreach(EnemyState e in enemyStates){
            if (e.GetType() == aState.GetType()){
                Debug.Log("State already exists!");
                return;
            }
        }
        enemyStates.Add(aState);
    }

    public void ChangeState<aState>()
    {
        foreach(EnemyState e in enemyStates){
            if (e.GetType() == typeof(aState)){
                currentEnemyState?.EnemyStateExit();
                currentEnemyState = e;
                currentEnemyState.EnemyStateEnter();
                return;
            }
        }
        Debug.LogWarning("Behaviour script is missing from the enemy or the state doesn't exist!");
    }

    private void FixedUpdate(){
        Debug.Log(currentEnemyState);
        currentEnemyState?.EnemyStateUpdate();
    }
}

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
