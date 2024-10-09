using UnityEngine;
using NaughtyAttributes;
using System.Collections.Generic;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _target;
    [SerializeField] private EnumRest _typeRest;
    [SerializeField] private EnumReaction _typeReacton;

    private IStateRest _stateRest;
    private IStateReaction _stateReaction;

    [SerializeField, ShowIf(nameof(_typeRest), EnumRest.Patrol), Label("Points Patrol")] 
    private List<Transform> _pointsPatrol = new List<Transform>();

    private void Start()
    {
        Initstalize();
    }

    [Button("Spawn")]
    private void Initstalize()
    {
        Enemy enemy = Instantiate(_enemy, this.transform.position, Quaternion.identity);
        SetRest(enemy);
        SetReaction(enemy);

        if (CanSpawn() == true)
        {
            enemy.Initialize(_stateRest, _stateReaction, _target);
        }
        else
        {
            Destroy(enemy);
            Debug.Log("Вы не можете заспавнить!");
        }
    }

    #region Rest
    private void SetRest(Enemy enemy)
    {
        switch (_typeRest)
        {
            case EnumRest.Idle:
                _stateRest = SetRestIdle();
                break;

            case EnumRest.Patrol:
                _stateRest = SetRestPatrol(enemy);
                break;

            case EnumRest.Random:
                _stateRest = SetRestRandom(enemy);
                break;

            default:
                Debug.Log("Вы не указали тип покоя!");
                return;
        }
    }

    private IStateRest SetRestIdle() => new StateRestIdle();

    private IStateRest SetRestRandom(Enemy enemy) => new StateRestRandom(enemy.transform);

    private IStateRest SetRestPatrol(Enemy enemy)
    {
        if (_pointsPatrol.Count <= 0)
        {
            Debug.Log("Нет точек для патрулирования");
            return null;
        }

        List<Vector3> points = new List<Vector3>();
        foreach (Transform transform in _pointsPatrol)
            points.Add(transform.position);

        return new StateRestPatrol(points, enemy.transform);
    }

    #endregion

    #region Reaction
    private void SetReaction(Enemy enemy)
    {
        switch (_typeReacton)
        {
            case EnumReaction.Escape:
                _stateReaction = SetReactionEscape(enemy);
                break;

            case EnumReaction.Die:
                _stateReaction = SetReactionDie(enemy);
                break;

            case EnumReaction.Chase:
                _stateReaction = SetReactionChase(enemy);
                break;

            default:
                Debug.Log("Вы не указали тип реакции!");
                return;
        }
    }

    private IStateReaction SetReactionEscape(Enemy enemy) => new StateReactionEscape(_target, enemy.transform);

    private IStateReaction SetReactionChase(Enemy enemy) => new StateReactionChase(_target, enemy.transform);

    private IStateReaction SetReactionDie(Enemy enemy) => new StateReactionDie(_target, enemy.transform);

    #endregion

    private bool CanSpawn() => _stateReaction != null || _stateRest != null;
}
