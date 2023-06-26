using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe
{
    class CashCalc
    {
        int cost, money, allMoney;
        private bool check = false;
        List<int> lst = new List<int>();
        public CashCalc()
        {

        }

        public string Cost { set { cost = int.Parse(value);} get => cost.ToString(); }
        public int CostInt { set { cost = value; } get => cost; }

        public string Money { set { money = int.Parse(value); lst.Add(money);} get => money.ToString(); }

        public string Change { get
        {
            if (allMoney < cost) return "0";
            else
            {
                allMoney = Calculate();
                return Math.Abs(cost - allMoney).ToString();
            }
        }}
        public int ChangeInt
        {
            get
            {
                if (allMoney < cost) return 0;
                else
                {
                    allMoney = Calculate();
                    return Math.Abs(cost - allMoney);
                }
            }
        }

        public string ALL_MONEY { get => (allMoney = Calculate()).ToString(); }
        public int ALL_MONEY_INT { get => allMoney=Calculate();}

        public bool Check
        {
            set
            {
                check = value;
                allMoney = Calculate();
            }
        }
        private int Calculate()
        {
            int sum = 0;
            if (!check)
            {
                foreach (int i in lst)
                {
                    sum += i;
                }

                return sum;
            }
            else
            {
                lst.Clear();
                return 0;
            }
        }
    }
}
