<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Masterpage.Master" AutoEventWireup="true" CodeBehind="FinishReg.aspx.cs" Inherits="IndividuelltProjekt.Ticketregpages.FinishReg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
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
       
    <asp:ListView ID="EndView" runat="server"
                    ItemType="IndividuelltProjekt.Model.BLL.Transaction"
                    SelectMethod="EndView_GetData"
                    DataKeyNames="TransactionID">                    
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
                                     Biljett nummer:<asp:label ID="BiljettLabel" runat="server" Text=""></asp:label>  
                                </td>
                                <td>                            
                                    Person nummer:<asp:label ID="PersonLabel" runat="server" Text=""></asp:label>
                                </td>
                           <td class="command">
                               <td>                             
                                    <asp:LinkButton runat="server" Text="Avsluta!" CausesValidation="false" OnClick="Finish_Registration" CommandArgument='<%#Convert.ToInt32(Eval("PersonLabel"))%>''<%#Convert.ToInt32(Eval("BiljettLabel"))%>'/>
                               </td>     
                           </td>                                                        
                        </tr>
                    </ItemTemplate>
            </asp:ListView>
    <asp:Button ID="Button1" runat="server" Text="Button" enabled="false"/>
</asp:Content>
