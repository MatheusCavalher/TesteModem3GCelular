using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO.Ports;

namespace smsTeste
{
    public partial class Form1 : Form
    {
        String telefone = "", ddd = "";
        SqlCommand cmd;  
        errorLog ErrorLog = new errorLog();
        SerialPort port = new SerialPort();
        FunSMS objclsSMS = new FunSMS();
        ShortMessageCollection objShortMessageCollection = new ShortMessageCollection();

        public Form1()
        {
            InitializeComponent();
        }

        public void enviaTeste1()
        {
            SqlConnection conn = ConexaoBanco.conectarBanco();
            String portaserial, correto, mensagem;

            cmd = new SqlCommand("SELECT PORTASERIAL FROM ");
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable tabela = new DataTable();
            cmd.Connection = conn;
            dataAdapter.Fill(tabela);

            if (tabela.Rows != null && tabela.Rows.Count > 0)
            {
                try
                {
                    portaserial = tabela.Rows[0]["portaserial"].ToString().Trim();

                    this.port = objclsSMS.OpenPort(Convert.ToString(portaserial), Convert.ToInt32(9600), Convert.ToInt32(8), Convert.ToInt32(300), Convert.ToInt32(300));

                    correto = "+55" + ddd + "" + telefone + "";

                    mensagem = "Teste da porta " + portaserial + ": OK!";

                   if (objclsSMS.sendMsg(this.port, Convert.ToString(correto), mensagem))
                        {
                            pbxModem0.Image = smsTeste.Properties.Resources.check;
                            prb1.Value = 10;
                            lblCarregamento.Text = "10";
                        }
                        else
                        {
                            pbxModem0.Image = smsTeste.Properties.Resources.check2;
                            prb1.Value = 10;
                            lblCarregamento.Text = "10";
                        }

                        objclsSMS.ClosePort(this.port);
                }
                catch { }
            }
            Application.DoEvents();
            ConexaoBanco.desconectarBanco();
        }

        public void enviaTeste2()
        {
            SqlConnection conn = ConexaoBanco.conectarBanco();
            String portaserial, correto, mensagem;

            cmd = new SqlCommand("SELECT PORTASERIAL FROM ");
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable tabela = new DataTable();
            cmd.Connection = conn;
            dataAdapter.Fill(tabela);

            if (tabela.Rows != null && tabela.Rows.Count > 0)
            {
                try
                {
                    portaserial = tabela.Rows[1]["portaserial"].ToString().Trim();

                    this.port = objclsSMS.OpenPort(Convert.ToString(portaserial), Convert.ToInt32(9600), Convert.ToInt32(8), Convert.ToInt32(300), Convert.ToInt32(300));

                    correto = "+55" + ddd + "" + telefone + "";

                    mensagem = "Teste da porta " + portaserial + ": OK!";

                    try
                    {
                        if (objclsSMS.sendMsg(this.port, Convert.ToString(correto), mensagem))
                        {
                            pbxModem1.Image = smsTeste.Properties.Resources.check;
                            prb1.Value = 20;
                            lblCarregamento.Text = "20";
                        }
                        else
                        {
                            pbxModem1.Image = smsTeste.Properties.Resources.check2;
                            prb1.Value = 20;
                            lblCarregamento.Text = "20";
                        }
                    }
                    catch
                    {
                        pbxModem1.Image = smsTeste.Properties.Resources.check2;
                        prb1.Value = 20;
                        lblCarregamento.Text = "20";
                    }

                        objclsSMS.ClosePort(this.port);
                }
                catch { }
            }
            Application.DoEvents();
            ConexaoBanco.desconectarBanco();
        }

        public void enviaTeste3()
        {
            SqlConnection conn = ConexaoBanco.conectarBanco();
            String portaserial, correto, mensagem;

            cmd = new SqlCommand("SELECT PORTASERIAL FROM ");
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable tabela = new DataTable();
            cmd.Connection = conn;
            dataAdapter.Fill(tabela);

            if (tabela.Rows != null && tabela.Rows.Count > 0)
            {
                try
                {
                    portaserial = tabela.Rows[2]["portaserial"].ToString().Trim();

                    this.port = objclsSMS.OpenPort(Convert.ToString(portaserial), Convert.ToInt32(9600), Convert.ToInt32(8), Convert.ToInt32(300), Convert.ToInt32(300));
   
                    correto = "+55" + ddd + "" + telefone + "";

                    mensagem = "Teste da porta " + portaserial + ": OK!";

                    try
                    {
                        if (objclsSMS.sendMsg(this.port, Convert.ToString(correto), mensagem))
                        {
                            pbxModem2.Image = smsTeste.Properties.Resources.check;
                            prb1.Value = 30;
                            lblCarregamento.Text = "30";
                        }
                        else
                        {
                            pbxModem2.Image = smsTeste.Properties.Resources.check2;
                            prb1.Value = 30;
                            lblCarregamento.Text = "30";
                        }
                    }
                    catch
                    {
                        pbxModem2.Image = smsTeste.Properties.Resources.check2;
                        prb1.Value = 30;
                        lblCarregamento.Text = "30";
                    }
                        objclsSMS.ClosePort(this.port);

                }
                catch { }
            }
            Application.DoEvents();
            ConexaoBanco.desconectarBanco();
        }

