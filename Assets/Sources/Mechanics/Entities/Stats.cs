using UnityEngine;
using UnityEngine.Events;

namespace Mechanics.Entities
{
    public class Stats : MonoBehaviour
    {
        #region Health
        private float maxHealthPoints;
        public float MaxHealthPoints;
        private float healthPoints;
        public float HealthPoints;
        public float HPRegeneration;
        #endregion


        #region Protection
        private float maxProtectionPoints;
        public float MaxProtectionPoints;
        private float protectionPoints;
        public float ProtectionPoints;
        public float PPRegeneration;
        #endregion


        public float Velocity;
        public bool Moveable;

        public float DamagePoints;
        public float AttackCouldown;
        public float AttackDuration;

        public UnityEvent<float, float> OnHealthUpdate;
        public UnityEvent<float, float> OnProtectionUpdate;


        private void Update()
        {
            if (MaxHealthPoints != maxHealthPoints)
            {
                OnHealthUpdate?.Invoke(maxHealthPoints, MaxHealthPoints);
                maxProtectionPoints = MaxProtectionPoints;
            }
            if (MaxProtectionPoints != maxProtectionPoints)
            {
                OnProtectionUpdate?.Invoke(maxProtectionPoints, MaxProtectionPoints);
                maxProtectionPoints = MaxProtectionPoints;
            }
        }


        #region Local

        public void UpdateRegenerationPoints()
        {
            HPRegeneration = CalculateHealthRegenerationPoints(HealthPoints);
            PPRegeneration = CalculateProtectionRegenerationPoints(ProtectionPoints);
        }

        public int GetHealthPersentage()
        {
            return Mathf.CeilToInt(MaxHealthPoints / HealthPoints * 100);
        }

        public int GetProtectionPersentage()
        {
            return Mathf.CeilToInt(MaxProtectionPoints / ProtectionPoints * 100);
        }
    
        #endregion

        #region Static Fields

        /// <summary>
        /// Calculate protection points keeping in mind that the entity is
        /// being attacked
        /// </summary>
        /// <param name="protection"></param>
        /// <returns></returns>
        public static float CalculateProtectionOnDamage(float protection)
        {
            return protection * .4f;
        }

        /// <summary>
        /// Calculate damage points accounting protection
        /// </summary>
        /// <param name="damage">Damage Points</param>
        /// <param name="protection">Protection Points</param>
        /// <returns></returns>
        public static float CalculateDamage(float damage, float protection)
        {
            damage = CalculateProtectionOnDamage(protection) - damage;
            if (damage < 0)
            {
                damage = 0;
            }

            return damage;
        }

        /// <summary>
        /// Calculate how much health points we'll have
        /// after regeneration
        /// </summary>
        /// <param name="healthPoints">Actual Health Points</param>
        /// <param name="regen">Regeneration Points</param>
        /// <returns></returns>
        public static float CalculateHPOnRegeneration(float healthPoints, float regen)
        {
            return healthPoints + regen;
        }

        /// <summary>
        /// Calculate how much protection points we'll have
        /// after regeneration
        /// </summary>
        /// <param name="protectionPoints">Actual Protection Points</param>
        /// <param name="regen">Regeneration Points</param>
        /// <returns></returns>
        public static float CalculatePPOnRegeneration(float protectionPoints, float regen)
        {
            return protectionPoints + regen;
        }

        /// <summary>
        /// Calculate regeneration points depending on
        /// count of the health points
        /// </summary>
        /// <param name="healthPoints"></param>
        /// <returns></returns>
        public static float CalculateHealthRegenerationPoints(float healthPoints)
        {
            return healthPoints / 10;
        }

        /// <summary>
        /// Calculate regeneration points depending on
        /// count of the protection points
        /// </summary>
        /// <param name="protectionPoints"></param>
        /// <returns></returns>
        public static float CalculateProtectionRegenerationPoints(float protectionPoints)
        {
            return protectionPoints / 10;
        }

        #endregion

    }
}
