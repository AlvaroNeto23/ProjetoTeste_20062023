<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">

        <div class="row">
            <div class="col-md-12">
                <label>Número Por Extenso</label>
                <input type="text" id="txtNumInteiro" runat="server" placeholder="Número Inteiro até 4 caracteres" />
                <asp:Button ID="btnNumExtenso" runat="server" Text="Número por extenso" OnClick="btnNumExtenso_Click" />
                <input type="text" id="txtResultado" runat="server" />
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <label>Expressão Matemática</label>
                <input type="text" id="txtExprMatem" runat="server" placeholder="Expressão Matemática" />
                <asp:Button ID="btnExprMatem" runat="server" Text="Calcular" OnClick="btnExprMatem_Click" />
                <input type="text" id="txtResultadoExprMatem" runat="server" />
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <label>Array Somar Números Inteiros</label>
                <input type="text" id="txtNumerosInteiros" runat="server" placeholder="Números Inteiros separados por '+'" />
                <asp:Button ID="btnSomarNumeros" runat="server" Text="Somar Números" OnClick="btnSomarNumeros_Click" />
                <input type="text" id="txtResultadoSomarNumeros" runat="server" />
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <label>Lista De Objetos Sem Repetição</label>
                <input id="txtObjeto" />
                <input type="button" id="btnSemRepeticao" value="Sem Repetição" onclick="btnSemRepeticao()" />
                <input id="txtResultadoSemRepeticao" />
            </div>
        </div>
    </div>

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>

    <script type="text/javascript">
        
        function btnSemRepeticao() {

            //.DISTINCT().ToArray();
            debugger;

            $.ajax({
                type: "POST",
                url: "Default.aspx/FuncaoSemRepeticao",
                data: "{objeto: '" + $("#txtObjeto").val() + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (resposta) {
                    debugger;

                    $("#txtResultadoSemRepeticao").val(resposta.d);
                }
            });
        }
    </script>

</asp:Content>