        public void enviaTeste4()
        {
            SqlConnection conn = ConexaoBanco.conectarBanco();
            String portaserial, correto, mensagem;

            cmd = new SqlCommand("SELECT PORTASERIAL FROM ");
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable tabela = new DataTable();
            cmd.Connection = conn;
            dataAdapter.Fill(tabela);

            if (tabela.Rows != null && tabela.Rows.Count > 0)
            {
                try
                {
                    portaserial = tabela.Rows[3]["portaserial"].ToString().Trim();

                    this.port = objclsSMS.OpenPort(Convert.ToString(portaserial), Convert.ToInt32(9600), Convert.ToInt32(8), Convert.ToInt32(300), Convert.ToInt32(300));

                    correto = "+55" + ddd + "" + telefone + "";

                    mensagem = "Teste da porta " + portaserial + ": OK!";

                    try
                    {
                        if (objclsSMS.sendMsg(this.port, Convert.ToString(correto), mensagem))
                        {
                            pbxModem3.Image = smsTeste.Properties.Resources.check;
                            prb1.Value = 40;
                            lblCarregamento.Text = "40";
                        }
                        else
                        {
                            pbxModem3.Image = smsTeste.Properties.Resources.check2;
                            prb1.Value = 40;
                            lblCarregamento.Text = "40";
                        }
                    }
                    catch
                    {
                        pbxModem3.Image = smsTeste.Properties.Resources.check2;
                        prb1.Value = 40;
                        lblCarregamento.Text = "40";
                    }

                        objclsSMS.ClosePort(this.port);
                }
                catch { }
            }
            Application.DoEvents();
            ConexaoBanco.desconectarBanco();
        }

        public void enviaTeste5()
        {
            SqlConnection conn = ConexaoBanco.conectarBanco();
            String portaserial, correto, mensagem;

            cmd = new SqlCommand("SELECT PORTASERIAL FROM ");
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable tabela = new DataTable();
            cmd.Connection = conn;
            dataAdapter.Fill(tabela);

            if (tabela.Rows != null && tabela.Rows.Count > 0)
            {
                try
                {
                    portaserial = tabela.Rows[4]["portaserial"].ToString().Trim();

                    this.port = objclsSMS.OpenPort(Convert.ToString(portaserial), Convert.ToInt32(9600), Convert.ToInt32(8), Convert.ToInt32(300), Convert.ToInt32(300));

                    correto = "+55" + ddd + "" + telefone + "";

                    mensagem = "Teste da porta " + portaserial + ": OK!";

                    try
                    {
                        if (objclsSMS.sendMsg(this.port, Convert.ToString(correto), mensagem))
                        {
                            pbxModem4.Image = smsTeste.Properties.Resources.check;
                            prb1.Value = 50;
                            lblCarregamento.Text = "50";
                        }
                        else
                        {
                            pbxModem4.Image = smsTeste.Properties.Resources.check2;
                            prb1.Value = 50;
                            lblCarregamento.Text = "50";
                        }
                    }
                    catch
                    {
                        pbxModem4.Image = smsTeste.Properties.Resources.check2;
                        prb1.Value = 50;
                        lblCarregamento.Text = "50";
                    }

                        objclsSMS.ClosePort(this.port);


                }
                catch { }
            }
            Application.DoEvents();
            ConexaoBanco.desconectarBanco();
        }

