using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffe
{
    public class Drink
    {
        private string name, imgPath, imgStakPath, imgGifPath, countOfSugar, mode;
        private bool sugar;
        private string price;
        public Drink(string imgPath, string imgStakPath, string imgGifPath, string name, string price, bool sugar)
        {
            this.imgPath = imgPath;
            this.imgStakPath = imgStakPath;
            this.name = name;
            this.price = price;
            this.sugar = sugar;
            this.imgGifPath = imgGifPath;
        }
        public string Name { get => name; }
        public string Price { get => price; }
        public string ImgPath { get => imgPath; }
        public string ImgStakPath { get => imgStakPath; }
        public bool Sugar { get => sugar; }
        public string CountOfSugar { set { if (sugar) countOfSugar = value; else countOfSugar = "0"; } get { if (sugar) return countOfSugar; else return "0"; } }
        public int CountOfSugarInt { set { if (sugar) countOfSugar = value.ToString(); else countOfSugar = "0"; } get { if (sugar) return int.Parse(countOfSugar); else return 0; } }
        public string Mode { set { mode = value; } get => mode; }
        public string ImgGifPath { get => imgGifPath;}
    }
}
