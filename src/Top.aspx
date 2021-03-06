<%@ Page Title="" Language="C#" MasterPageFile="~/master_Home.Master" AutoEventWireup="true" CodeBehind="Top.aspx.cs" Inherits="MusicWebOnline.Top" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="__Top">
        <div class="__Top_TieuDe"></div>
        <div class="Top_XepHang">
            <asp:DataList ID="Album__" runat="server" Width="100%" RepeatColumns="1">
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButton2" runat="server" Height="120px"
                        ImageUrl='<%# "~/img_album/"+Eval("Hinh") %>'
                        PostBackUrl='<%#Eval("MaAlbum","~/Play.aspx?A={0}") %>'
                        Width="200px" />
                    <div id="TenAlbum">
                        <asp:HyperLink ID="cl3" runat="server"
                            NavigateUrl='<%# Eval("MaAlbum","~/Play.aspx?A={0}") %>'
                            Text='<%# Eval("TenAlbum") %>'></asp:HyperLink>
                    </div>
                    <br />
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</asp:Content>
