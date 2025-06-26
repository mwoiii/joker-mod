using System.Collections;
using JokerMod.Modules;
using RoR2;
using RoR2.Projectile;
using UnityEngine;
using UnityEngine.Networking;

namespace JokerMod.Joker.Components.SkillHelpers {
    public class EmitProjectiles : MonoBehaviour {

        // used for agidyne
        // mostly copied from projectileexplosion

        protected ProjectileController projectileController;

        protected ProjectileDamage projectileDamage;

        protected HitBoxGroup hitBoxGroup;

        public GameObject childrenProjectilePrefab;

        public int childrenCount;

        public float timeBetweenEmits;

        public float childPositionProportionOfParentUpper = 0.5f;

        public float childPositionProportionOfParentLower = 0.5f;

        [Tooltip("What percentage of our damage does the children get?")]
        public float childrenDamageCoefficient;

        [Tooltip("Should children inherit the damage type of this projectile?")]
        public bool childrenInheritDamageType;

        public float minRollDegrees;

        public float rangeRollDegrees;

        public float minPitchDegrees;

        public float rangePitchDegrees;

        public float minYawDegrees;

        public float rangeYawDegrees;

        protected virtual void Awake() {
            projectileController = GetComponent<ProjectileController>();
            projectileDamage = GetComponent<ProjectileDamage>();
            hitBoxGroup = GetComponent<HitBoxGroup>();
            StartCoroutine(FireChildren());
        }

        protected Quaternion GetRandomChildRollPitch() {
            Quaternion quaternion = Quaternion.AngleAxis(minRollDegrees + UnityEngine.Random.Range(0f, rangeRollDegrees), Vector3.forward);
            Quaternion quaternion2 = Quaternion.AngleAxis(minPitchDegrees + UnityEngine.Random.Range(0f, rangePitchDegrees), Vector3.left);
            return Quaternion.AngleAxis(minYawDegrees + UnityEngine.Random.Range(0f, rangeYawDegrees), Vector3.up) * quaternion * quaternion2;
        }

        protected virtual Quaternion GetRandomDirectionForChild() {
            Quaternion randomChildRollPitch = GetRandomChildRollPitch();
            return randomChildRollPitch;
        }

        protected IEnumerator FireChildren() {
            while (true) {
                yield return new WaitForSeconds(timeBetweenEmits);
                // determine random position
                Transform hitBoxTransform = ((HitBox)Utils.RandomChoice(hitBoxGroup.hitBoxes)).transform;
                Vector3 childPosition = hitBoxTransform.position;
                float positionRange = childPositionProportionOfParentUpper - childPositionProportionOfParentLower;
                float yRange = hitBoxTransform.localScale.y / 2f;
                float zeroToOneProportion = childPositionProportionOfParentLower + ((float)Utils.rand.NextDouble()) * positionRange;
                float negOneToOneProportion = (2 * zeroToOneProportion) - 1;
                childPosition.y += yRange * negOneToOneProportion;

                Quaternion randomDirectionForChild = GetRandomDirectionForChild();
                GameObject obj = UnityEngine.Object.Instantiate(childrenProjectilePrefab, childPosition, randomDirectionForChild);
                ProjectileController component = obj.GetComponent<ProjectileController>();
                if ((bool)component) {
                    component.procChainMask = projectileController.procChainMask;
                    component.procCoefficient = projectileController.procCoefficient;
                    component.Networkowner = projectileController.owner;
                }
                obj.GetComponent<TeamFilter>().teamIndex = GetComponent<TeamFilter>().teamIndex;
                ProjectileDamage component2 = obj.GetComponent<ProjectileDamage>();
                if ((bool)component2) {
                    component2.damage = projectileDamage.damage * childrenDamageCoefficient;
                    component2.crit = projectileDamage.crit;
                    component2.force = projectileDamage.force;
                    component2.damageColorIndex = projectileDamage.damageColorIndex;
                    if (childrenInheritDamageType) {
                        component2.damageType = projectileDamage.damageType;
                    }
                }
                NetworkServer.Spawn(obj);
            }
        }
    }
}
