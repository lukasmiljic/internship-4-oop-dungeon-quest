using DungeonGame.Domain.Enums;

namespace DungeonGame.Domain.UI
{
    public static class Helper
    {
        public static HeroVocation? ValidateVocation(string vocation)
        {
            if (vocation != HeroVocation.Enchanter.ToString() || vocation != HeroVocation.Marksman.ToString() || vocation != HeroVocation.Gladiator.ToString())
                return null;
            switch (vocation) 
            {
                case "G":
                    return HeroVocation.Gladiator;
                case "M":
                    return HeroVocation.Gladiator;
                case "E":
                    return HeroVocation.Gladiator;
            }
            return null;
        }
        public static bool AreYouSure()
        {
            do
            {
                char userChoice;
                Console.Write("[y/n]: ");
                char.TryParse(Console.ReadLine(), out userChoice);
                if (userChoice == 'y')
                {
                    return true;
                }
                else if (userChoice == 'n')
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            } while (true);
        }
    }
}
