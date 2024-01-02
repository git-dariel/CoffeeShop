using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace Coffee_Shop
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            ApplyRoundedCorners(panel2, 10);
            ApplyRoundedCorners(panel4, 10);
            ApplyRoundedCorners(panel6, 10);
            ApplyRoundedCorners(panel8, 10);
        }

        private void ApplyRoundedCorners(Control control, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            Rectangle bounds = control.ClientRectangle;

            path.AddArc(bounds.Left, bounds.Top, radius * 2, radius * 2, 180, 90);
            path.AddArc(bounds.Right - radius * 2, bounds.Top, radius * 2, radius * 2, 270, 90);
            path.AddArc(bounds.Right - radius * 2, bounds.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(bounds.Left, bounds.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseFigure();

            control.Region = new Region(path);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCappucino.Checked == true)
            {
                txtQtyCappucino.Enabled = true;
            }
            else
            {
                txtQtyCappucino.Enabled = false;
                txtQtyCappucino.Text = "0";
            }
        }

        private void cbExpresso_CheckedChanged(object sender, EventArgs e)
        {
            if (cbExpresso.Checked == true)
            {
                txtQtyExpresso.Enabled = true;
            }
            else
            {
                txtQtyExpresso.Enabled = false;
                txtQtyExpresso.Text = "0";
            }
        }

        private void cbLatte_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLatte.Checked == true)
            {
                txtQtyLatte.Enabled = true;
            }
            else
            {
                txtQtyLatte.Enabled = false;
                txtQtyLatte.Text = "0";
            }
        }

        private void cbAmericano_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAmericano.Checked == true)
            {
                txtQtyAmericano.Enabled = true;
            }
            else
            {
                txtQtyAmericano.Enabled = false;
                txtQtyAmericano.Text = "0";
            }
        }

        double cappucino = 0.00;
        double expresso = 0.00;
        double latte = 0.00;
        double americano = 0.00;
        double qty1, qty2, qty3, qty4 = 0.00;


        double subtotal, subtotal2, subtotal3, subtotal4, tax, total, totalAmount = 0.00;

     
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to sign out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                Login loginscreen = new Login();
                loginscreen.Show();
                this.Hide();

            }
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            if (txtQtyCappucino.Enabled == true)
            {
                cappucino = 4.20;
                qty1 = double.Parse(txtQtyCappucino.Text);
                subtotal = qty1 * cappucino;
            }
            else
            {
                cappucino = 0;
                qty1 = 0;
                subtotal = 0;
            }
            if (txtQtyExpresso.Enabled == true)
            {
                expresso = 3.00;
                qty2 = double.Parse(txtQtyExpresso.Text);
                subtotal2 = qty2 * expresso;
            }
            else
            {
                expresso = 0;
                qty2 = 0;
                subtotal2 = 0;
            }
            if (txtQtyLatte.Enabled == true)
            {
                latte = 3.50;
                qty3 = double.Parse(txtQtyLatte.Text);
                subtotal3 = qty3 * latte;
            }
            else
            {
                latte = 0;
                qty3 = 0;
                subtotal3 = 0;
            }
            if (txtQtyAmericano.Enabled == true)
            {
                americano = 5.00;
                qty4 = double.Parse(txtQtyAmericano.Text);
                subtotal4 = qty4 * americano;
            }
            else
            {
                americano = 0;
                qty4 = 0;
                subtotal4 = 0;
            }

            if (txtQtyCappucino.Enabled == false && txtQtyExpresso.Enabled == false && txtQtyLatte.Enabled == false && txtQtyAmericano.Enabled == false)
            {
                MessageBox.Show("Please choose an order");
            }
            else
            {
                total = subtotal + subtotal2 + subtotal3 + subtotal4;
                tax = total * .08;
                totalAmount = tax + total;
                txtSubtotal.Text = total.ToString();
                txtTax.Text = tax.ToString();
                txtTotalAmount.Text = totalAmount.ToString();

                btnPayment.Enabled = true;
                btnPrint.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtQtyCappucino.Enabled = false;
            txtQtyCappucino.Text = "0";
            txtQtyExpresso.Enabled = false;
            txtQtyExpresso.Text = "0";
            txtQtyLatte.Enabled = false;
            txtQtyLatte.Text = "0";
            txtQtyAmericano.Enabled = false;
            txtQtyAmericano.Text = "0";

            cbCappucino.Checked = false;
            cbExpresso.Checked = false;
            cbLatte.Checked = false;
            cbAmericano.Checked = false;

            txtSubtotal.Text = "0";
            txtTax.Text = "0";
            txtTotalAmount.Text = "0";

            txtPayment.Clear();
            txtChange.Text = "0";

            btnPayment.Enabled = false;
            btnPrint.Enabled = false;
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            txtQtyCappucino.Enabled = false;
            txtQtyCappucino.Text = "0";
            txtQtyExpresso.Enabled = false;
            txtQtyExpresso.Text = "0";
            txtQtyLatte.Enabled = false;
            txtQtyLatte.Text = "0";
            txtQtyAmericano.Enabled = false;
            txtQtyAmericano.Text = "0";

            cbCappucino.Checked = false;
            cbExpresso.Checked = false;
            cbLatte.Checked = false;
            cbAmericano.Checked = false;

            txtSubtotal.Text = "0";
            txtTax.Text = "0";
            txtTotalAmount.Text = "0";

            txtPayment.Clear();
            txtChange.Text = "0";

            btnPayment.Enabled = false;
            btnPrint.Enabled = false;

            richTextBox1.Clear();
        }

        double orderTotal = 0.00;
        double payment = 0.00;
        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPayment.Text))
            {
                MessageBox.Show("Please enter the payment amount!");
                txtChange.Text = string.Empty;
            }
            else
            {
                payment = double.Parse(txtPayment.Text);

                if (payment >= totalAmount)
                {
                    orderTotal = payment - totalAmount;

                    txtChange.Text = orderTotal.ToString();
                }
                else
                {
                    MessageBox.Show("Please pay the right amount!");
                    txtChange.Text = string.Empty;
                }
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "************************RECEIPT************************" + "\n" + "\n"
                + "Cappucino $4.20 x " + qty1 + " = " + subtotal + "\n"
                + "Expresso $3.00 x " + qty2 + " = " + subtotal2 + "\n"
                + "Latte $3.50 x " + qty3 + " = " + subtotal3 + "\n"
                + "Americano $5.00 x " + qty4 + " = " + subtotal4 + "\n"
                + "\n" + "\n"
                + "Sub Total :   P " + total + "\n"
                + "Tax 8% :      P " + tax + "\n"
                + "Total Amount: P " + totalAmount + "\n"
                + "Payment:      P " + payment + "\n"
                + "Change:       P " + orderTotal + "\n" + "\n"
                + "****************************************************************";
        }


    }


}
