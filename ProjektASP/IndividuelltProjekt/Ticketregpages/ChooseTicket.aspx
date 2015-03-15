<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Masterpage.Master" AutoEventWireup="true" CodeBehind="ChooseTicket.aspx.cs" Inherits="IndividuelltProjekt.Ticketregpages.ChooseTicket" %>
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
     
    <asp:ListView ID="ContactListView" runat="server"
                    ItemType="IndividuelltProjekt.Model.BLL.Ticket"
                    SelectMethod="TicketListView_GetData"
                    DataKeyNames="BiljettID">
                    <LayoutTemplate>
                        <table>
                            <tr>
                                <th>
                                    Biljettyp
                                </th>
                                <th>
                                    Biljettnamn
                                </th>
                                <th>
                                    Kostnad
                                </th>
                                <th>
                                    Välj Biljett för registering av faktura för att komplettera den valda personen
                                </th>
                            </tr>
                            <asp:PlaceHolder ID="ItemPlaceholder" runat="server"/>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#: Item.BiljettID %>
                            </td>
                            
                            <td>
                                <%#: Item.Biljettnamn %>
                            </td>

                            <td>
                                <%#: Item.kostnad %>
                            </td>
                            <td class="Commands">
                                <asp:LinkButton runat="server" CommandArgument='<%#:Item.BiljettID %>' OnClick="TicketListView_AddFaktura" Text="Välj för fakturaregistering" CausesValidation="false"/>                                
                            </td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                         <table class="grid">
                        <tr>
                            <td>
                                Biljett saknas .
                            </td>
                        </tr>
                    </table>
                    </EmptyDataTemplate>
                </asp:ListView>
</asp:Content>
