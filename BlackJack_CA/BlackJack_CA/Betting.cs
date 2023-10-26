using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_CA
{
    internal class Betting
    {
        public enum Result { BlackJack, Win, Draw, Loss } //Enum for each scenario in BlackJack
        public double BetValue 
        { 
            get;
            set; 
        }
        public double ChipsLeft
        {
            get;
            set;
        }
        public Betting (int betValue)
        {
            BetValue = betValue;
        }
        //Way of getting the remaing chips after inputting the BetValue.
        public double BetCalc() //Calculate 
        {
            if (BetValue >= ChipsLeft) //To avoid going into negative chips
            {
                BetValue = ChipsLeft;
                ChipsLeft = 0;
            }
            else if (BetValue < ChipsLeft)
            {
                ChipsLeft = ChipsLeft - BetValue;
            }
            return ChipsLeft;
        }
        public void BetWinning(Result match)
        {
            if (match == Result.BlackJack) //Scenario when player gets BlackJack
            {
                BetValue = BetValue * 2.5;
                ChipsLeft = ChipsLeft + BetValue;
            }
            else if (match == Result.Win) //Scenario when player wins
            {
                BetValue = BetValue * 2;
                ChipsLeft = ChipsLeft + BetValue;
            }
            else if (match == Result.Draw) //Scenario when player draws
            {
                ChipsLeft += BetValue;
            }
            else if (match == Result.Loss) //Scenario when player loses or busts
            {
                ChipsLeft -= BetValue;
            }
        }

    }
}
