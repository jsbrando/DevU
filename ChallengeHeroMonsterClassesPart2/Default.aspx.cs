using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeHeroMonsterClassesPart2
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void battleButton_Click(object sender, EventArgs e)
        {
            // put in click instead
            resultLabel.Text = "";

            Character theHero = new Character();
            theHero.Name = "Artemis";
            theHero.Health = 100;
            theHero.MaxDamage = 22;
            theHero.AttackBonus = true;

            Character theVillain = new Character();
            theVillain.Name = "Xanthor";
            theVillain.Health = 100;
            theVillain.MaxDamage = 31;
            theVillain.AttackBonus = false;

            Dice rollDice = new Dice();
            
            if (theHero.AttackBonus == true)
            {
                theVillain.Defend(theHero.Attack(rollDice));
                //damage = theHero.Attack(rollDice);
                //theVillain.Defend(damage);
            }
            else if (theVillain.AttackBonus == true)
            {
                theHero.Defend(theVillain.Attack(rollDice));
                //damage = theVillain.Attack(rollDice);
                //theHero.Defend(damage);
            }
            else return;

            while (theHero.Health > 0 && theVillain.Health > 0)
            {
                theVillain.Defend(theHero.Attack(rollDice));
                theHero.Defend(theVillain.Attack(rollDice));
                //damage = theHero.Attack(rollDice);
                //theVillain.Defend(damage);

                //damage = theVillain.Attack(rollDice);
                //theHero.Defend(damage);

                displayCharacter(theHero);
                displayCharacter(theVillain);

                displayResult(theHero, theVillain);
            }
        }

        private void displayResult(Character opponent1, Character opponent2)
        {
            if (opponent1.Health <= 0 && opponent2.Health <= 0)
            {
                resultLabel.Text += String.Format("Both {0} and {1} died", opponent1.Name, opponent2.Name);
            }
            else if (opponent1.Health <= 0)
            {
                resultLabel.Text += String.Format("{0} died", opponent1.Name);
            }
            else if (opponent2.Health <= 0)
            {
                resultLabel.Text += String.Format("{0} died", opponent2.Name);
            }
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

        
        public int Attack(Dice dice)
        {
            //dice.Sides = this.MaxDamage;
            //return dice.Sides;
            dice.Sides = 25;
            int damage = dice.Roll();
            return damage;
        }


        public void Defend(int damage)
        {
            this.Health -= damage;
        }
    }

    class Dice
    {
        public int Sides { get; set; }
        
        Random random = new Random();
        public int Roll()
        {
            return random.Next(this.Sides);
            //int damage = random.Next(this.Sides);
            //return damage;
        }
    }
}