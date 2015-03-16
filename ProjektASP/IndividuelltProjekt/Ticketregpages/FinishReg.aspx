<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Masterpage.Master" AutoEventWireup="true" CodeBehind="FinishReg.aspx.cs" Inherits="IndividuelltProjekt.Ticketregpages.FinishReg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Fel inträffade"/>

     <asp:PlaceHolder ID="MessagePlaceholder" Visible="false" runat="server">
         <div id="MessageBox">
             <asp:Label ID="ConfirmationLabel" runat="server" Text=""></asp:Label>
             <div id="CloseButton">
                 <label>X</label>
             </div>
         </div>
      </asp:PlaceHolder>

     Person nummer:<asp:Label ID="BiljettLabel" runat="server" Text="<%$RouteValue:id%>"></asp:Label> <br />
    Biljett nummer:<asp:Label ID="PersonLabel" runat="server" Text="<%$RouteValue:id2%>"></asp:Label> <br />                                                     
                          
    
    <asp:Button ID="Button1" runat="server" Text="Avsluta registering" OnClick="Button1_Click"/>
</asp:Content>
