using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;
namespace JossemarProMegaFinalSinoDaMeSuicido
{
    public partial class FrmAgregarProductoNuevo : Form
    {
        public FrmAgregarProductoNuevo(string a)
        {
            InitializeComponent();
            id = a;
        }
        string id;
        CLogicaObtenerIP idS = new CLogicaObtenerIP();
        CLogicaRegistrarProducto save = new CLogicaRegistrarProducto();
        CLogicaLlenarCmb fill = new CLogicaLlenarCmb();
        private void BtnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void FrmAgregarProductoNuevo_Load(object sender, EventArgs e)
        {
            LblIdUsuario.Text = id;
            cmbCategorias();
            cmbUnidadMedida();
        }

        void CapturarDatos()
        {
            string nom = TxtNombreProducto.Text;
            int IdUnidadM = Convert.ToInt32(CmbUnidadMedida.SelectedValue.ToString());
            string descrip = TxtDescripcion.Text;
            string marca = TxtMarca.Text;
            int IdCategoria = Convert.ToInt32(CmbCategoria.SelectedValue.ToString());
            string fecha = DtpCaducidad.Value.ToString("yyy/MM/dd");
            //string IdS = idS.ObtenerSede();

            /*Obtener sede*/
            CLogicaConsultas c = new CLogicaConsultas();
            CLogicaObtenerIP b = new CLogicaObtenerIP();
            string localIP = b.ObtenerIp();

            MessageBox.Show("Local Ip = " + localIP);

            string idU = c.ConsultaSimple("SELECT IpMaquina.IdUsuario FROM IpMaquina WHERE IpMaquina.IpMaquina = '" + localIP + "'");
            string IdSede = c.ConsultaSimple("SELECT Usuarios.IdSede FROM Usuarios WHERE Usuarios.IdUsuario = '" + idU + "'");

            //MessageBox.Show("Nombre = " + nom);
            //MessageBox.Show("UnidadM = " + IdUnidadM);
            //MessageBox.Show("descrip = " + descrip);

            //MessageBox.Show("marca = " + marca);
            //MessageBox.Show("IdCategoria = " + IdCategoria);
            //MessageBox.Show("fecha = " + fecha);
            //MessageBox.Show("IdS = " + IdSede);

            string result = save.AgregarProductos(nom,descrip,marca,0,IdUnidadM,IdCategoria,Convert.ToInt32(IdSede));


            MessageBox.Show("Res = " + result);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            CapturarDatos();
        }

        private void TxtNombreProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloLetrasONumeros(e);
        }

        private void TxtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloLetrasONumeros(e);
        }

        private void TxtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloLetrasONumeros(e);
        }

        void cmbCategorias()
        {
            CmbCategoria.DataSource = fill.cmbCategoria();
            CmbCategoria.DisplayMember = "DescripcionC";
            CmbCategoria.ValueMember = "IdCategoria";

        }

        void cmbUnidadMedida()
        {
            CmbUnidadMedida.DataSource = fill.cmbUnidadM();
            CmbUnidadMedida.DisplayMember = "DescripcionTipoUM";
            CmbUnidadMedida.ValueMember = "IdUnidadM";

        }

    }
}
