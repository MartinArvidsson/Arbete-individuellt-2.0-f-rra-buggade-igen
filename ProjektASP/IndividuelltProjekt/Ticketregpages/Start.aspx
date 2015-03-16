<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Masterpage.Master" AutoEventWireup="true" CodeBehind="Start.aspx.cs" Inherits="IndividuelltProjekt.Ticketregpages.Start" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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

                <asp:ListView ID="Transactionview" runat="server"
                    ItemType="IndividuelltProjekt.Model.BLL.Transaction"
                    SelectMethod="Transactionview_GetData"
                    InsertMethod="Transactionview_InsertItem"
                    DeleteMethod="Transactionview_DeleteItem"
                    DataKeyNames="TransactionID"

                    InsertItemPosition="FirstItem">
                    <LayoutTemplate>
                        <table id="TableOne">
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
                                    Personnummer
                                </th>
                                <th>
                                    Biljettyp
                                </th>
                                <th>
                                    Biljettnamn
                                </th>
                                <th>
                                    Kostnad
                                </th>
                            </tr>
                            <asp:PlaceHolder ID="ItemPlaceholder" runat="server"/>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>                            
                            <td>
                                <%#: Item.PersonID %>
                            </td>
                            <td>
                                <%#: Item.Fnamn %>
                            </td>
                            <td>
                                <%#: Item.Enamn %>
                            </td>
                            <td>
                                <%#: Item.Fdatum %>
                            </td>

                            <td>
                                <%#: Item.BiljettID %>
                            </td>
                            <td>
                                <%#: Item.BiljettNamn %>
                            </td>
                            <td>
                                <%#: Item.BiljettKostnad %>
                            </td>
                            <td class="command">
                                <asp:LinkButton runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false" OnClientClick="return confirmation();"/>
                            </td>
                         
                        </tr>
                    </ItemTemplate>
                    
                    <EmptyDataTemplate>
                         <table class="grid">
                        <tr>
                            <td>
                                Kontaktuppgift saknas .
                            </td>
                        </tr>
                    </table>
                    </EmptyDataTemplate>
                <InsertItemTemplate>
                </InsertItemTemplate>
            </asp:ListView>  
    <asp:Button ID="Button1" runat="server" Text="Starta registering" OnClick="Button1_Click" />                  
</asp:Content>
