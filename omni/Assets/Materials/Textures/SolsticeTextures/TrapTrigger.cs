namespace Runemark.DeadlyDungeonTraps
{
    using UnityEngine;
    using UnityEngine.Events;

#if UNITY_EDITOR
    using UnityEditor;
#endif

    [RequireComponent(typeof(BoxCollider))]
    public class TrapTrigger : MonoBehaviour
    {
        public enum Action { Activate, Deactivate, Toggle }
        public enum Interaction { None, KeyCode, UnityInput }

        public Trap trap;
        public Action action;
        [Min(0f)] public float cooldown;
        public string[] tagMask = new string[0];

        public Interaction interaction;
        public KeyCode key;
        public string input;

        public UnityEvent onTriggerEnter;
        public UnityEvent onTriggerExit;
        public UnityEvent onActivate;
        public UnityEvent onDeactivate;
 
        public float Temperature
        {
            get
            {
                return Mathf.Clamp01(nextSendTime);
            }
        }
        float nextSendTime;
        void OnEnable()
        {
            BoxCollider collider = GetComponent<BoxCollider>();
            collider.isTrigger = true;
        }

        void Update()
        {
            if (nextSendTime > 0) nextSendTime -= Time.deltaTime;
        }
        protected void DoAction()
        {
            if (nextSendTime > 0) return;

            switch (action)
            {
                case Action.Activate: 
                    if(trap != null) trap.Activate(); 
                    onActivate.Invoke(); 
                    break;

                case Action.Deactivate: 
                    if(trap != null) trap.Deactivate(); 
                    onDeactivate.Invoke(); 
                    break;

                case Action.Toggle: 
                    if(trap != null) 
                    {
                        trap.Toggle();

                        if(trap.isActive)
                            onActivate.Invoke();
                        else
                            onDeactivate.Invoke();
                    }                   
                    break;
            }
            nextSendTime = cooldown;
        }

        void OnTriggerEnter(Collider other)
        {
            var go = other.gameObject;
            if (CheckTag(go))
            {
                onTriggerEnter.Invoke();
                if (interaction == Interaction.None)
                    DoAction();
            }
        }
        void OnTriggerStay(Collider other)
        {
            var go = other.gameObject;
            if (!CheckTag(go)) return;

            bool keyPressed = interaction == Interaction.KeyCode && Input.GetKey(key);
            bool inputPressed = interaction == Interaction.UnityInput && Input.GetButton(input);

            if (keyPressed || inputPressed)
                DoAction();
        }
        void OnTriggerExit(Collider other)
        {
            var go = other.gameObject;
            if (CheckTag(go))
            {
                onTriggerExit.Invoke();
            }
        }

        bool CheckTag(GameObject otherGO)
        {
            if (otherGO == null) return false;

            foreach (var tag in tagMask)
            {
                if (otherGO.CompareTag(tag))
                    return true;
            }
            return false;
        }
    }



}