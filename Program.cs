using System;

namespace InterfaceGun
{
    interface IHaseInfo
    {
        void ShowInfo();
    }

    interface IWeapon
    {
        int Damage { get; }
        void Fire();
    }

    abstract class Weapon : IHaseInfo, IWeapon
    {
        public abstract int Damage { get; }

        public abstract void Fire();

        public void ShowInfo()
        {
            Console.WriteLine($"{GetType().Name} Damage: {Damage}");
        }
    }

    class Gun : Weapon
    {
        public override int Damage { get { return 5; } }

        public override void Fire()
        {
            Console.WriteLine("Pif!");
        }
    }

    class LaserGun : Weapon
    {
        public override int Damage { get { return 8; } }

        public override void Fire()
        {
            Console.WriteLine("Piu!");
        }
    }

    class Bow : Weapon
    {
        public override int Damage => 3;

        public override void Fire()
        {
            Console.WriteLine("Chpunk!");
        }
    }

    class Player
    {
        public void Fire(IWeapon weapon)
        {
            weapon.Fire();
        }

        public void CheckInfo(IHaseInfo haseInfo)
        {
            haseInfo.ShowInfo();
        }
    }

    class Box : IHaseInfo
    {
        public void ShowInfo()
        {
            Console.WriteLine("Special Gun");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();

            Weapon[] inventory = { new Gun(), new LaserGun(), new Bow() };

            foreach (var item in inventory)
            {
                player.CheckInfo(item);
                player.Fire(item);
                Console.WriteLine();

            }
            player.CheckInfo(new Box());
            Console.ReadLine();
        }
    }
}
