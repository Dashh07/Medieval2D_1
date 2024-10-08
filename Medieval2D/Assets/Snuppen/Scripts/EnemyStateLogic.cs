using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStateLogic : MonoBehaviour
{
    [SerializeField] List<EnemyState> enemyStates = new();
    EnemyState currentEnemyState;
    
    void Start(){
        
        //AddStateToList(GetComponent<EnemyPatrolBehaviour>());
        ChangeState<EnemyPatrolBehaviour>();
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

    void ChangeState<aState>()
    {
        foreach(EnemyState e in enemyStates){
            if (e.GetType() == typeof(aState)){
                currentEnemyState?.EnemyStateExit();
                currentEnemyState = e;
                currentEnemyState.EnemyStateEnter();
                return;
            }
        }
        Debug.LogWarning("Tried changing to a state that doesn't exist!");
    }

    private void FixedUpdate(){
        currentEnemyState?.EnemyStateUpdate();
    }
}