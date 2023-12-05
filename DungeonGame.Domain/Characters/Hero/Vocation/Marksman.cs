using DungeonGame.Domain.Constants;

namespace DungeonGame.Domain.Characters.Hero.Vocation
{
    public class Marksman : Hero
    {
        public override int HP { get; set; } = 120;
        public override int Damage { get; set; } = 8;
        public int CricitcalChance { get; set; } = 5 + Level*5;
        const int CritMultiplier = 5;
        public int StunChance { get; set; } = 5 + Level*5;
        public bool CritAttack { get; set; } = false;
        override public int Turn(Character charToAttack, bool winFlag)
        {
            CritAttack = false;
            if (!winFlag) return GameConstants.LostRound;
            Attack(charToAttack);
            checkIfAlive(charToAttack);
            if (!charToAttack.isAlive)

                GainXP(charToAttack.XP);
            return GameConstants.AttackSuccess;
        }
        public override void Attack(Character charToAttack)
        {
            var rand = new Random();
            int rollDice = rand.Next(99);
            if (rollDice <= StunChance) Stun(charToAttack);
            rollDice = rand.Next(99);
            if (rollDice <= CricitcalChance) CriticalAttack(charToAttack);
            else charToAttack.HP -= Damage;
        }

        public void CriticalAttack(Character charToAttack)
        {
            charToAttack.HP -= Damage * CritMultiplier;
            Console.WriteLine($"CRITICAL ATTACK HIT FOR {Damage * CritMultiplier} POINTS");
        }

        public void Stun(Character charToAttack)
        {
            charToAttack.IsStunned = true;
            Console.WriteLine("STUNNED ENEMY");
        }
    }
}
