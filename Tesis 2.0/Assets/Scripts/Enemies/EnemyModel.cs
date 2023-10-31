using System;
using Extensions;
using PlayerScripts;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(HealthController))]
    public class EnemyModel : MonoBehaviour
    {
        [SerializeField] private EnemyData data;

        private int m_currHp;
        private EnemyView m_view;
        private Transform m_target;

        public IHealthController HealthController { get; private set; }
        public static event Action<EnemyModel> OnDie;
        
        private void Awake()
        {
            HealthController = GetComponent<HealthController>();
            HealthController.Initialize(data.MaxHp);
            m_view = GetComponent<EnemyView>();
            HealthController.OnDie += Die;
        }

        public Transform GetTargetTransform()
        {
            m_target ??= FindObjectOfType<PlayerModel>().transform;
            return m_target;
        }

        public EnemyData GetData() => data;

        public void SetLastTargetLocation(Vector3 p_pos)
        {
            
        }

        public void MoveTowards(Vector3 p_targetPoint)
        {
            //TODO: Agregar sistemas de obs avoidance
            p_targetPoint.Xyo();
            var dir = (p_targetPoint - transform.position).normalized;
            transform.position += dir * (data.MovementSpeed * Time.deltaTime);
            m_view.SetWalkSpeed((dir * data.MovementSpeed).magnitude);
        }

        private void Die()
        {
            OnDie?.Invoke(this);
            Destroy(gameObject);
        }

        private void OnCollisionEnter(Collision p_collision)
        {
            if (!p_collision.gameObject.layer.Equals(data.TargetMask)) 
                return;
            
            if(!p_collision.gameObject.TryGetComponent(out IHealthController l_healthController))
                return;
                
            l_healthController.TakeDamage(data.Damage);
            m_view.PlayHurtAnim();
        }
    }
}