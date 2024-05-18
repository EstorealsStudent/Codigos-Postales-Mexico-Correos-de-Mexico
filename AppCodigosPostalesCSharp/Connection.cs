using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Data;

public class Connection
{
    private static SqlConnection cnx = new SqlConnection();
    private static void Connect()
    {
        try
        {
            cnx.ConnectionString = "Data Source=localhost; Initial Catalog=CorreosMexico;Integrated Security=True";
            cnx.Open();
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Error al conectar a la base de datos: " + ex.Message);
        }
    }
    private static void Disconect()
    {
        try
        {
            if (cnx.State == ConnectionState.Open)
                cnx.Close();
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Error al desconectar de la base de datos: " + ex.Message);
        }
    }
    // Create a method to excecute a Selection query
    public static DataTable SelectQuery(string query)
    {
        DataTable dt = new DataTable();
        try
        {
            Connect();
            SqlCommand cmd = new SqlCommand(query, cnx);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Error al ejecutar la consulta: " + ex.Message);
        }
        finally
        {
            Disconect();
        }
        return dt;
    }
}
