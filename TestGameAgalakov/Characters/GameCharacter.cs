using System;
using System.Collections.Generic;
using TestGameAgalakov.Actions;
using TestGameAgalakov.Skills;

namespace TestGameAgalakov.Characters
{
    /// <summary>
    /// Game Character base class for fight character
    /// </summary>
    public abstract class GameCharacter : IFight
    {
        private readonly IEnumerable<ISkill> _skills;
        public string Name { get; }
        protected int Health { get; set; }
        protected int HitLevel { get; set; }
        public int Kills { get; set; }

        /// <summary>
        /// Constructor with paramters
        /// </summary>
        /// <param name="name">Character Name</param>
        /// <param name="health">start health level</param>
        /// <param name="hitLevel">how huge hit could be</param>
        /// <param name="skills">extra skills that would be used after fight</param>
        protected GameCharacter(string name, int health, int hitLevel = 3, IEnumerable<ISkill> skills = null)
        {
            Name = name;
            _skills = skills;
            Health = health;
            HitLevel = hitLevel;
        }

        /// <summary>
        /// Fight method try to hit other Game Character
        /// </summary>
        /// <param name="target">to whom make a hit</param>
        public virtual void Fight(GameCharacter target)
        {
            if (target == null)
            {
                return;
            }
            target.TakeDamage(this.HitLevel);

            if (!target.IsAlive)
            {
                Kills++;
            }

            UseSkills();
        }

        /// <summary>
        /// Is Character has Health
        /// </summary>
        public bool IsAlive => Health > 0;

        public void TakeDamage(int damage)
        {
            if (Health > 0)
            {
                Health -= damage;
            }

            Console.WriteLine($"{this} takes " + damage + " damage. Health: " + Health);
        }

        public void IncreaseHitLevel()
        {
            HitLevel++;
        }

        public void AddHealth(int level)
        {
            if (Health > 0)
            {
                Health += level;
            }
        }

        /// <summary>
        /// method how characters feels him-self 
        /// </summary>
        public virtual void SayAboutMyLife()
        {
            switch (Health)
            {
                case <= 0:
                    Console.WriteLine($"{this} life is over.");
                    break;
                case <= 25:
                    Console.WriteLine($"{this} life is low.");
                    break;
                case <= 50:
                    Console.WriteLine($"{this} life is in good shape.");
                    break;
                default:
                    Console.WriteLine($"{this} life is full of energy.");
                    break;
            }
        }

        /// <summary>
        /// use extra skills 
        /// </summary>
        protected void UseSkills()
        {
            if (_skills == null)
            {
                return;
            }
            Console.WriteLine($"{this} using skills:");
            foreach (var skill in _skills)
            {

                skill.Use(this);
            }
        }

        public override string ToString()
        {
            return $"{Name} ({this.GetType().Name})";
        }
    }
}
