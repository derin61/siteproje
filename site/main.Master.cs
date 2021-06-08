using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace site
{
    public partial class main : System.Web.UI.MasterPage
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

            object kullanici = Session["kullaniciadi"];

            if(kullanici !=null)
            {
                pnlGiris.Visible = false;
                pnlKullanici.Visible = true;
                lblKullaniciAdi.Text = kullanici.ToString();
            }
            else
            {
                pnlKullanici.Visible = false;
                pnlGiris.Visible = true;
                
            }


        }



        protected void txtSifre_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnKayit_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text;
            string sifre = txtSifre.Text;
            if (txtKullaniciAdi.Text != "" && txtSifre.Text != "")
            {

                SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString);

                string sorgu = "Insert into Kullanicilar (KullaniciAdi,Sifre) Values(@kullaniciadi,@sifre)";

                SqlCommand cmd = new SqlCommand(sorgu, cnn);

                cnn.Open();

                try
                {
                    cmd.Parameters.AddWithValue("@kullaniciadi", txtKullaniciAdi.Text);
                    cmd.Parameters.AddWithValue("@sifre", txtSifre.Text);

                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    lblSonuc.Text = "Kayıt Yapılmıştır";
                }
                catch (Exception)
                {
                    lblSonuc.Text = "Kayıt yapılamadı";
                }

            }
            else
            {
                lblSonuc.Text = "Boş alanı doldurunuz";
            }

       
               
        }

        protected void txtKullaniciAdi_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            string sorgu = "Select * From Kullanicilar Where KullaniciAdi=@kullaniciadi AND Sifre =@sifre";

            SqlCommand cmd = new SqlCommand(sorgu, cnn);
            cmd.Parameters.AddWithValue("@kullaniciadi", txtKullaniciAdi.Text);
            cmd.Parameters.AddWithValue("@sifre", txtSifre.Text);

            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                Session.Timeout = 300;
                Session.Add("kullaniciadi", dr["KullaniciAdi"].ToString());
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                lblSonuc.Text = "Giriş Sağlanamadı";
            }  
            cnn.Close();

        }

        protected void btnCikis_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect(Request.RawUrl);
        }

        protected void txtSifre_TextChanged1(object sender, EventArgs e)
        {

        }
    }
}