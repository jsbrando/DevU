using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeHeroMonsterClassesPart1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Character theHero = new Character();
            theHero.Name = "Artemis";
            theHero.Health = 100;
            theHero.MaxDamage = 22;
            theHero.AttackBonus = false;

            Character theVillain = new Character();
            theVillain.Name = "Xanthor";
            theVillain.Health = 100;
            theVillain.MaxDamage = 31;
            theVillain.AttackBonus = true;

            int damage = theHero.Attack();
            theVillain.Defend(damage);

            damage = theVillain.Attack();
            theHero.Defend(damage);

            displayCharacter(theHero);
            displayCharacter(theVillain);
        }

        private void displayCharacter(Character character)
        {
            resultLabel.Text += String.Format("<p>Name: {0} - Health: {1} - Max Damage: {2} - Attack Bonus: {3}</p>"
                , character.Name, character.Health, character.MaxDamage, character.AttackBonus);
        }

    }

    class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxDamage { get; set; }
        public bool AttackBonus { get; set; }

        public int Attack()
        {
            Random random = new Random();
            int damage = random.Next(this.MaxDamage);
            return damage;
        }

        public void Defend(int damage)
        {
            this.Health -= damage;
        }
    }
}