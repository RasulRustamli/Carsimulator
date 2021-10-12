using System;
using System.Collections.Generic;
using System.Text;

namespace Carsimulator
{
    class Car
    {
        double Lt { get; set; }//100 km yandirilan benzin
        double Litr { get; set; }//ustunde olan benzin
        double Money { get;} = 0.9;//benzinin 1 ltr qiymeti
        string Mode { get; set; }// masinin hal hazirdaki modu 
        double Waylt { get; set; }//Verilen yol ucun lazim olan benzinin litri
        int Capasity { get; set; }//Benzin limiti
        double Capasityway { get; set; }//bir depoya gede bileceyi yol
        double Km1{get; set; }
        double Lt1{ get; set; }

        public Car(double litr, double lt,int capasity)
        {
            Litr = litr;
            Lt = lt;
            Capasity = capasity;
            Lt1 = 100 / lt;//bir litre nece km gedir
            Km1 =lt / 100;//bir kmye nece litr yandirir
            Capasityway = Lt1 * capasity;

        }
        #region Modeselect
        public void ModeSpeed(string Modtype)
        {
            switch (Modtype)
            {
                case "ofroad":
                    Lt += 4;
                    break;
                case "eco":
                    Lt -= 2.1;
                    break;
                case "sport":
                    Lt += 2.5;
                    break;
                default: Console.WriteLine("Car has not this mode ");
                    break;
            }
        }
        #endregion
        #region Way
        public void Way(int km)
        {
            Waylt = km * Km1;
            if (Waylt <= Litr)
            {
                Console.WriteLine($"you have {Litr-Waylt}liters of gasoline left");
            }
            else if (Waylt <= Capasity)
            {
                Console.WriteLine($"You need{(Capasity-Waylt)-Litr}liters gasoline");
            }
            else
            {
                Console.WriteLine($"You can go {Capasityway}km far with a depot. " +
                $"You need {(Capasityway-km)*Km1}lt much extra gasoline to get to the address.");
            }
        }
#endregion
        #region Refuelling full
        public void Refueling()//full depo
        {
            if (Litr < Capasity)
            {
                double qalan = Capasity - Litr;
                double TotalMoney = qalan * Money;
                Console.WriteLine($"You have to pay{TotalMoney}AZN");    
            }
            else Console.WriteLine("Full depo");
        }
#endregion
        #region Refuelling
        public void Refueling(double litr)
        {
            if(litr<(Capasity-Litr)){
                Litr += litr;
                double Totalmoney = litr * Money;
                Console.WriteLine($"You have to pay{Totalmoney}");
            }
            else if(Capasity>(Capasity-Litr))
            {
                double qalan = Capasity - Litr;
                Console.WriteLine($"you can only fill {qalan} liters and {qalan*Money}AZN the price");
            }
            else Console.WriteLine("Full depo");
        }
        #endregion
        


    }
 }

