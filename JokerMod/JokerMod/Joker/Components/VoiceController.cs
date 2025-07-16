using System.Collections.Generic;
using System.Linq;
using JokerMod.Modules;
using RoR2;
using RoR2.Audio;
using UnityEngine;

namespace JokerMod.Joker.Components {

    public class VoiceController : MonoBehaviour {

        private JokerMaster master;

        private Dictionary<NetworkSoundEventDef[], float> soundArrayStopwatches;

        private Dictionary<NetworkSoundEventDef[], float> soundArrayMinWait;

        private Dictionary<NetworkSoundEventDef[], float> soundArrayMaxWait;

        private Dictionary<NetworkSoundEventDef[], int> soundArrayPrevIndex;

        private Dictionary<NetworkSoundEventDef[], NetworkSoundEventDef[]> sharingArrays;

        private void Awake() {
            soundArrayStopwatches = new Dictionary<NetworkSoundEventDef[], float>();
            soundArrayMinWait = new Dictionary<NetworkSoundEventDef[], float>();
            soundArrayMaxWait = new Dictionary<NetworkSoundEventDef[], float>();
            soundArrayPrevIndex = new Dictionary<NetworkSoundEventDef[], int>();
            sharingArrays = new Dictionary<NetworkSoundEventDef[], NetworkSoundEventDef[]>();
        }

        public void RegisterSharedStopwatch(NetworkSoundEventDef[] newArray, NetworkSoundEventDef[] registeredArray) {
            if (sharingArrays.ContainsKey(registeredArray) || soundArrayStopwatches.ContainsKey(newArray)) {
                Log.Error("newArray already has a stopwatch or registeredArray is not a stopwatch owner! Couldn't share a stopwatch.");
            } else if (soundArrayStopwatches.ContainsKey(registeredArray)) {
                sharingArrays[newArray] = registeredArray;
            } else {
                Log.Error("registeredArray has not already been registered! Couldn't share a stopwatch.");
            }
        }

        public void RegisterArray(NetworkSoundEventDef[] array, float minWait, float maxWait) {
            soundArrayStopwatches[array] = 0f;
            soundArrayMinWait[array] = minWait;
            soundArrayMaxWait[array] = maxWait;
        }

        public void UnpausedUpdate() {
            float time = Time.deltaTime;
            foreach (NetworkSoundEventDef[] key in soundArrayStopwatches.Keys.ToArray()) {
                soundArrayStopwatches[key] += time;
            }
        }

        private bool RollForSoundEvent(NetworkSoundEventDef[] soundArray, bool maxFiftyFifty) {
            float time = 0f;
            if (sharingArrays.ContainsKey(soundArray)) {
                soundArray = sharingArrays[soundArray];
                time = soundArrayStopwatches[soundArray];
            } else if (soundArrayStopwatches.ContainsKey(soundArray)) {
                time = soundArrayStopwatches[soundArray];
            } else {
                Log.Error("soundArray has not been registered! Couldn't roll.");
                return false;
            }

            float chance = (float)Utils.rand.NextDouble() * soundArrayMaxWait[soundArray];

            if (maxFiftyFifty && time > soundArrayMaxWait[soundArray] * 0.5f) {
                time = soundArrayMaxWait[soundArray] * 0.5f;
            }

            if (time > soundArrayMinWait[soundArray] && time > chance) {
                soundArrayStopwatches[soundArray] = 0f;
                return true;
            }

            return false;
        }
        public void TryPlayRandomUniqueNetworkedSound(NetworkSoundEventDef[] soundArray, GameObject source, bool maxFiftyFifty = false) {
            if (RollForSoundEvent(soundArray, maxFiftyFifty)) {
                int idRoll;
                if (soundArrayPrevIndex.ContainsKey(soundArray)) {
                    idRoll = Utils.rand.Next(soundArray.Length - 1);
                    Log.Info($"Prev ID was {soundArrayPrevIndex[soundArray]}, rolled {idRoll}");
                    if (idRoll >= soundArrayPrevIndex[soundArray]) {
                        idRoll++;
                        idRoll %= soundArray.Length;
                    }
                } else {
                    idRoll = Utils.rand.Next(soundArray.Length);
                    soundArrayPrevIndex.Add(soundArray, idRoll);
                }
                soundArrayPrevIndex[soundArray] = idRoll;
                Log.Info($"fina roll is {idRoll}");
                EntitySoundManager.EmitSoundServer(soundArray[idRoll].akId, source);
            }
        }

        public void TryPlayRandomNetworkedSound(NetworkSoundEventDef[] soundArray, GameObject source, bool maxFiftyFifty = false) {
            if (RollForSoundEvent(soundArray, maxFiftyFifty)) {
                PlayRandomNetworkedSound(soundArray, source);
            }
        }

        public void TryPlayRandomNetworkedSound(NetworkSoundEventDef[] soundArray, Vector3 position, bool maxFiftyFifty = false) {
            if (RollForSoundEvent(soundArray, maxFiftyFifty)) {
                PlayRandomNetworkedSound(soundArray, position);
            }
        }

        public void TryPlayRandomSound(NetworkSoundEventDef[] soundArray, GameObject source, bool maxFiftyFifty = false) {
            if (RollForSoundEvent(soundArray, maxFiftyFifty)) {
                PlayRandomSound(soundArray, source);
            }
        }

        public void TryPlayRandomSound(NetworkSoundEventDef[] soundArray, Vector3 position, bool maxFiftyFifty = false) {
            if (RollForSoundEvent(soundArray, maxFiftyFifty)) {
                PlayRandomSound(soundArray, position);
            }
        }

        public static void PlayRandomNetworkedSound(NetworkSoundEventDef[] soundArray, GameObject source) {
            EntitySoundManager.EmitSoundServer(((NetworkSoundEventDef)Utils.RandomChoice(soundArray)).akId, source);
        }

        public static void PlayRandomNetworkedSound(NetworkSoundEventDef[] soundArray, Vector3 position) {
            EffectManager.SimpleSoundEffect(((NetworkSoundEventDef)Utils.RandomChoice(soundArray)).index, position, true);
        }

        public static void PlayRandomSound(NetworkSoundEventDef[] soundArray, GameObject source) {
            EntitySoundManager.EmitSoundLocal(((NetworkSoundEventDef)Utils.RandomChoice(soundArray)).akId, source);
        }

        public static void PlayRandomSound(NetworkSoundEventDef[] soundArray, Vector3 position) {
            EffectManager.SimpleSoundEffect(((NetworkSoundEventDef)Utils.RandomChoice(soundArray)).index, position, false);
        }
    }
}
