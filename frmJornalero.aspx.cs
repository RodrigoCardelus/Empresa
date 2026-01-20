using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class frmJornalero : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        //Creamos la variable antes del try, para poder hacer el Close en el finally
        SqlConnection cnn = null;
        try
        {
            //Para conocer los tipo de conexión usamos https://www.connectionstrings.com/

            string conexion = "Server=.;Database=Empresa;Trusted_Connection=True";
            //Generamos una instancia de SqlConnection con el string de conexión que contiene la info necesaria para
            //conectarme a la base de datos.
            cnn = new SqlConnection(conexion);

            //Genero un comando para pasarle la consulta SQL.
            //El comando necesita para funcionar dos cosas:
            // 1- la conexión
            // 2- la consulta SQL o el Procedimiento Almacenado (SP)
            SqlCommand cmd = new SqlCommand();

            //Como la conexión la la tengo (cnn), lo que me resta es generar la consulta SQL
            string cedula = txtCedula.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            DateTime nac = Convert.ToDateTime(txtNacimiento.Text);

            string consulta = string.Format("INSERT Empleados VALUES ({0}, '{1}' , '{2}' , '{3}')", cedula,
                nombre, apellido, nac.ToShortDateString());

            //Le indico al comando cual es la conexión y cual es la consulta
            cmd.Connection = cnn;
            cmd.CommandText = consulta;

            //Solo resta: Abrir la conexión, ejecutar el comando y cerrar la conexión.
            cnn.Open();
            cmd.ExecuteNonQuery();
            //cnn.Close();

            lblMensaje.Text = "Se agregó correctamente al empleado";
        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }
        finally
        { cnn.Close(); }
    }
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        SqlConnection cnn = null;
        try
        {
            string conexion = "Server=.;Database=Empresa;Trusted_Connection=True";
            cnn = new SqlConnection(conexion);

            SqlCommand cmd = new SqlCommand();

            string cedula = txtCedula.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            DateTime nac = Convert.ToDateTime(txtNacimiento.Text);

            string consulta = string.Format("UPDATE Empleados SET Nombre = '{1}', Apellido = '{2}', Nacimiento = '{3}' WHERE Cedula = {0}",
                cedula, nombre, apellido, nac.ToShortDateString());

            cmd.Connection = cnn;
            cmd.CommandText = consulta;

            cnn.Open();
            int resp = cmd.ExecuteNonQuery();

            if (resp > 0)
                lblMensaje.Text = "Se modificó correctamente al empleado";
            else
                lblMensaje.Text = "No se modificó, ya que no hay empleados con la cédula " + cedula;
        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }
        finally
        { cnn.Close(); }
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        SqlConnection cnn = null;
        try
        {
            string conexion = "Server=.;Database=Empresa;Trusted_Connection=True";
            cnn = new SqlConnection(conexion);

            SqlCommand cmd = new SqlCommand();

            string cedula = txtCedula.Text;

            string consulta = string.Format("DELETE Empleados WHERE Cedula = {0}", cedula);

            cmd.Connection = cnn;
            cmd.CommandText = consulta;

            cnn.Open();
            //Recordar que el entero devuelto por el 'ExecuteNonQuery' es la cantidad de filas afectadas por la consulta.
            int resp = cmd.ExecuteNonQuery();

            if (resp > 0)
                lblMensaje.Text = "Se eliminó correctamente al empleado";
            else
                lblMensaje.Text = "No se eliminó, ya que no hay empleados con la cédula " + cedula;
        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }
        finally
        { cnn.Close(); }
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        SqlConnection cnn = null;
        try
        {
            string conexion = "Server=.;Database=Empresa;Trusted_Connection=True";
            cnn = new SqlConnection(conexion);

            SqlCommand cmd = new SqlCommand();
            string cedula = txtCedula.Text;
            string consulta = "SELECT * FROM Empleados WHERE cedula = " + cedula;
            cmd.Connection = cnn;
            cmd.CommandText = consulta;

            cnn.Open();
            SqlDataReader lector = cmd.ExecuteReader();

            //Para saber si tengo líneas para recorrer pregunto:
            if (!lector.HasRows)
                lblMensaje.Text = "No hay empleados con la cédula " + cedula;
            else
            {
                //'Read()' se mueve a la siguiente línea, y como en esta caso ya comprobamos que hay línea para moverse,
                //no tengo problemas. Además en este caso solo habría una línea, dado que el select esta filtrado por cédula
                lector.Read();

                //Después del Read() lector esta sobre la primera línea, por lo que hay que capturar la info de cada campo
                //de la línea. A los campos se acceden por su nombre o por el índice. El nombre es el que está en la consulta
                //y el índice corresponde al orden de los campos en la consulta

                //No cargo el txtCedula, dado que es el dato desde el que partí.
                txtNombre.Text = (string)lector[1];
                txtApellido.Text = lector[2].ToString();
                txtNacimiento.Text = ((DateTime)lector["nacimiento"]).ToShortDateString();
                lblMensaje.Text = "";//Por las dudas de que haya un mensaje de acciones anteriores.
            }
        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }
        finally
        { cnn.Close(); }
    }
    protected void btnListarEmp_Click(object sender, EventArgs e)
    {
        SqlConnection cnn = null;
        try
        {
            string conexion = "Server=.;Database=Empresa;Trusted_Connection=True";
            cnn = new SqlConnection(conexion);
            SqlCommand cmd = new SqlCommand();

            string consulta = "SELECT * FROM Empleados";
            cmd.Connection = cnn;
            cmd.CommandText = consulta;
            cnn.Open();
            SqlDataReader lector = cmd.ExecuteReader();

            //Para saber si tengo líneas para recorrer pregunto:
            if (!lector.HasRows)
                lblMensaje.Text = "No hay empleados para listar.";
            else
            {
                //Antes de agregar los empleados al ListBox, vacío el ListBox
                lstListaEmpleados.Items.Clear();
                while (lector.Read())
                {
                    ListItem item = new ListItem((string)lector[1] + " - " + (string)lector[2], lector[0].ToString());
                    lstListaEmpleados.Items.Add(item);

                    //La línea de abajo no agregaría info en el value de cada item, por eso dejo la de arriba.
                    //lstListaEmpleados.Items.Add((string)lector[1] + " - " + (string)lector[2]);
                }
                lblMensaje.Text = "";
            }
        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }
        finally
        { cnn.Close(); }
    }
    protected void btnListarEmpSP_Click(object sender, EventArgs e)
    {
        SqlConnection cnn = null;
        try
        {
            string conexion = "Server=.;Database=Empresa;Trusted_Connection=True";
            cnn = new SqlConnection(conexion);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "ListarEmpleados";//Esta vez vamos a indicar el nombre le procedimiento almacenado.

            //Hay que indicar que el comando contien un nombre de SP
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cnn.Open();
            SqlDataReader lector = cmd.ExecuteReader();
            if (!lector.HasRows)
                lblMensaje.Text = "No hay empleados para listar.";
            else
            {
                lstListaEmpleados.Items.Clear();
                while (lector.Read())
                {
                    ListItem item = new ListItem(lector[1] + " - " + lector[2], lector[0].ToString());
                    lstListaEmpleados.Items.Add(item);
                }
                lblMensaje.Text = "";
            }
        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }
        finally
        { cnn.Close(); }
    }
    protected void BuscarSP_Click(object sender, EventArgs e)
    {
        SqlConnection cnn = null;
        try
        {
            string conexion = "Server=.;Database=Empresa;Trusted_Connection=True";
            cnn = new SqlConnection(conexion);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "BuscarEmpleado";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //Como el SP recibe un parámetro, necesitamos crear un pámetro y agregarlo al comando.
            SqlParameter prmCedula = new SqlParameter(); //No uso contructor completo para que se entienda mejor.
            prmCedula.ParameterName = "@cedula"; //Indico el nombre del parámetro tal cual en el SP de SQL
            prmCedula.Value = txtCedula.Text; //Le cargo el valor

            cmd.Parameters.Add(prmCedula);//Agrego el parámetro a la lista de parámetros del comando.

            cnn.Open();
            SqlDataReader lector = cmd.ExecuteReader();

            if (lector.Read())
            {
                txtCedula.Text = lector[0].ToString();
                txtNombre.Text = lector[1].ToString();
                txtApellido.Text = lector[2].ToString();
                txtNacimiento.Text = ((DateTime)lector[3]).ToShortDateString();
                lblMensaje.Text = "";
            }
            else
            {
                lblMensaje.Text = "No se encontró ningún empleado con la cédula " + txtCedula.Text;
            }
        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }
        finally
        { cnn.Close(); }
    }
    protected void tnEliminarSP_Click(object sender, EventArgs e)
    {
        SqlConnection cnn = null;
        try
        {
            string conexion = "Server=.;Database=Empresa;Trusted_Connection=True";
            cnn = new SqlConnection(conexion);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "EliminarEmpleado";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //Creo el parámetro con los datos
            SqlParameter prmCedula = new SqlParameter("@cedula", txtCedula.Text);
            //Agrego el parámetro a la colección de parámetros del comando
            cmd.Parameters.Add(prmCedula);

            cnn.Open();
            int resp = cmd.ExecuteNonQuery();
            if (resp <= 0)
                lblMensaje.Text = "No hay ningún empleado con la cédula " + txtCedula.Text;
            else
                lblMensaje.Text = "Se eliminó correctamente al empleado.";
        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }
        finally
        { cnn.Close(); }
    }
    protected void btnAgregarSP_Click(object sender, EventArgs e)
    {
        SqlConnection cnn = null;
        try
        {
            string conexion = "Server=.;Database=Empresa;Trusted_Connection=True";
            cnn = new SqlConnection(conexion);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "AgregarEmpleado";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //Para agregar los parámetros lo podemos resumir en:
            cmd.Parameters.AddWithValue("@cedula", txtCedula.Text);
            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
            cmd.Parameters.AddWithValue("@apellido", txtApellido.Text);
            cmd.Parameters.AddWithValue("@nac", txtNacimiento.Text);

            cnn.Open();
            int resp = cmd.ExecuteNonQuery();
            if (resp <= 0)
                lblMensaje.Text = "Ya hay un empleado con la cédula " + txtCedula.Text;
            else
                lblMensaje.Text = "Se agregó correctamente al empleado.";
        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }
        finally
        { cnn.Close(); }
    }
    protected void btnModificarSP_Click(object sender, EventArgs e)
    {
        SqlConnection cnn = null;
        try
        {
            string conexion = "Server=.;Database=Empresa;Trusted_Connection=True";
            cnn = new SqlConnection(conexion);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "ModificarEmpleado";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@cedula", txtCedula.Text);
            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
            cmd.Parameters.AddWithValue("@apellido", txtApellido.Text);
            cmd.Parameters.AddWithValue("@nac", txtNacimiento.Text);

            //Creo un parámetro para que capture el 'return' del SP
            SqlParameter prmReturn = new SqlParameter();
            //Indico que el parámetro es del tipo return
            prmReturn.Direction = System.Data.ParameterDirection.ReturnValue;
            // OJO!!!! No olvidarse de agragar el parámetro a la colección de parámetros del comando
            cmd.Parameters.Add(prmReturn);

            cnn.Open();
            cmd.ExecuteNonQuery();
            //SE puede cerrar la conexión, dado que el valor del return ya quedó en el prmReturn
            //cnn.Close();

            int retorno = (int)prmReturn.Value;
            switch (retorno)
            {
                case -1:
                    lblMensaje.Text = "La cédula ingresada NO existe en la BD.";
                    break;
                case -2:
                    lblMensaje.Text = "La fecha de nacimiento debe ser previa a la de hoy.";
                    break;
                case 1:
                    lblMensaje.Text = "Se agregó correctamente al empleado.";
                    break;
                default:
                    lblMensaje.Text = "Error desconocido. Contacte al administrador del sistema";
                    break;
            }
        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }
        finally
        { cnn.Close(); }
    }
}