using System;
using DG.Tweening;
using Modules.ObjectPooler.Scripts.Runtime.Enums;
using Modules.ObjectPooler.Scripts.Runtime.Key;
using Rich.Base.Runtime.Abstract.View;
using Runtime.Data.ValueObject;
using Runtime.Key;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Runtime.Views
{
    public class BulletView : RichView
    {
        #region Unity Actions

        public UnityAction<OnEnqueuePooledObjectParams> onEnqueueBullet = delegate { };

        #endregion

        #region Self Variables

        #region Public Variables

        public BulletVO Vo;

        #endregion

        #region Private Variables

        private Rigidbody _rigidbody;
        private Collider _collider;

        #endregion

        #endregion

        protected override void Awake()
        {
            base.Awake();
            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
        }

        protected override void OnEnable()
        {
            base.OnEnable();


            GiveForwardForce();

            if (!Vo.IsDestrcutable)
            {
                EnqueueBullet(PoolType.Bullet);
            }
        }

        private void EnqueueBullet(PoolType type)
        {
            DOVirtual.DelayedCall(Vo.TimeToEnqueue, () => onEnqueueBullet.Invoke(new OnEnqueuePooledObjectParams()
            {
                PooledObject = gameObject,
                PooledObjectType = type
            }));
        }

        private void GiveForwardForce()
        {
            var cameraForwardDirection = Camera.main.transform.forward;
            var directionToMove = Vector3.Scale(cameraForwardDirection, (Vector3.right + Vector3.forward));

            _rigidbody.AddForceAtPosition(
                directionToMove * Vo.BulletSpeed,
                new Vector3(Random.Range(Vo.minDeflection, Vo.maxDeflection),
                    Random.Range(Vo.minDeflection, Vo.maxDeflection), Random.Range(Vo.minDeflection, Vo.maxDeflection)),
                ForceMode.Impulse);
        }


        protected override void OnDisable()
        {
            base.OnDisable();

            ResetBullet();
        }


        private void ResetBullet()
        {
            transform.rotation = Quaternion.identity;
            transform.localEulerAngles = Vector3.zero;
            transform.localPosition = Vector3.zero;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.LogWarning("Triggered");
            EnqueueBullet(PoolType.PatlayanBullet);
        }
    }
}