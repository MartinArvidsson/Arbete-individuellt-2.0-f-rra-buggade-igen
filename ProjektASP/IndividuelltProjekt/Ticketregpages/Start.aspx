<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Masterpage.Master" AutoEventWireup="true" CodeBehind="Start.aspx.cs" Inherits="IndividuelltProjekt.Ticketregpages.Start" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
                        <table>
                            <tr>
                                <th>
                                    Person
                                </th>
                                <th>
                                    Biljettyp
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
                                <%#: Item.BiljettID %>
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
                <tr>
                        <%--<td>
                            <asp:TextBox ID="PersonID" runat="server" Text='<%# BindItem.PersonID %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="BiljettID" runat="server" Text='<%# BindItem.BiljettID %>' />
                        </td>
                        <td>
                            <asp:LinkButton runat="server" CommandName="Insert" Text="Lägg till" />
                            <asp:LinkButton runat="server" CommandName="Cancel" Text="Rensa" CausesValidation="false" />
                        </td>--%>
                    </tr>
                </InsertItemTemplate>
                <%--<EditItemTemplate>
                    <tr>
                        <td>
                            <asp:TextBox ID="PersonID" runat="server" Text='<%# BindItem.PersonID %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="BiljettID" runat="server" Text='<%# BindItem.BiljettID %>' />
                        </td>
                        <td>
                            <asp:LinkButton runat="server" CommandName="Update" Text="Spara" />
                            <asp:LinkButton runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />
                        </td>
                    </tr>
                </EditItemTemplate>--%>
            </asp:ListView>  
    <asp:Button ID="Button1" runat="server" Text="Starta registering" />                  
</asp:Content>
