﻿<%@ Page Title="" Language="C#" MasterPageFile="~/NavegadorPrincipal.Master" AutoEventWireup="true" CodeBehind="catConceptosDeObra.aspx.cs" Inherits="SIP.Formas.Catalogos.catConceptosDeObra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">

   <div class="panel panel-success">
        <div class="panel-heading">

            <div class="row">
                <div class="col-md-4"><h3 class="panel-title">Conceptos de Obra</h3></div>
                <div class="col-md-4">.</div>
                <div class="col-md-4"><a href="<%=ResolveClientUrl("~/Formas/Catalogos/catConceptosDeObraGrupoAdd.aspx") %>">Agregar Agrupador</a></div>
                
             </div>
        </div>
    </div>
       

               
        <div id="divConceptos" class="row" runat ="server">
            <label>Conceptos de Obra</label>




            <div class="bs-example">
            <div class="panel-group" id="accordion" runat="server">

                

            </div>
            </div>


        </div>


       

    </div>
</asp:Content>
