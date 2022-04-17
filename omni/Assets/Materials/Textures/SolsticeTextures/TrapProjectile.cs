namespace Runemark.DeadlyDungeonTraps
{
    using UnityEngine;

#if UNITY_EDITOR
    using UnityEditor;
    using UnityEditorInternal;
#endif

    
    public class TrapProjectile : DamageSource
    {
        public bool sticky;
        public float force;
        public float distanceLeft;
        StarterAssets.ThirdPersonController player;
        public float MaxDownTime = 3f;
        public float CurrentDownTime;
        public bool tagged;

        private void OnEnable()
        {
            mode = Mode.Contact;
            duration = Duration.Once;
            ResetCollisionLog();
        }

        void Update()
        {
            float deltaDistance = force * Time.deltaTime;
            transform.position += transform.forward * deltaDistance;
            distanceLeft -= deltaDistance;

            if (distanceLeft <= 0) gameObject.SetActive(false);
        }

        void OnCollisionEnter (Collision other)
        {
            if (other.collider.tag == "Player")
            {
                 player = other.gameObject.GetComponent<StarterAssets.ThirdPersonController>();
                 WaitSpace(player);
                 tagged = true;
                 
            }
        }
        void WaitSpace (StarterAssets.ThirdPersonController log)
        {
            CurrentDownTime = MaxDownTime;

            if (tagged)
            {
                if (CurrentDownTime > 0)
            {
                CurrentDownTime -= Time.deltaTime;
                log.MoveSpeed -= 2;
                log.SprintSpeed -=2;
                Debug.Log("slowing speed");
                
            }
            else if (CurrentDownTime < 0)
            {
                log.MoveSpeed += 2;
                log.SprintSpeed += 2;
                Debug.Log("return speed");
                tagged = false;
            }
            }
        }
    }

}
