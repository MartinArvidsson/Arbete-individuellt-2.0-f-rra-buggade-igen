<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Masterpage.Master" AutoEventWireup="true" CodeBehind="RegPerson.aspx.cs" Inherits="IndividuelltProjekt.Ticketregpages.RegPerson" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Fel inträffade"
                cssClass="ValidationSumErrors" />


                <asp:ListView ID="PersonListView" runat="server"
                    ItemType="IndividuelltProjekt.Model.BLL.Person"
                    
                    SelectMethod="PersonListView_GetData"

                    InsertMethod="PersonListView_InsertItem"

                    UpdateMethod="PersonListView_UpdateItem"

                    DeleteMethod="PersonListView_DeleteItem"

                    DataKeyNames="PersonID"

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
                                    Födelsedatum
                                </th>
                                <th>
                                    Välj person för registering av faktura
                                </th>
                            </tr>
                            <asp:PlaceHolder ID="ItemPlaceholder" runat="server"/>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#: Item.Fnamn %>
                            </td>
                            
                            <td>
                                <%#: Item.Enamn %>
                            </td>

                            <td>
                                <%#: Item.Fdatum %>
                            </td>

                            <td class="command">
                                <asp:LinkButton runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false" OnClientClick="return confirmation();"/>
                                <asp:LinkButton runat="server" CommandName="Edit" Text="Redigera" CausesValidation="false"/>
                                <asp:LinkButton runat="server" CommandArgument='<%#:Item.PersonID %>' OnClick="PersonListView_AddFaktura" Text="Välj för fakturaregistering" CausesValidation="false"/>
                                
                                <%--<input type="radio" name="RadioPerson" checked="checked" value='<%#Eval("PersonID") %>'/>--%>
                                <%-- Förbannat vad strul det ska vara med radiobutton i listview, Fråga om en bra lösning --%>
                

                            </td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                         <table class="grid">
                        <tr>
                            <td>
                                Personuppgifter saknas .
                            </td>
                        </tr>
                    </table>
                    </EmptyDataTemplate>
                    <InsertItemTemplate>
                        <tr>
                        <td>
                            <asp:TextBox ID="Förnamn" runat="server" Text='<%# BindItem.Fnamn %>' Maxlength="50"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1a" runat="server" ErrorMessage="ej giltigt förnamn" ControlToValidate="Förnamn" ValidationGroup="AddPerson"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="Efternamn" runat="server" Text='<%# BindItem.Enamn %>' MaxLength="50"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2a" runat="server" ErrorMessage="Ej giltigt efternamn" ControlToValidate="Efternamn" ValidationGroup="AddPerson"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="Födelsedatum" runat="server" Text='<%# BindItem.Fdatum %>' MaxLength="10"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3a" runat="server" ErrorMessage="Ej giltigt efternamn" ControlToValidate="Födelsedatum" ValidationGroup="AddPerson"></asp:RequiredFieldValidator>  
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="RegularExpressionValidator" ValidationExpression="^(19|20)\d\d([- /.])(0[1-9]|1[012])\2(0[1-9]|[12][0-9]|3[01])$" ControlToValidate="Födelsedatum"></asp:RegularExpressionValidator>
                        </td>
                        <td>
                            <asp:LinkButton runat="server" CommandName="Insert" Text="Lägg till" ValidationGroup="AddPerson" />
                            <asp:LinkButton runat="server" CommandName="Cancel" Text="Rensa" CausesValidation="false"  />
                        </td>
                    </tr>
                    </InsertItemTemplate>

                    <EditItemTemplate>
                    <tr>
                        <td>
                            <asp:TextBox ID="Förnamn" runat="server" Text='<%# BindItem.Fnamn %>' MaxLength="50"/>
                            <asp:RequiredFieldValidator 
                                ID="RequiredFieldValidator1" 
                                runat="server" ErrorMessage="Ej giltigt förnamn" 
                                ControlToValidate="Förnamn"
                                ValidationGroup="AddPerson">
                            </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="Efternamn" runat="server" Text='<%# BindItem.Enamn %>' MaxLength="50"/>
                        <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator2" 
                            runat="server" 
                            ErrorMessage="Ej giltigt efternamn" 
                            ControlToValidate="Efternamn"
                            ValidationGroup="AddPerson">
                        </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="Födelsedatum" runat="server" Text='<%# BindItem.Fdatum %>' MaxLength="15"/>
                        <asp:RequiredFieldValidator 
                            ID="RequiredFieldValidator3" 
                            runat="server" 
                            ErrorMessage="RequiredFieldValidator" 
                            ControlToValidate="Födelsedatum"
                            ValidationGroup="AddPerson">
                        </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:LinkButton runat="server" CommandName="Update" Text="Spara"  CausesValidation="false"/>
                            <asp:LinkButton runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />
                        </td>
                    </tr>
                </EditItemTemplate>
                </asp:ListView>               
</asp:Content>