        public void enviaTeste6()
        {
            SqlConnection conn = ConexaoBanco.conectarBanco();
            String portaserial, correto, mensagem;

            cmd = new SqlCommand("SELECT PORTASERIAL FROM ");
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable tabela = new DataTable();
            cmd.Connection = conn;
            dataAdapter.Fill(tabela);

            if (tabela.Rows != null && tabela.Rows.Count > 0)
            {
                try
                {
                    portaserial = tabela.Rows[5]["portaserial"].ToString().Trim();

                    this.port = objclsSMS.OpenPort(Convert.ToString(portaserial), Convert.ToInt32(9600), Convert.ToInt32(8), Convert.ToInt32(300), Convert.ToInt32(300));

                    correto = "+55" + ddd + "" + telefone + "";

                    mensagem = "Teste da porta " + portaserial + ": OK!";

                    try
                    {
                        if (objclsSMS.sendMsg(this.port, Convert.ToString(correto), mensagem))
                        {
                            pbxModem5.Image = smsTeste.Properties.Resources.check;
                            prb1.Value = 60;
                            lblCarregamento.Text = "60";
                        }
                        else
                        {
                            pbxModem5.Image = smsTeste.Properties.Resources.check2;
                            prb1.Value = 60;
                            lblCarregamento.Text = "60";
                        }
                    }
                    catch
                    {
                        pbxModem5.Image = smsTeste.Properties.Resources.check2;
                        prb1.Value = 60;
                        lblCarregamento.Text = "60";
                    }

                        objclsSMS.ClosePort(this.port);
                }
                catch { }
            }
            Application.DoEvents();
            ConexaoBanco.desconectarBanco();
        }

        public void enviaTeste7()
        {
            SqlConnection conn = ConexaoBanco.conectarBanco();
            String portaserial, correto, mensagem;

            cmd = new SqlCommand("SELECT PORTASERIAL FROM ");
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable tabela = new DataTable();
            cmd.Connection = conn;
            dataAdapter.Fill(tabela);

            if (tabela.Rows != null && tabela.Rows.Count > 0)
            {
                try
                {
                    portaserial = tabela.Rows[6]["portaserial"].ToString().Trim();

                    this.port = objclsSMS.OpenPort(Convert.ToString(portaserial), Convert.ToInt32(9600), Convert.ToInt32(8), Convert.ToInt32(300), Convert.ToInt32(300));

                    correto = "+55" + ddd + "" + telefone + "";

                    mensagem = "Teste da porta " + portaserial + ": OK!";

                    try
                    {
                        if (objclsSMS.sendMsg(this.port, Convert.ToString(correto), mensagem))
                        {
                            pbxModem6.Image = smsTeste.Properties.Resources.check;
                            prb1.Value = 70;
                            lblCarregamento.Text = "70";
                        }
                        else
                        {
                            pbxModem6.Image = smsTeste.Properties.Resources.check2;
                            prb1.Value = 70;
                            lblCarregamento.Text = "70";
                        }
                    }
                    catch
                    {
                        pbxModem6.Image = smsTeste.Properties.Resources.check2;
                        prb1.Value = 70;
                        lblCarregamento.Text = "70";
                    }
                        objclsSMS.ClosePort(this.port);
                }
                catch { }
            }
            Application.DoEvents();
            ConexaoBanco.desconectarBanco();
        }

        public void enviaTeste8()
        {
            SqlConnection conn = ConexaoBanco.conectarBanco();
            String portaserial, correto, mensagem;

            cmd = new SqlCommand("SELECT PORTASERIAL FROM ");
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable tabela = new DataTable();
            cmd.Connection = conn;
            dataAdapter.Fill(tabela);

            if (tabela.Rows != null && tabela.Rows.Count > 0)
            {
                try
                {
                    portaserial = tabela.Rows[7]["portaserial"].ToString().Trim();

                    this.port = objclsSMS.OpenPort(Convert.ToString(portaserial), Convert.ToInt32(9600), Convert.ToInt32(8), Convert.ToInt32(300), Convert.ToInt32(300));

                    correto = "+55" + ddd + "" + telefone + "";

                    mensagem = "Teste da porta " + portaserial + ": OK!";

                    try
                    {
                        if (objclsSMS.sendMsg(this.port, Convert.ToString(correto), mensagem))
                        {
                            pbxModem7.Image = smsTeste.Properties.Resources.check;
                            prb1.Value = 80;
                            lblCarregamento.Text = "80";
                        }
                        else
                        {
                            pbxModem7.Image = smsTeste.Properties.Resources.check2;
                            prb1.Value = 80;
                            lblCarregamento.Text = "80";
                        }
                    }
                    catch
                    {
                        pbxModem7.Image = smsTeste.Properties.Resources.check2;
                        prb1.Value = 80;
                        lblCarregamento.Text = "80";
                    }

                        objclsSMS.ClosePort(this.port);
                }
                catch { }
            }
            Application.DoEvents();
            ConexaoBanco.desconectarBanco();
        }

