using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using Logica_Proyecto;
//
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;




public class BaseDeDatos 
{
    private string connection = string.Empty;
    private SqlConnection connect;
    private SqlCommand command;
    private SqlDataAdapter da;
    private SqlDataReader dr;
    private DataTable dt;
    private DataSet ds;
    private DataRow dar;//

    public BaseDeDatos()
    {
        connect = new SqlConnection();
        try
        {
            connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        }
        catch
        {
            connection = ConfigurationManager.AppSettings.Get("connection");
        }
    }
    private SqlConnection connecttodb()
    {
        if (connect.State != ConnectionState.Open)
        {
            try
            {
                connect.ConnectionString = connection;
                connect.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        return connect;
    }
    private void closeconnection()
    {
        if (connect.State != ConnectionState.Closed)
            connect.Close();
    }
    public string selectstring(string query)
    {
        string cadena = string.Empty;
        try
        {
            connecttodb();
            command = new SqlCommand(query, connect);
            cadena = command.ExecuteScalar().ToString();
        }
        catch
        {
            cadena = string.Empty;
        }
        finally
        {
            closeconnection();
        }
        return cadena;
    }

    public bool executecommand(string query)
    {
        bool exito;
        try
        {
            connecttodb();
            command = new SqlCommand(query, connect);
            command.ExecuteNonQuery();
            exito = true;
        }
        catch
        {
            exito = false;
        }
        finally
        {
            closeconnection();
        }
        return exito;
    }

    public bool ExecuteStoreProcedure(string namestoreprocedure)
    {
        try
        {
            connecttodb();
            command = new SqlCommand(namestoreprocedure, connect);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            return true;
        }
        catch
        {
            return false;
        }
        finally
        {
            closeconnection();
        }
    }

    public DataTable SelectDataTableFromStoreProcedure(string namestoreprocedure)
    {
        dt = new DataTable();
        try
        {
            connecttodb();
            command = new SqlCommand(namestoreprocedure, connect);//
            command.CommandType = CommandType.StoredProcedure;
            dt = new DataTable();
            da = new SqlDataAdapter();
            da.SelectCommand = command;
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            closeconnection();
        }
        return dt;
    }
    public DataTable SelectDataTable(string query)
    {
        dt = new DataTable();
        try
        {
            connecttodb();
            da = new SqlDataAdapter(query, connect);
            da.Fill(dt);
              
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            connecttodb();
        }
        return dt;
    }

    public DataSet SelectDataSet(string query, string table)
    {
        ds = new DataSet();
        try
        {
            connecttodb();
            da = new SqlDataAdapter(query, connect);
            da.Fill(ds, table);
        }
        catch //(Exception ex)
        {
            // ds = null;
        }
        finally
        {
            closeconnection();
        }
        return ds;
    }

    public void autocompletar(string query,string columna, int estado,TextBox cajatexto)
    {
        Querys qry = new Querys();
        try
        {
            connecttodb();
            command = new SqlCommand(query, connect);
            dr = command.ExecuteReader();
            while (dr.Read())
            {
                if (estado == 1) cajatexto.AutoCompleteCustomSource.Add(qry.desencriptacion(dr[columna].ToString())); //de["Nombre"]
                if (estado == 2) cajatexto.AutoCompleteCustomSource.Add(dr[columna].ToString()); //de["Nombre"]

            }
            dr.Close();
            //closeconnection();
        }
        catch (Exception ex)
        {

            MessageBox.Show("Fallo no se completo el textbox" + ex.ToString());
        }
    }


    public void verImagen(PictureBox pbFoto)
    {
        try
        {
            connecttodb();
            da = new SqlDataAdapter("select FotoBuffet from Buffet where NombreBuffet = 'Hola'", connect);
            ds = new DataSet();
            da.Fill(ds, "Buffet");
            byte[] datos = new byte[0];
            dar = ds.Tables["Buffet"].Rows[0];
            datos = (byte[])dr["FotoBuffet"];
            System.IO.MemoryStream ms = new System.IO.MemoryStream(datos);
            pbFoto.Image = System.Drawing.Bitmap.FromStream(ms);
        }
        catch (Exception ex)
        {
            MessageBox.Show("No se pudo consultar la Imagen: " + ex.ToString());
        }
        finally
        {
            connecttodb();
        }
    }

    public bool executecommandImagen(byte[] foto, string sql)
    {

        bool exito;
        try
        {
            connecttodb();
            command = new SqlCommand(sql, connect);
            command.Parameters.Add("@Imagen", SqlDbType.Image);

           /* System.IO.MemoryStream ms = new System.IO.MemoryStream();

            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            command.Parameters["@Imagen"].Value = ms.GetBuffer();*/
            command.Parameters["@Imagen"].Value = foto;
            //command.Parameters.AddWithValue("@Imagen", foto);
            command.ExecuteNonQuery();
            exito = true;
        }
        catch (Exception ex)
        {
            exito = false;
        }
        finally
        {
            connecttodb();
        }
        return exito;
    }

    public bool executecommand2Imagen(byte[] foto1,byte[] foto2, string sql)
    {

        bool exito;
        try
        {
            connecttodb();
            command = new SqlCommand(sql, connect);
            command.Parameters.Add("@Imagen1", SqlDbType.Image);
            command.Parameters.Add("@Image2", SqlDbType.Image);

            /* System.IO.MemoryStream ms = new System.IO.MemoryStream();

             imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
             command.Parameters["@Imagen"].Value = ms.GetBuffer();*/
            command.Parameters["@Imagen1"].Value = foto1;
            command.Parameters["@Imagen2"].Value = foto2;
            //command.Parameters.AddWithValue("@Imagen", foto);
            command.ExecuteNonQuery();
            exito = true;
        }
        catch (Exception ex)
        {
            exito = false;
        }
        finally
        {
            connecttodb();
        }
        return exito;
    }

   /* public string insertarImagen(System.Drawing.Image imageIn, string tabla, string columna)
    {
        string mensaje = "Se inserto la imagen";
        try
        {
            command = new SqlCommand("Insert into " + tabla + "(" + columna + ") values(,@Imagen)", connect);
            command.Parameters.Add("@Imagen", SqlDbType.Image);

            System.IO.MemoryStream ms = new System.IO.MemoryStream();

            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            command.Parameters["@Imagen"].Value = ms.GetBuffer();
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            mensaje = "No se inserto la imagen: " + ex.ToString();
        }
        return mensaje;
    }*/

   /* public string insertarImagen(PictureBox pbImagen, string tabla, string columna)
    {
        string mensaje = "Se inserto la imagen";
        try
        {
            command = new SqlCommand("Insert into "+ tabla +"("+ columna +") values(,@Imagen)", connect);
            command.Parameters.Add("@Imagen", SqlDbType.Image);

            System.IO.MemoryStream ms = new System.IO.MemoryStream();

            pbImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            command.Parameters["@Imagen"].Value = ms.GetBuffer();
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            mensaje = "No se inserto la imagen: " + ex.ToString();
        }
        return mensaje;
    }*/

  /*  public string insertarImagen(PictureBox pbImagen)
    {
        string mensaje = "Se inserto la imagen";
        string descripcion = "Hola";
        try
        {        
            connecttodb();
            command = new SqlCommand("Insert into Buffet(NombreBuffet,FotoBuffet) values(@NombreBuffet,@Imagen)", connect);
            command.Parameters.Add("@NombreBuffet", SqlDbType.NChar);
            command.Parameters.Add("@Imagen", SqlDbType.Image);

            command.Parameters["@NombreBuffet"].Value = descripcion;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();

            pbImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            command.Parameters["@Imagen"].Value = ms.GetBuffer();
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            mensaje = "No se inserto la imagen: " + ex.ToString();
        }
        return mensaje;
    }*/

}

