﻿<%@ Page Title="" Language="C#" MasterPageFile="~/NavegadorPrincipal.Master" AutoEventWireup="true" CodeBehind="catConceptosDeObraAdd.aspx.cs" Inherits="SIP.Formas.Catalogos.catConceptosDeObraAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">



        function fnc_Confirmar() {
            return confirm("¿Está seguro de eliminar el registro?");
        }




    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="container">

        <div class="panel-footer alert alert-success" id="divMsgSuccess" style="display:none" runat="server">
                <asp:Label ID="lblMensajeSuccess" runat="server" Text=""></asp:Label>
    </div>
    <div class="panel-footer alert alert-danger" id="divMsg" style="display:none" runat="server">
                <asp:Label ID="lblMensajes" runat="server" Text=""></asp:Label>
    </div>

    <div id="divDatos" runat="server" class="panel panel-success">
        <div class="panel-heading">
            <div class="row">
                <div class="col-md-8"><h3 class="panel-title">Agregando Conceptos de Obra</h3></div>
                <div class="col-md-2"> . </div>
                <div class="col-md-2"><a href="<%=ResolveClientUrl("~/Formas/Catalogos/catConceptosDeObra.aspx") %>">Regresar</a></div>
            </div>
        </div>


        <asp:GridView Height="25px" ShowHeaderWhenEmpty="true" CssClass="table" ID="grid" DataKeyNames="Id" AutoGenerateColumns="False" runat="server">
                <Columns>



                    <asp:TemplateField HeaderText="Clave" ItemStyle-CssClass="col-md-1">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Clave") %>'></asp:Label>
                        </ItemTemplate>                        
                    </asp:TemplateField>



                    <asp:TemplateField HeaderText="Nombre" ItemStyle-CssClass="col-md-8">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                        </ItemTemplate>                        
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Nombre" ItemStyle-CssClass="col-md-1">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("UnidadDeMedida.Clave") %>'></asp:Label>
                        </ItemTemplate>                        
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Nombre" ItemStyle-CssClass="col-md-1">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Minimo") %>'></asp:Label>
                        </ItemTemplate>                        
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Nombre" ItemStyle-CssClass="col-md-1">
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Maximo") %>'></asp:Label>
                        </ItemTemplate>                        
                    </asp:TemplateField>


                        <asp:TemplateField HeaderText="Acciones" ItemStyle-CssClass="col-md-.5">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgBtnEdit" ToolTip="Editar" runat="server" ImageUrl="~/img/Edit1.png" OnClick="imgBtnEdit_Click"/>
                            <asp:ImageButton ID="imgBtnEliminar" ToolTip="Borrar" runat="server" ImageUrl="~/img/close.png" OnClientClick="return fnc_Confirmar()" OnClick="imgBtnEliminar_Click"/>
                            
                        </ItemTemplate>
                        <HeaderStyle BackColor="#EEEEEE" />
                        <ItemStyle HorizontalAlign="right" VerticalAlign="Middle" BackColor="#EEEEEE" />
                    </asp:TemplateField>                                  


                </Columns>
                    
                
                    
        </asp:GridView>



    </div>


        <div id="divBtnNuevo" runat="server">
        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-primary" OnClick="btnNuevo_Click" AutoPostBack="false" />
    </div>
    
    
       <div class="row"> 

       <div id="divCaptura" runat="server" class="panel panel-success">

        

        <div class="panel-heading">
            <div class="row">
                <div class="col-md-8"><h3 class="panel-title">Agregando Conceptos de Obra</h3></div>
                <div class="col-md-2"> . </div>
                <div class="col-md-2"><a href="<%=ResolveClientUrl("~/Formas/Catalogos/catConceptosDeObra.aspx") %>">Regresar</a></div>
            </div>
        </div>


           <div class="row">
                                   
                 <div class="col-md-8">
       

                    <div class="form-group"">
                    
                        <label for="Clave">Clave</label>
                        <input type="text" class="input-sm required form-control" id="txtClave" runat="server" style="text-align: left; width:200px; align-items:flex-start" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtClave" ErrorMessage="El campo clave es obligatorio" ValidationGroup="validateX">*</asp:RequiredFieldValidator>
                    
                    </div>

                     <div class="form-group">
                        <label for="Descripcion">Descripcion</label>
                        <input type="text" class="input-sm required form-control" id="txtDescripcion" runat="server" style="text-align: left; width:600px;  align-items:flex-start" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="El campo Nombre es obligatorio" ValidationGroup="validateX">*</asp:RequiredFieldValidator>                    
                    </div>


                     <div class="form-group">
                        <label for="Unidad">Unidad de Medida</label>
                        <asp:DropDownList ID="ddlUnidad" CssClass="form-control" runat="server" style="text-align: left; width:200px; align-items:flex-start"></asp:DropDownList>
                    </div>
                 </div>

               <div class="col-md-4">

                    <div class="form-group">
                        <label for="minimo">Mínimo</label>
                        <input type="text" class="input-sm required form-control" id="txtMinimo" runat="server" style="text-align: left; width:200px;  align-items:flex-start" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMinimo" ErrorMessage="El campo Mínimo es obligatorio" ValidationGroup="validateX">*</asp:RequiredFieldValidator>                    
                    </div>


                    <div class="form-group">
                        <label for="maximo">Máximo</label>
                        <input type="text" class="input-sm required form-control" id="txtMaximo" runat="server" style="text-align: left; width:200px;  align-items:flex-start" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMaximo" ErrorMessage="El campo Máximo es obligatorio" ValidationGroup="validateX">*</asp:RequiredFieldValidator>                    
                    </div>


                    <div class="form-group">
                            <asp:Button  CssClass="btn btn-primary" Text="Guardar" ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" AutoPostBack="false" ValidationGroup="validateX" />
                            <asp:Button  CssClass="btn btn-default" Text="Cancelar" ID="btnCancelar" runat="server" OnClick="btnCancelar_Click"  AutoPostBack="false" />
                    </div>


               </div>

            </div>
                




            
                


                



                <div style="display:none" runat="server">
                    <asp:TextBox ID="_ElId" runat="server" Enable="false" BorderColor="White" BorderStyle="None" ForeColor="White"></asp:TextBox>
                    <asp:TextBox ID="_Accion" runat="server" Enable="false" BorderColor="White" BorderStyle="None" ForeColor="White"></asp:TextBox>
                                    
                </div>

                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="validateX" ViewStateMode="Disabled" />

            </div>
    </div>


</div>
</asp:Content>
