<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Kaydol.aspx.cs" Inherits="site.Kaydol" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Kaydol</title>

    <link href="style.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div style="width:293px; margin-top:50px; margin-left: auto; margin-right: auto; margin-bottom: 0;">

        <div class="solkısım2">

            <asp:Panel ID="pnlKayit" runat="server">

                 <div class="hızlıkayıt">
                    <div class="ust">
                        Hızlı Kayıt Ol
                    </div>
                    <div class="alt">

                        <br />
&nbsp;&nbsp;&nbsp; Kullanıcı Adı<br />
                    <asp:TextBox ID="txtKullaniciAdi" CssClass="textbox" runat="server" />

                        <br />
                        <br />
&nbsp;&nbsp;&nbsp; Şifre<br />
                    <asp:TextBox ID="txtSifre" CssClass="textbox" runat="server"/>

                        &nbsp;<asp:Button ID="btnKayit" CssClass="btnKayit" Text="Kaydet" runat="server" Height="36px" Width="109px" OnClick="btnKayit_Click" />
                    <asp:Label ID="lblSonuc" Text="" runat="server" />
                     
                        <a href="/" class="btnGiris" >İptal</a></div>
                </div>

            </asp:Panel>
            
            <asp:Panel ID="pnlDurum" runat="server" style="background-color:#d5d5d5;">
                <asp:Label ID="lblDurum" Text="" runat="server"/>
                <br />
                &nbsp;&nbsp; <a href="/">Ana Sayfaya Git</a>

              </asp:Panel>


            </div>
            </div>






        
        
    </form>
</body>
</html>
