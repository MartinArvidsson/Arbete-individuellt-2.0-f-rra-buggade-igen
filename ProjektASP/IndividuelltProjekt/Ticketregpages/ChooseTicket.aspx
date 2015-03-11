<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Masterpage.Master" AutoEventWireup="true" CodeBehind="ChooseTicket.aspx.cs" Inherits="IndividuelltProjekt.Ticketregpages.ChooseTicket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <asp:ListView ID="ContactListView" runat="server"
                    ItemType="IndividuelltProjekt.Model.BLL.Ticket"

                    SelectMethod="TicketListView_GetData"

                    DataKeyNames="BiljettID"

                   >
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
                                <input type="radio" name="RadioTicket" value='<%#Eval("BiljettID") %>'/>
                                <%-- Förbannat vad strul det ska vara med radiobutton i listview, Fråga om en bra lösning --%>
                                <label>Välj Biljett för registering av faktura</label>
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
                </asp:ListView>
        <asp:Button ID="Button1" runat="server" Text="Avsluta registering" OnClick="Button1_Click" />
</asp:Content>
