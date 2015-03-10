<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Masterpage.Master" AutoEventWireup="true" CodeBehind="RegPerson.aspx.cs" Inherits="IndividuelltProjekt.Ticketregpages.RegPerson" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Fel inträffade"
                cssClass="ValidationSumErrors" />


                <asp:ListView ID="ContactListView" runat="server"
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
                            <asp:TextBox ID="Förnamn" runat="server" Text='<%# BindItem.Fnamn %>' Maxlength="50"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1a" runat="server" ErrorMessage="ej giltigt förnamn" ControlToValidate="Förnamn"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="Efternamn" runat="server" Text='<%# BindItem.Enamn %>' MaxLength="50"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2a" runat="server" ErrorMessage="Ej giltigt efternamn" ControlToValidate="Efternamn"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="Födelsedatum" runat="server" Text='<%# BindItem.Fdatum %>' MaxLength="15"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3a" runat="server" ErrorMessage="Ej giltigt efternamn" ControlToValidate="Födelsedatum"></asp:RequiredFieldValidator>  
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
                            <asp:TextBox ID="Förnamn" runat="server" Text='<%# BindItem.Fnamn %>' MaxLength="50"/>
                            <asp:RequiredFieldValidator 
                                ID="RequiredFieldValidator1" 
                                runat="server" ErrorMessage="Ej giltigt förnamn" 
                                ControlToValidate="Förnamn">
                            </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="Efternamn" runat="server" Text='<%# BindItem.Enamn %>' MaxLength="50"/>
                        <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator2" 
                            runat="server" 
                            ErrorMessage="Ej giltigt efternamn" 
                            ControlToValidate="Efternamn">
                        </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="Födelsedatum" runat="server" Text='<%# BindItem.Fdatum %>' MaxLength="15"/>
                        <asp:RequiredFieldValidator 
                            ID="RequiredFieldValidator3" 
                            runat="server" 
                            ErrorMessage="RequiredFieldValidator" 
                            ControlToValidate="Födelsedatum">
                        </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:LinkButton runat="server" CommandName="Update" Text="Spara" CausesValidation="False"/>
                            <asp:LinkButton runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />
                        </td>
                    </tr>
                </EditItemTemplate>
                </asp:ListView>
        <asp:Button ID="Button1" runat="server" Text="Fortsätt registering" />                  
</asp:Content>

