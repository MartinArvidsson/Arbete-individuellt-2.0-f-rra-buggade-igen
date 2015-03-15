<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Masterpage.Master" AutoEventWireup="true" CodeBehind="FinishReg.aspx.cs" Inherits="IndividuelltProjekt.Ticketregpages.FinishReg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
     <asp:PlaceHolder ID="MessagePlaceholder" Visible="false" runat="server">
                    <div id="MessageBox">
                        <asp:Label ID="ConfirmationLabel" runat="server" Text=""></asp:Label>
                            <div id="CloseButton">
                               <label>X</label>
                            </div>
                    </div>
                </asp:PlaceHolder>
    
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Fel inträffade"
        cssClass="ValidationSumErrors" />
      
    <asp:label ID="BiljettLabel" runat="server" Text=""></asp:label>
    <asp:label ID="PersonLabel" runat="server" Text=""></asp:label>--%>
    
    <asp:ListView ID="Transactionview" runat="server"

                    ItemType="IndividuelltProjekt.Model.BLL.Transaction"

                    SelectMethod="Transactionview_GetData"

                    InsertMethod="Transactionview_InsertItem"

                    DataKeyNames="TransactionID"

                    InsertItemPosition="FirstItem">
                    <LayoutTemplate>
                        <table>
                            <tr>
                                <th>
                                    Person
                                </th>
                                <th>
                                    Förnamn
                                </th>
                                <th>
                                    Efternamn
                                </th>
                                <th>
                                    Biljett
                                </th>
                            </tr>
                            <asp:PlaceHolder ID="ItemPlaceholder" runat="server"/>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#:Item.PersonID %>
                            </td>
                            <td>                            
                                <%#:Item.Fnamn %>
                            </td>
                            <td>
                                <%#:Item.Enamn %>
                            </td>
                            <td>
                                <%#:Item.BiljettID %>
                            </td>
                           <td class="command">    
                           </td>                           
                        </tr>
                    </ItemTemplate>
                    
                    <EmptyDataTemplate>
                         <table class="grid">
                        <tr>
                            <td>
                                Personuppgift saknas .
                            </td>
                        </tr>
                    </table>
                    </EmptyDataTemplate>
                <InsertItemTemplate>
                <tr>
                <td>
                        <%#: Item.PersonID %>
                    </td>
                    <td>
                        <%#: Item.BiljettID %>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="Insert" Text="Slutför!" ValidationGroup="Temp" />
                    
                    </td>
                    </tr>
                </InsertItemTemplate>
            </asp:ListView>  
    <asp:Button ID="Button1" runat="server" Text="Avsluta registrering" OnClick="Button1_Click" Enabled="false" /> 
</asp:Content>