        public void enviaTeste9()
        {
            SqlConnection conn = ConexaoBanco.conectarBanco();
            String portaserial, correto, mensagem;

            cmd = new SqlCommand("SELECT PORTASERIAL FROM ");
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable tabela = new DataTable();
            cmd.Connection = conn;
            dataAdapter.Fill(tabela);

            if (tabela.Rows != null && tabela.Rows.Count > 0)
            {
                try
                {
                    portaserial = tabela.Rows[8]["portaserial"].ToString().Trim();

                    this.port = objclsSMS.OpenPort(Convert.ToString(portaserial), Convert.ToInt32(9600), Convert.ToInt32(8), Convert.ToInt32(300), Convert.ToInt32(300));

                    correto = "+55" + ddd + "" + telefone + "";

                    mensagem = "Teste da porta " + portaserial + ": OK!";

                    try
                    {
                        if (objclsSMS.sendMsg(this.port, Convert.ToString(correto), mensagem))
                        {
                            pbxModem8.Image = smsTeste.Properties.Resources.check;
                            prb1.Value = 90;
                            lblCarregamento.Text = "90";
                        }
                        else
                        {
                            pbxModem8.Image = smsTeste.Properties.Resources.check2;
                            prb1.Value = 90;
                            lblCarregamento.Text = "90";
                        }
                    }
                    catch
                    {
                        pbxModem8.Image = smsTeste.Properties.Resources.check2;
                        prb1.Value = 90;
                        lblCarregamento.Text = "90";
                    }

                    objclsSMS.ClosePort(this.port);
                }
                catch { }
            }
            Application.DoEvents();
            ConexaoBanco.desconectarBanco();
        }

        public void enviaTeste10()
        {
            SqlConnection conn = ConexaoBanco.conectarBanco();
            String portaserial, correto, mensagem;

            cmd = new SqlCommand("SELECT PORTASERIAL FROM ");
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable tabela = new DataTable();
            cmd.Connection = conn;
            dataAdapter.Fill(tabela);

            if (tabela.Rows != null && tabela.Rows.Count > 0)
            {
                try
                {
                    portaserial = tabela.Rows[9]["portaserial"].ToString().Trim();

                    this.port = objclsSMS.OpenPort(Convert.ToString(portaserial), Convert.ToInt32(9600), Convert.ToInt32(8), Convert.ToInt32(300), Convert.ToInt32(300));

                    correto = "+55" + ddd + "" + telefone + "";

                    mensagem = "Teste da porta " + portaserial + ": OK!";

                    try
                    {
                        if (objclsSMS.sendMsg(this.port, Convert.ToString(correto), mensagem))
                        {
                            pbxModem9.Image = smsTeste.Properties.Resources.check;
                            prb1.Value = 100;
                            lblCarregamento.Text = "100";
                        }
                        else
                        {
                            pbxModem9.Image = smsTeste.Properties.Resources.check2;
                            prb1.Value = 100;
                            lblCarregamento.Text = "100";
                        }
                    }
                    catch
                    {
                        pbxModem9.Image = smsTeste.Properties.Resources.check2;
                        prb1.Value = 100;
                        lblCarregamento.Text = "100";
                    }

                        objclsSMS.ClosePort(this.port);
                }
                catch { }
            }
            Application.DoEvents();
            ConexaoBanco.desconectarBanco();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnTeste.PerformClick();
            Application.Exit();
        }

        private void btnTeste_Click(object sender, EventArgs e)
        {
            enviaTeste1();
            enviaTeste2();
            enviaTeste3();
            enviaTeste4();
            enviaTeste5();
            enviaTeste6();
            enviaTeste7();
            enviaTeste8();
            enviaTeste9();
            enviaTeste10(); 
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            pbxModem0.Image = smsTeste.Properties.Resources.check2;
            pbxModem1.Image = smsTeste.Properties.Resources.check2;
            pbxModem2.Image = smsTeste.Properties.Resources.check2;
            pbxModem3.Image = smsTeste.Properties.Resources.check2;
            pbxModem4.Image = smsTeste.Properties.Resources.check2;
            pbxModem5.Image = smsTeste.Properties.Resources.check2;
            pbxModem6.Image = smsTeste.Properties.Resources.check2;
            pbxModem7.Image = smsTeste.Properties.Resources.check2;
            pbxModem8.Image = smsTeste.Properties.Resources.check2;
            pbxModem9.Image = smsTeste.Properties.Resources.check2;

            lblCarregamento.Text = "0";
            prb1.Value = 0;

            btnTeste.PerformClick();
        }
    }
}