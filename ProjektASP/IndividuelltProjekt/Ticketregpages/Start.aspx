<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Masterpage.Master" AutoEventWireup="true" CodeBehind="Start.aspx.cs" Inherits="IndividuelltProjekt.Ticketregpages.Start" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Fel inträffade"
        cssClass="ValidationSumErrors" />

                <asp:ListView ID="Transactionview" runat="server"
                    ItemType="IndividuelltProjekt.BLL.Transaction"

                    SelectMethod="Transactionview_GetData"

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
                                <asp:LinkButton runat="server" CommandName="Edit" Text="Redigera" CausesValidation="false"/>
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
</asp:Content>
