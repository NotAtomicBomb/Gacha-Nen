using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public enum DamageType {
        Conjuration,
        Manipulation,
        Emission,
        Transmutation,
        Enhancement,
        Specialization
    }

    public abstract class BaseCharacter : MonoBehaviour
    {
        const float maxHealth = 100f;

        [SerializeField]
        public string Name;
        
        [SerializeField]
        internal float health = maxHealth;

        public virtual void Damage(float damageAmount, DamageType damageType)
        {
            if (damageAmount > health)
            {
                Die();
            }
            else
            {
                health -= damageAmount;
            }
        }

        public virtual void Heal(float healAmount)
        {
            if ((healAmount + health) > maxHealth)
            {
                health = maxHealth;
            }
            else
            {
                health += healAmount;
            }
        }

        private void Die()
        {
            print($"{this} has died.");
        }

        public override string ToString()
        {
            return Name;
        }
    }

}

