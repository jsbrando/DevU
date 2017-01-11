using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengePhunWithStrings
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 1.  Reverse your name
            string name = "Jason Brandolini";
            // In my case, the result would be:
            // robaT boB
            char[] nameArray = name.ToCharArray();
            Array.Reverse(nameArray);
            string reverseName = new string(nameArray);

            // OR Bob's way...
            string nameResult = "";
            for (int i = name.Length -1 ; i >= 0 ; i--)
            {
                nameResult += name[i];
            }
            

            // 2.  Reverse this sequence:
            string names = "Luke,Leia,Han,Chewbacca";
            // When you're finished it should look like this:
            // Chewbacca,Han,Leia,Luke
            string firstName = names.Split(',')[0];
            string secondName = names.Split(',')[1].Split(',')[0];
            string thirdName = names.Split(',')[2].Split(',')[0];
            string fourthName = names.Split(',')[3].Split(',')[0];
            string result1 = fourthName + "," + thirdName + "," + secondName + "," + firstName;

            // OR Bob's way...
            string[] rebelScum = names.Split(',');
            string rebels = "";
            for (int i = rebelScum.Length - 1; i >= 0; i--)
            {
                rebels += rebelScum[i] + ",";
            }
            rebels = rebels.Remove(rebels.Length - 1, 1);

            //string secondName = names.Contains("i").ToString();
            //string thirdName = names.Contains("n").ToString();
            //string fourthName = names.Contains("Ch").ToString();
            //string result1 = firstName + "," + secondName + "," + thirdName + "," + fourthName;

            // 3. Use the sequence to create ascii art:
            // *****luke*****
            // *****leia*****
            // *****han******
            // **Chewbacca***
            string result = "";
            string result2 = "";
            string[] values = names.Split(',');
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i].Length < 4)
                    result += values[i].PadLeft(8,'*').PadRight(14, '*').ToLower() + "<br/>";
                else if (values[i].Length == 4)
                    result += values[i].PadLeft(9, '*').PadRight(14, '*').ToLower() + "<br/>";
                else
                    result += values[i].PadLeft(11, '*').PadRight(14, '*') + "<br/>";
            }

            // OR Bob's way...
            for (int i = 0; i < values.Length; i++)
            {
                int padLeft = (14 - values[i].Length) / 2;
                string temp = values[i].PadLeft(values[i].Length + padLeft, '*');
                result2 += temp.PadRight(14, '*');
                result2 += "<br/>";
            }


            // 4. Solve this puzzle:
            // Once you fix it with string helper methods, it should read:
            // Now is the time for all good men to come to the aid of their country.
            string puzzle = "NOW IS ZHEremove-me ZIME FOR ALL GOOD MEN ZO COME ZO ZHE AID OF ZHEIR COUNZRY.";
            string value = " ";
            string puzzleLower = puzzle.ToLower();
            // first remove the "remove-me"
            string puzzleLowerRemove = puzzleLower.Replace("remove-me", value);
            // second replace all Z with a T
            string puzzleLowerRemoveReplace = puzzleLowerRemove.Replace('z', 't');
            // third lowercase everything after first letter
            string answer = puzzleLowerRemoveReplace.Substring(0, 1).ToUpper() + puzzleLowerRemoveReplace.Substring(1);

            //OR Bob's way...
            string removeMe = "remove-me";
            int index = puzzle.IndexOf(removeMe);
            puzzle = puzzle.Remove(index, removeMe.Length);
            puzzle = puzzle.ToLower();
            puzzle = puzzle.Replace('z', 't');
            puzzle = puzzle.Remove(0, 1);
            puzzle = puzzle.Insert(0, "N");


            // display all results together
            resultLabel.Text = nameResult + "<br/><br/>Bob's way...<br/>" + reverseName + "<br/><br/>" +  
                result1 + "<br/><br/>Bob's way...<br/>" + rebels + "<br/><br/>" + 
                result + "<br/><br/>Bob's way...<br/>" + result2 + "<br/><br/>" + 
                answer + "<br/><br/>Bob's way...<br/>" + puzzle;

        }
    }
}