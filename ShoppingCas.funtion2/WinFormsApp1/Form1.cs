using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Security.Policy;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.LinkLabel;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
        }
        public double Item(TextBox item1, TextBox itemamount1, TextBox item2, TextBox itemamount2, CheckBox item_check1, CheckBox item_check2)
        {


            string inCofprice = item1.Text;
            string inamount = itemamount1.Text;
            string inTeaprice = item2.Text;
            string inTeaAmount = itemamount2.Text;

            int Cofprice = 0;
            int amount = 0;
            int teaAmount = 0;
            int teaprice = 0;

            try
            {
                if (item_check1.Checked)
                    Cofprice = int.Parse(inCofprice);
                amount = int.Parse(inamount);

            }
            catch (FormatException) { }
            try
            {
                if (item_check2.Checked)
                    teaprice = int.Parse(inTeaprice);
                teaAmount = int.Parse(inTeaAmount);
            }
            catch (FormatException)
            {

            }
            double sum1 = Cofprice * amount;
            double sum2 = teaprice * teaAmount;
            double sum = sum1 + sum2;
            return sum;
        }
        public double DiscountAll(double Drink, double Food)
        {
            double sum1 = 0;
            if (Discount_All.Checked)
            {
                double discountvalue = 0;
                try
                {
                    discountvalue = int.Parse(Tb_DisAll.Text);
                    double all = Drink + Food;
                    all = all - (all * discountvalue / 100);
                    sum1 += all;

                }
                catch (FormatException)
                {
                    double all = Drink + Food;
                    sum1 += all;
                }


            }
            return sum1;
        }
        public double DiscountDrink(double Drink)
        {
            if (Discount_Drink.Checked)
            {
                double discountvalue = 0;
                try
                {
                    discountvalue = int.Parse(Tb_DisDrink.Text);
                    Drink = Drink - (Drink * discountvalue / 100);

                }
                catch (FormatException)
                { Drink = Drink - (Drink * discountvalue / 100); }

            }
            return Drink;
        }
        public double DiscountFood(double Food)
        {
            if (Discount_Food.Checked)
            {
                double discountvalue = 0;
                try
                {
                    discountvalue = int.Parse(Tb_DisFood.Text);
                    Food = Food - (Food * discountvalue / 100);

                }
                catch (FormatException)
                {
                    Food = Food - (Food * discountvalue / 100);

                }
            }

            return Food;
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (Cola_Check.Checked == false)
            {
                ColaPrice.Enabled = false;
                ColaAmount.Enabled = false;
            }
            if (Cola_Check.Checked == true)
            {
                ColaPrice.Enabled = true;
                ColaAmount.Enabled = true;
            }

        }

        private void CoffeePrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double Drink = Item(ColaPrice, ColaAmount, WaterPrice, WaterAmount, Cola_Check, water_Check);
            double Food = Item(Canfish_Price, Canfish_Amount, Noondle_price, Noondle_Amount, Canfish_Check, Noondle_Check);
            double sum1 = 0;
            if (Discount_All.Checked)
            {
                sum1 += DiscountAll(Drink, Food);

            }
            else if (Discount_Drink.Checked)
            {
                Drink = DiscountDrink(Drink);
                sum1 += Drink + Food;

            }

            else if (Discount_Food.Checked)
            {
                Food = DiscountFood(Food);
                sum1 += Food + Drink;



            }
            else
            {
                sum1 += Drink + Food;
            }
            Total.Text = sum1.ToString();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            double total = 0;
            double cash = 0;
            try
            {

                cash = double.Parse(Cash.Text);

            }
            catch (FormatException) { }

            try
            {
                total = double.Parse(Total.Text);
            }
            catch (FormatException) { }
            double change = cash - total;
            Changebox.Text = change.ToString();

            double OneT = 0;
            double FiveH = 0;
            double oneH = 0;
            double fifty = 0;
            double twenty = 0;
            double ten = 0;
            double five = 0;
            double one = 0;
            double fiftystang = 0;
            double twentyfivestang = 0;
            double tenstang = 0;
            double fivestang = 0;
            double onestang = 0;
            while (change >= 0.01)
            {
                if (change >= 1000)
                {
                    change -= 1000;
                    OneT++;
                }
                else if (change >= 500)
                {
                    change -= 500;
                    FiveH++;
                }
                else if (change >= 100)
                {
                    change -= 100;
                    oneH++;
                }
                else if (change >= 50)
                {
                    change -= 50;
                    fifty++;
                }
                else if (change >= 20)
                {
                    change -= 20;
                    twenty++;
                }
                else if (change >= 10)
                {
                    change -= 10;
                    ten++;
                }
                else if (change >= 5)
                {
                    change -= 5;
                    five++;
                }
                else if (change >= 1)
                {
                    change -= 1;
                    one++;
                }
                else if (change >= 0.50)
                {
                    change -= 0.50;
                    fiftystang++;
                }
                else if (change >= 0.25)
                {
                    change -= 0.25;
                    twentyfivestang++;
                }
                else if (change >= 0.10)
                {
                    change -= 0.10;
                    tenstang++;
                }
                else if (change >= 0.05)
                {
                    change -= 0.05;
                    fivestang++;

                }
                else if (change >= 0.01)
                {
                    change -= 0.01;
                    onestang++;
                }
            }
            OneThousand.Text = OneT.ToString();
            FiveHundred.Text = FiveH.ToString();
            OneHundred.Text = oneH.ToString();
            Fifty.Text = fifty.ToString();
            Twenty.Text = twenty.ToString();
            Ten.Text = ten.ToString();
            Five.Text = five.ToString();
            One.Text = one.ToString();
            FiftyStang.Text = fiftystang.ToString();
            TwentyFiveStang.Text = twentyfivestang.ToString();
            TenStang.Text = tenstang.ToString();
            FiveStang.Text = fivestang.ToString();
            OneStang.Text = onestang.ToString();


        }

        private void Tea_check_CheckedChanged(object sender, EventArgs e)
        {
            if (water_Check.Checked == true)
            {
                WaterPrice.Enabled = true;
                WaterAmount.Enabled = true;
            }
            if (water_Check.Checked == false)
            {
                WaterPrice.Enabled = false;
                WaterAmount.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (Discount_Drink.Checked)
            {
                Discount_All.Checked = false;
                Discount_Food.Checked = false;
                Tb_DisDrink.Enabled = true;
            }
            else
            {
                Tb_DisDrink.Enabled = false;
            }
        }

        private void Discount_Food_CheckedChanged(object sender, EventArgs e)
        {
            if (Discount_Food.Checked)
            {
                Discount_All.Checked = false;
                Discount_Drink.Checked = false;
                Tb_DisFood.Enabled = true;
            }
            else
            {
                Tb_DisFood.Enabled = false;
            }
        }

        private void Discount_All_CheckedChanged(object sender, EventArgs e)
        {
            if (Discount_All.Checked)
            {
                Discount_Drink.Checked = false;
                Discount_Food.Checked = false;
                Discount_All.Checked = true;
                Tb_DisAll.Enabled = true;
            }
            else
            {
                Tb_DisAll.Enabled = false;
            }

        }


        private void Pizza_Check_CheckedChanged(object sender, EventArgs e)
        {
            if (Canfish_Check.Checked)
            {
                Canfish_Price.Enabled = true;
                Canfish_Amount.Enabled = true;
            }
            else
            {
                Canfish_Price.Enabled = false;
                Canfish_Amount.Enabled = false;
            }

        }

        private void Burger_Check_CheckedChanged(object sender, EventArgs e)
        {
            if (Noondle_Check.Checked == true)
            {
                Noondle_price.Enabled = true;
                Noondle_Amount.Enabled = true;
            }
            else
            {
                Noondle_price.Enabled = false;
                Noondle_Amount.Enabled = false;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void One_TextChanged(object sender, EventArgs e)
        {

        }

        private void Fifty_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

