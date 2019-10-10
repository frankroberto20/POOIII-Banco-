using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.ServiceProcess;
using System.Timers;

namespace IntegrationService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer1 = new Timer
            {
                Interval = 300000
            };
            timer1.Elapsed += new ElapsedEventHandler(this.Timer1_Tick);
            timer1.Enabled = true;
            timer1.Start();
        }

        protected override void OnStop()
        {
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                SqlDataReader reader;
                SqlConnection sqlConnection = new SqlConnection(@"Data Source = integracion - banco - p3.database.windows.net; Initial Catalog = IntegracionDB; User ID = integracion1; Password = IntegracionP3");
                sqlConnection.Open();
                string select = "select Cuenta, Monto, Operacion from TblMovimientos where Enviada=0";
                SqlCommand sqlCommand = new SqlCommand(select, sqlConnection)
                {
                    Connection = sqlConnection
                };
                reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    List<Movimiento> list = new List<Movimiento>();
                    while (reader.Read())
                    {
                        string sel2 = "select TitularDeCuenta from TblCuentas where NumeroDeCuenta=@ID";
                        SqlCommand sqlCommand2 = new SqlCommand(sel2, sqlConnection);
                        sqlCommand2.Parameters.AddWithValue("@ID", SqlDbType.NVarChar);
                        sqlCommand2.Parameters["@ID"].Value = reader.GetInt32(0);
                        sqlCommand2.Connection = sqlConnection;
                        SqlDataReader reader2 = sqlCommand2.ExecuteReader();
                        Movimiento x = new Movimiento(reader.GetInt32(0), reader.GetDecimal(1), reader.GetString(2), reader2.GetString(0));
                        x.MovimientoPurge();
                        reader2.Close();
                        sqlCommand2.Dispose();
                    }
                }
                else throw new Exception();
                reader.Close();
                sqlConnection.Close();
            }
            catch (Exception)
            {

            }
        }
        public class Movimiento
        {
            public string Cedula;
            public int Cuenta;
            public decimal Monto;
            public string Operacion;
            public Movimiento(int cuenta, decimal monto, string op, string cedula)
            {
                Cedula = cedula;
                Cuenta = cuenta;
                Monto = monto;
                Operacion = op;
            }

            public void MovimientoPurge()
            {
                if (this.Operacion.ToUpper() == "RETIRO")
                {
                    CoreServices.WebServicesCoreSoapClient coreSoap = new CoreServices.WebServicesCoreSoapClient();
                    coreSoap.Retirar(Cedula, Cuenta.ToString(), Monto);//RETIRO
                }
                else if (this.Operacion.ToUpper() == "DEPOSITO")
                {
                    CoreServices.WebServicesCoreSoapClient coreSoap = new CoreServices.WebServicesCoreSoapClient();
                    coreSoap.Depositar(Cedula, Cuenta.ToString(), Monto); //DEPOSITO
                }
                else return;

            }
        }
    }
}
