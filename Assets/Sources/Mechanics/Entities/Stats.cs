using UnityEngine;

namespace Mechanics.Entities
{
    public class Stats : MonoBehaviour
    {

        public float HealthPoints;
        public float ProtectionPoints;
        public float ManaPoints;

        public float HPRegeneration;
        public float PPRegeneration;
        public float MPRegeneraation;

        public float Velocity;
        public bool Moveable;

        public float DamagePoints;
        public float AttackCouldown;
        public float AttackDuration;


        public void UpdateRegenerationPoints()
        {
            HPRegeneration = CalculateHealthRegenerationPoints(HealthPoints);
            MPRegeneraation = CalculateManaRegenerationPoints(ManaPoints);
            PPRegeneration = CalculateProtectionRegenerationPoints(ProtectionPoints);
        }

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
                damage = 0;
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
        /// Calculate how much mana points we'll have
        /// after regeneration
        /// </summary>
        /// <param name="manaPoints">Actual Mana Points</param>
        /// <param name="regen">Regeneration Points</param>
        /// <returns></returns>
        public static float CalculateMPOnRegeneration(float manaPoints, float regen)
        {
            return manaPoints + regen;
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
        /// count of the mana points
        /// </summary>
        /// <param name="manaPoints"></param>
        /// <returns></returns>
        public static float CalculateManaRegenerationPoints(float manaPoints)
        {
            return manaPoints / 10;
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
