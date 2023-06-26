using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private CashCalc calc = new CashCalc();
        private BackgroundWorker worker = new BackgroundWorker();
        Drink info;
        bool isWorkerOver = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            TakeChangeBT.Enabled = false;
            Prepare.Enabled = false;
            BackBT.Enabled = false;
            trackBar1.Enabled = false;
            ForDrinksCup.Visible = false;
            ForDrinksCup.Enabled = false;
            weakBT.Enabled = false;
            middleBT.Enabled = false;
            strongBT.Enabled = false;
            ModeOfDrinkLB.BackgroundImageLayout = ImageLayout.Stretch;
            ForDrinksCup.BackgroundImageLayout = ImageLayout.Stretch;
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.ProgressChanged +=
                new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);

        }
        
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {            
            isWorkerOver = true;
            ForDrinksCup.Visible = true;
            pictureBox1.Visible = false;
            ForDrinksCup.BackgroundImage = Image.FromFile(info.ImgStakPath);
            if(calc.ChangeInt == 0) ForDrinksCup.Enabled = true;

        }
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int percentFinished = (int)e.Argument;
            while (!worker.CancellationPending && percentFinished != 100)
            {
                percentFinished++;
                worker.ReportProgress(percentFinished);
                System.Threading.Thread.Sleep(50);
            }
            e.Result = percentFinished;
        }
        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            TimeCoffe.Value = e.ProgressPercentage;
        }
        private void modeOfDrink_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            info.Mode = bt.Tag.ToString();
            ModeOfDrinkLB.BackgroundImage = bt.BackgroundImage;
        }
        private void TakeChangeBT_Click(object sender, EventArgs e)
        {
            calc.Check = true;
            GetChangeLB.Text = calc.Change;
            allCash.Text = calc.ALL_MONEY;
            calc.Money = "0";
            TakeChangeBT.Enabled = false;
            if (isWorkerOver) ForDrinksCup.Enabled = true;
        }

        private void Prepare_Click(object sender, EventArgs e)
        {
            EnableButtons(this, false);
            if(calc.ChangeInt > 0) TakeChangeBT.Enabled = true;
            pictureBox1.Visible = true;
            pictureBox1.Enabled = true;
            pictureBox1.Image = Image.FromFile(info.ImgGifPath);
            panel1.Enabled = true;
            calc.Check = false;
            CoffeTime();
        }

        private void ReturnMoneyBT_Click(object sender, EventArgs e)
        {
            calc.Check = true;
            calc.Money = "0";           
            GetChangeLB.Text = calc.Change;
            allCash.Text = calc.ALL_MONEY;
            Prepare.Enabled = false;
        }

        private void EnableButtons(Form frm, bool k)
        {
            foreach (Control c in Controls)
            {
                c.Enabled = k;               
            }
        }

        private void CoffeTime()
        {
            if (worker.IsBusy)
            {
                worker.CancelAsync();
            }
            else
            {
                if (TimeCoffe.Value == TimeCoffe.Maximum)
                {
                    TimeCoffe.Value = TimeCoffe.Minimum;
                }
                worker.RunWorkerAsync(TimeCoffe.Value);
            }
        }
        

        private void BackBT_Click(object sender, EventArgs e)
        {
            BackBackExit();
        }
        private void newApparat_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
        }


        #region Components
        private void component1_Load(object sender, EventArgs e)
        {
            Drink drink1 = new Drink(Environment.CurrentDirectory + "\\imgaes\\raf.jpg", Environment.CurrentDirectory + "\\imgaes\\1.jpg", Environment.CurrentDirectory + "\\imgaes\\1.gif", "Raf Coffe", "150", true);
            component1.CreateButton(drink1.Name, drink1.Price, drink1.ImgPath);
            component1.Tag = drink1;
        }
        private void component2_Load(object sender, EventArgs e)
        {
            Drink drink2 = new Drink(Environment.CurrentDirectory + "\\imgaes\\espresso.jpg", Environment.CurrentDirectory + "\\imgaes\\2.jpg", Environment.CurrentDirectory + "\\imgaes\\2.gif", "Espresso", "200", true);
            component2.CreateButton(drink2.Name, drink2.Price, drink2.ImgPath);
            component2.Tag = drink2;
        }

        private void component3_Load(object sender, EventArgs e)
        {
            Drink drink3 = new Drink(Environment.CurrentDirectory + "\\imgaes\\latte.png", Environment.CurrentDirectory + "\\imgaes\\3.jpg", Environment.CurrentDirectory + "\\imgaes\\3.gif", "Latte", "350", true);
            component3.CreateButton(drink3.Name, drink3.Price, drink3.ImgPath);
            component3.Tag = drink3;
        }

        private void component4_Load(object sender, EventArgs e)
        {
            Drink drink4 = new Drink(Environment.CurrentDirectory + "\\imgaes\\mocca.jpg", Environment.CurrentDirectory + "\\imgaes\\4.jpg", Environment.CurrentDirectory + "\\imgaes\\4.gif", "Mocca", "100", true);
            component4.CreateButton(drink4.Name, drink4.Price, drink4.ImgPath);
            component4.Tag = drink4;
        }

        private void component5_Load(object sender, EventArgs e)
        {
            Drink drink5 = new Drink(Environment.CurrentDirectory + "\\imgaes\\latte_machiatto.jpg", Environment.CurrentDirectory + "\\imgaes\\5.jpg", Environment.CurrentDirectory + "\\imgaes\\5.gif", "Latte machiato", "210", true);
            component5.CreateButton(drink5.Name, drink5.Price, drink5.ImgPath);
            component5.Tag = drink5;
        }

        private void component6_Load(object sender, EventArgs e)
        {
            Drink drink6 = new Drink(Environment.CurrentDirectory + "\\imgaes\\americano.jpg", Environment.CurrentDirectory + "\\imgaes\\6.jpg", Environment.CurrentDirectory + "\\imgaes\\6.gif", "Americano", "400", true);
            component6.CreateButton(drink6.Name, drink6.Price, drink6.ImgPath);
            component6.Tag = drink6;
        }

        private void component7_Load(object sender, EventArgs e)
        {
            Drink drink7 = new Drink(Environment.CurrentDirectory + "\\imgaes\\water.jpg", Environment.CurrentDirectory + "\\imgaes\\7.jpg", Environment.CurrentDirectory + "\\imgaes\\7.gif", "Water", "50", false);
            component7.CreateButton(drink7.Name, drink7.Price, drink7.ImgPath);
            component7.Tag = drink7;
        }

        private void component8_Load(object sender, EventArgs e)
        {
            Drink drink8 = new Drink(Environment.CurrentDirectory + "\\imgaes\\juice.jpg", Environment.CurrentDirectory + "\\imgaes\\8.jpg", Environment.CurrentDirectory + "\\imgaes\\8.gif", "Juice", "100", false);
            component8.CreateButton(drink8.Name, drink8.Price, drink8.ImgPath);
            component8.Tag = drink8;
        }

        private void component1_Click(object sender, EventArgs e)
        {
            info = (Drink)(sender as UserControl).Tag;
            trackBar1.Enabled = true;
            NameOfDrinkLB.Text = info.Name;
            CostLB.Text = info.Price;
            calc.Cost = info.Price;
            GetChangeLB.Text = calc.Change;
            BackBT.Enabled = true;
            ModeOfDrinkLB.BackgroundImage = null;
            if (!info.Sugar)
            {
                trackBar1.Enabled = false;
                info.CountOfSugarInt = 0;
                trackBar1.Value = info.CountOfSugarInt;
                SugarLB.Text = info.CountOfSugar;
                middleBT.Enabled = false;
                strongBT.Enabled = false;
                weakBT.Enabled = false;               
            }
            else
            {
                trackBar1.Enabled = true;
                ModeOfDrinkLB.BackgroundImage = Image.FromFile(Environment.CurrentDirectory+"\\imgaes\\fire1.png");
                middleBT.Enabled = true;
                strongBT.Enabled = true;
                weakBT.Enabled = true;
            }
            if (calc.CostInt <= calc.ALL_MONEY_INT && info.Name != "")
            {
                Prepare.Enabled = true;
            }
            else
            {
                Prepare.Enabled = false;
            }
        }
        #endregion
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            info.CountOfSugar = trackBar1.Value.ToString();
            SugarLB.Text = info.CountOfSugar;
        }

        private void moneyDealer_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            calc.Check = false;
            calc.Money = btn.Tag.ToString();
            allCash.Text = calc.ALL_MONEY;
            GetChangeLB.Text = calc.Change;
            if (calc.CostInt <= calc.ALL_MONEY_INT && NameOfDrinkLB.Text != "")
            {
                Prepare.Enabled = true;
            }
        }
        private void BackBackExit()
        {
            info = new Drink("", "", "", "","0", false);
            NameOfDrinkLB.Text = info.Name;
            CostLB.Text = info.Price;
            GetChangeLB.Text = info.Price;
            ModeOfDrinkLB.Text = info.Mode;
            ModeOfDrinkLB.BackgroundImage = null;
            SugarLB.Text = info.CountOfSugar;
            Prepare.Enabled = false;
            calc.Cost = info.Price;
            trackBar1.Enabled = false;
            weakBT.Enabled = false;
            middleBT.Enabled = false;
            strongBT.Enabled = false;

        }
        private void ForDrinksCup_Click_2(object sender, EventArgs e)
        {
            EnableButtons(this, true);
            BackBackExit();
            TimeCoffe.Value = 0;
            calc.Check = true;
            TakeChangeBT.Enabled = false;
            BackBT.Enabled = false;
            allCash.Text = calc.ALL_MONEY;
            ForDrinksCup.BackgroundImage = null;
            ForDrinksCup.Visible = false;
            ForDrinksCup.Enabled = false;
            isWorkerOver = false;
            trackBar1.Value = 0;
        }
    }
}

