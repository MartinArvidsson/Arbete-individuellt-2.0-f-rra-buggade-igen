<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Aventyrliga_kontakter.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
        <div id="Main">
            <form id="theForm" runat="server">
                <h1>
                    Kunder
                </h1>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Fel inträffade ;_; Gör om, Gör rätt"
                cssClass="ValidationSumErrors" />


                <asp:ListView ID="ContactListView" runat="server"
                    ItemType="Aventyrliga_kontakter.BLL.Contact"

                    SelectMethod="ContactListView_GetData"

                    InsertMethod="ContactListView_InsertItem"

                    UpdateMethod="ContactListView_UpdateItem"

                    DeleteMethod="ContactListView_DeleteItem"

                    DataKeyNames="ContactId"

                    InsertItemPosition="FirstItem">
                    <LayoutTemplate>
                        <table>
                            <tr>
                                <th>
                                    Förnamn
                                </th>
                                <th>
                                    Efternamn
                                </th>
                                <th>
                                    Epostadress
                                </th>
                            </tr>
                            <asp:PlaceHolder ID="ItemPlaceholder" runat="server"/>
                        </table>
                        <asp:DataPager ID="DataPager1" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ShowFirstPageButton="True" FirstPageText=" << "
                                    ShowNextPageButton="False" ShowPreviousPageButton="False"  />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ShowLastPageButton="True" LastPageText=" >> "
                                    ShowNextPageButton="False" ShowPreviousPageButton="False"  />
                    </Fields>
                        </asp:DataPager>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#: Item.FirstName %>
                            </td>
                            <td>
                                <%#: Item.LastName %>
                            </td>
                            <td>
                                <%#: Item.EmailAdress %>
                            </td>
                            <td class="command">
                                <asp:LinkButton runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false"/>
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
                    <InsertItemTemplate>
                        <tr>
                        <td>
                            <asp:TextBox ID="Förnamn" runat="server" Text='<%# BindItem.FirstName %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="Efternamn" runat="server" Text='<%# BindItem.LastName %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="Emailadress" runat="server" Text='<%# BindItem.EmailAdress %>'/>
                        </td>
                        <td>
                            <asp:LinkButton runat="server" CommandName="Insert" Text="Lägg till" />
                            <asp:LinkButton runat="server" CommandName="Cancel" Text="Rensa" CausesValidation="false" />
                        </td>
                    </tr>
                    </InsertItemTemplate>

                    <EditItemTemplate>
                    <tr>
                        <td>
                            <asp:TextBox ID="Förnamn" runat="server" Text='<%# BindItem.FirstName %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="Efternamn" runat="server" Text='<%# BindItem.LastName %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="Emailadress" runat="server" Text='<%# BindItem.EmailAdress %>'/>
                        </td>
                        <td>
                            <asp:LinkButton runat="server" CommandName="Update" Text="Spara" />
                            <asp:LinkButton runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />
                        </td>
                    </tr>
                </EditItemTemplate>
                </asp:ListView>
            </form>
        </div>
</body>
</html>
