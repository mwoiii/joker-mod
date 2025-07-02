namespace JokerMod.Joker.SkillStates {
    public class AOAStrong : AOA {

        // very temp as with base class
        public override float damageCoefficient => 1.4f;

        protected override void StartHitHandling() {
            attackHandler.StartExecution(true);
        }

    }
}
