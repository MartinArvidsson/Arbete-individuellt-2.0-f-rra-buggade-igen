<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Masterpage.Master" AutoEventWireup="true" CodeBehind="FinishReg.aspx.cs" Inherits="IndividuelltProjekt.Ticketregpages.FinishReg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                                    Biljett
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
                            <asp:TextBox ID="PersonID" runat="server" Text='<%# BindItem.PersonID %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="BiljettID" runat="server" Text='<%# BindItem.BiljettID %>' />
                        </td>

                    </tr>
                </InsertItemTemplate>
            </asp:ListView>  
    <asp:Button ID="Button1" runat="server" Text="Avsluta registrering" OnClick="Button1_Click" /> 
</asp:Content>
