<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="teste5.webforms1" EnableEventValidation="false" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Acesso ao BD</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <link href="css/main.css" rel="stylesheet" type="text/css" />
    <script src="js/main.js"></script>

</head>

<body onload="Inicia()">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <%-- Relogio --%>
        <div id="clock">
            <div id="relogioHora">
                00:00 AM
            </div>
            <div id="relogioData">
                01/01/2000
            </div>
        </div>


        <h1>Cadastro Nomes</h1>


        <%-- Conteudo principal--%>
        <div class="content">


            <%-- Busca --%>

            <asp:UpdatePanel ID="UpdBuscar" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

                    <div id="busca" runat="server">

                        <h3>Buscar:</h3>
                        <asp:TextBox runat="server" ID="txt_busca"></asp:TextBox>
                        <asp:Button runat="server" ID="btn_buscar" OnClick="btn_buscar_Click" CssClass="btn btn-preto" />
                        <asp:Button ID="btn_abrirCadastro" OnClick="btn_abrirCadastro_Click" CssClass="btn-novo btn btn-preto" runat="server"></asp:Button>



                    </div>



                    <div id="radiobtns" runat="server">

                        <asp:RadioButtonList ID="chks" runat="server" RepeatDirection="Horizontal">

                            <asp:ListItem Value="0">Todos</asp:ListItem>
                            <asp:ListItem Value="1" Selected="True">Por Id</asp:ListItem>
                            <asp:ListItem Value="2">Por Nome</asp:ListItem>

                        </asp:RadioButtonList>

                    </div>


                </ContentTemplate>
            </asp:UpdatePanel>


            <%-- grid para exibir os dados --%>

            <asp:Panel ID="PnlGrig" runat="server" ScrollBars="Auto" CssClass="pnlgrid">
                <asp:UpdatePanel ID="updgrid" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>

                        <asp:GridView ID="grid" runat="server" BorderWidth="0" AutoGenerateColumns="False" CssClass="grid">

                            <EmptyDataRowStyle />

                            <Columns>

                                <asp:TemplateField ShowHeader="False" ItemStyle-Width="36px" HeaderStyle-BackColor="#6699ff" ItemStyle-HorizontalAlign="center">

                                    <ItemTemplate>

                                        <asp:Button ID="btgrid_selecionar" runat="server" CssClass="btn btn-selecionar" OnClick="btgrid_selecionar_Click" />

                                    </ItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField ShowHeader="False" ItemStyle-Width="36px" HeaderStyle-BackColor="#6699ff" ItemStyle-HorizontalAlign="center">

                                    <ItemTemplate>

                                        <asp:Button ID="btgrid_excluir" runat="server" CssClass="btn btn-excluir" OnClick="btgrid_excluir_Click" />

                                    </ItemTemplate>

                                </asp:TemplateField>

                                <asp:BoundField DataField="id" FooterText="Id" HeaderText="Id" HeaderStyle-BackColor="#6699ff" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="center"></asp:BoundField>
                                <asp:BoundField DataField="nome" FooterText="Nome" HeaderText="Nome" HeaderStyle-BackColor="#6699ff" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="center"></asp:BoundField>

                            </Columns>

                            <EmptyDataTemplate>

                                <div class="filler">

                                    <p class="alert-empty">Nenhum Dado Retornado!</p>

                                </div>

                            </EmptyDataTemplate>

                        </asp:GridView>


                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>


            <%-- Modal selecionar --%>

            <asp:UpdatePanel ID="UpdSelecionar" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

                    <div class="modal" id="modalSelecionado" runat="server">

                        <div class="modal-inside">

                            <div class="modal-itens">

                                <h3 class="titulo-modal">Visualizar</h3>

                                <div class="inputs">

                                    <asp:Label ID="lbl_id" runat="server"></asp:Label>
                                    <asp:TextBox ID="txt_nome" runat="server" Font-Bold="true"></asp:TextBox>

                                </div>

                                <p class="alert" runat="server" id="alertSelecionado">Nao permitido nome em branco!</p>

                                <div class="btns">

                                    <asp:Button ID="btn_salvar" runat="server" OnClick="btn_salvar_Click" CssClass="btn-modal btn-salvar" Text="Salvar" />
                                    <asp:Button ID="btn_fechar" OnClick="btn_fechar_Click" CssClass="btn-modal btn-fechar" runat="server" Text="Fechar" />

                                </div>
                            </div>
                        </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>

            <%-- Modal Cadastrar --%>

            <asp:UpdatePanel ID="UpdCadastro" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

                    <div class="modal" id="modalCadastro" runat="server">

                        <div class="modal-inside">

                            <div class="modal-itens">

                                <h3 class="titulo-modal">Cadastro</h3>

                                <div class="inputs-div">

                                    <asp:Label ID="Label2" runat="server">Nome:</asp:Label>
                                    <asp:TextBox ID="txt_nomeCadastro" runat="server" Font-Bold="true"></asp:TextBox>

                                </div>

                                <p class="alert" runat="server" id="alertCadastro">Nao permitido nome em branco!</p>

                                <div class="btns">

                                    <asp:Button ID="btn_adicionar" runat="server" OnClick="btn_adicionar_Click" CssClass="btn-modal btn-salvar" Text="Salvar" />
                                    <asp:Button ID="btn_fecharCadastro" OnClick="btn_fecharCadastro_Click" CssClass="btn-modal btn-voltar btn-fechar" runat="server" Text="Fechar"></asp:Button>

                                </div>
                            </div>
                        </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </form>

</body>
</html>
