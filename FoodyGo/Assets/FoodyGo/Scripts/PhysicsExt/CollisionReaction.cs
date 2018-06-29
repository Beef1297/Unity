using UnityEngine;
using System.Collections;
using UnityEngine.Events;

namespace packt.FoodyGO.PhysicsExt
{
    public class CollisionReaction : MonoBehaviour
    {
        public string collisionObjectName;

        public CollisionEvent collisionEvent;        
        public Transform particlePrefab;
        public float destroyParticleDelaySeconds;
        public bool destroyObject;
        public float destroyObjectDelaySeconds;

        public void OnCollisionReaction(GameObject go, Collision collision)
        {
            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;

            if (particlePrefab != null)//particlePrefabがセットされていれば発動,インスタンスを生成
            {//方向と位置を決定し、パーティクルを生成するのが仕事みたいな感じ
                var particle = (Transform)Instantiate(particlePrefab, pos, rot);
                Destroy(particle.gameObject, destroyParticleDelaySeconds);
            }
            if (destroyObject)
            {
                Destroy(go, destroyObjectDelaySeconds);
            }

            collisionEvent.Invoke(gameObject, collision);//衝突イベントを処理するあらゆるリスナーにイベントの内容を渡す.
        }        
    }

    [System.Serializable]//衝突が起きたことを知らせる、コンポーネントをつなげる？？
    public class CollisionEvent : UnityEvent<GameObject, Collision>
    {

    }

}
