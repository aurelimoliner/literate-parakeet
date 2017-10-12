using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace biblioteca
{
    class bDallioli
    {
        public int siNoEstaenAlliInsertar()         {
            int iNR = -1;
            using (OleDbConnection cnn = new OleDbConnection(conString))
            {
                string sql = "SELECT * FROM  alli WHERE data = ? and cognoms = ?";
                OleDbCommand cmd = new OleDbCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@data", OleDbType.WChar).Value = f.data;
                cmd.Parameters.AddWithValue("@cognoms", OleDbType.WChar).Value = f.cognoms;
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = cmd;
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                adapter.Fill(table);
                iNR = table.Rows.Count;
            }
            if (iNR == 0)
            {

                using (OleDbConnection cnn = new OleDbConnection(conString))             {
                    string query = "INSERT INTO alli (numFormulari, " +
                            "adre, codicentre,codipostal, cognoms, c" +
                            "ontrol, data, datanaix, dni, entitat, i" +
                            "ban, mail,nom, nomipoblacio, numero,obs" +
                            "ervacions, oficina, poblacio, sitadmin," +
                            " telefon, territori, tmovil) VALUES " +
                            "(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?);";
                    OleDbCommand cmd = new OleDbCommand(query, cnn);
                    cnn.Open();
                    cmd.Parameters.AddWithValue("@numFormulari", OleDbType.Integer).Value = f.numFormulari;
                    cmd.Parameters.AddWithValue("@adre", OleDbType.WChar).Value = f.adre;
                    cmd.Parameters.AddWithValue("@codicentre", OleDbType.WChar).Value = f.codicentre;
                    cmd.Parameters.AddWithValue("@codipostal", OleDbType.WChar).Value = f.codipostal;
                    cmd.Parameters.AddWithValue("@cognoms", OleDbType.WChar).Value = f.cognoms;
                    cmd.Parameters.AddWithValue("@control", OleDbType.WChar).Value = f.control;
                    cmd.Parameters.AddWithValue("@data", OleDbType.WChar).Value = f.data;
                    cmd.Parameters.AddWithValue("@datanaix", OleDbType.WChar).Value = f.datanaix;
                    cmd.Parameters.AddWithValue("@dni", OleDbType.WChar).Value = f.dni;
                    cmd.Parameters.AddWithValue("@entitat", OleDbType.WChar).Value = f.entitat;
                    cmd.Parameters.AddWithValue("@iban", OleDbType.WChar).Value = f.iban;
                    cmd.Parameters.AddWithValue("@mail", OleDbType.WChar).Value = f.mail;
                    cmd.Parameters.AddWithValue("@nom", OleDbType.WChar).Value = f.nom;
                    cmd.Parameters.AddWithValue("@nomipoblacio", OleDbType.WChar).Value = f.nomipoblacio;
                    cmd.Parameters.AddWithValue("@numero", OleDbType.WChar).Value = f.numero;
                    cmd.Parameters.AddWithValue("@observacions", OleDbType.WChar).Value = f.observacions;
                    cmd.Parameters.AddWithValue("@oficina", OleDbType.WChar).Value = f.oficina;
                    cmd.Parameters.AddWithValue("@poblacio", OleDbType.WChar).Value = f.poblacio;
                    cmd.Parameters.AddWithValue("@sitadmin", OleDbType.WChar).Value = f.sitadmin;
                    cmd.Parameters.AddWithValue("@telefon", OleDbType.WChar).Value = f.telefon;
                    cmd.Parameters.AddWithValue("@territori", OleDbType.WChar).Value = f.territori;
                    cmd.Parameters.AddWithValue("@tmovil", OleDbType.WChar).Value = f.tmovil;
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show(e.Message);
                        throw;
                    }
                } else {
                    contadv += 1;
                }
            }
        }
    }
}
