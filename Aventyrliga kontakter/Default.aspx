<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Aventyrliga_kontakter.Default" ViewStateMode="Disabled"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="Model/BLL/Script.js"></script>
    <title></title>
</head>
<body>
        <div id="Main">
            <form id="theForm" runat="server">
                <h1>
                    Kunder
                </h1>
                <asp:PlaceHolder ID="MessagePlaceholder" Visible="false" runat="server">
                    <div id="MessageBox">
                        <asp:Label ID="ConfirmationLabel" runat="server" Text=""></asp:Label>
                            <div id="CloseButton">
                               <label>X</label>
                            </div>
                        <%--<button id="CloseButton" ></button>--%>
                    </div>
                </asp:PlaceHolder>

                <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Fel inträffade"
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
                    <InsertItemTemplate>
                        <tr>
                        <td>
                            <asp:TextBox ID="Förnamn" runat="server" Text='<%# BindItem.FirstName %>' />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="ej giltigt förnamn" ControlToValidate="Förnamn"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="Efternamn" runat="server" Text='<%# BindItem.LastName %>' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ej giltigt efternamn" ControlToValidate="Efternamn"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="Emailadress" runat="server" Text='<%# BindItem.EmailAdress %>'/>
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Ej giltig epost" ControlToValidate="Emailadress" ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?"></asp:RegularExpressionValidator>
                        </td>
                        <td>
                            <asp:LinkButton runat="server" CommandName="Insert" Text="Lägg till" CausesValidation="False" />
                            <asp:LinkButton runat="server" CommandName="Cancel" Text="Rensa" CausesValidation="false" />
                        </td>
                    </tr>
                    </InsertItemTemplate>

                    <EditItemTemplate>
                    <tr>
                        <td>
                            <asp:TextBox ID="Förnamn" runat="server" Text='<%# BindItem.FirstName %>' />
                            <asp:RequiredFieldValidator 
                                ID="RequiredFieldValidator1" 
                                runat="server" ErrorMessage="Ej giltigt förnamn" 
                                ControlToValidate="Förnamn">
                            </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="Efternamn" runat="server" Text='<%# BindItem.LastName %>' />
                        <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator2" 
                            runat="server" 
                            ErrorMessage="Ej giltigt efternamn" 
                            ControlToValidate="Efternamn">
                        </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="Emailadress" runat="server" Text='<%# BindItem.EmailAdress %>'/>
                        <asp:RequiredFieldValidator 
                            ID="RequiredFieldValidator3" 
                            runat="server" 
                            ErrorMessage="RequiredFieldValidator" 
                            ControlToValidate="Emailadress">
                        </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator 
                                ID="RegularExpressionValidator1" 
                                runat="server" 
                                ErrorMessage="Ej giltig epost" 
                                ControlToValidate="Emailadress" 
                                ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?">
                            </asp:RegularExpressionValidator>
                        </td>
                        <td>
                            <asp:LinkButton runat="server" CommandName="Update" Text="Spara" CausesValidation="False"/>
                            <asp:LinkButton runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />
                        </td>
                    </tr>
                </EditItemTemplate>
                </asp:ListView>
            </form>
        </div>
</body>
</html>
