using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using teste5.model;
using teste5.model.model.dao;

namespace teste5
{
    public partial class webforms1 : System.Web.UI.Page
    {
        TesteDAO testeDAO = new TesteDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            FillGrid();
            chks.Attributes.Add("onclick", "radioMe(event);");


        }



        void FillGrid()
        {
            grid.DataSource = testeDAO.GetAllData();
            grid.DataBind();
            updgrid.Update();
        }

        void FechaGrid()
        {
            grid.Visible = false;
            btn_abrirCadastro.Visible = false;
            busca.Style.Add("display", "none");
            radiobtns.Style.Add("display", "none");
            UpdBuscar.Update();


        }
        void AbreGrid()
        {
            grid.Visible = true;
            btn_abrirCadastro.Visible = true;
            FecharModais();
            UpdBuscar.Update();

        }
        void AbrirCadastro()
        {
            modalCadastro.Style.Add("display", "flex");
            UpdCadastro.Update();
        }

        void AbrirSelecionado()
        {
            modalSelecionado.Style.Add("display", "flex");
            UpdSelecionar.Update();

        }
        void FecharModais()
        {
            modalSelecionado.Style.Add("display", "none");
            modalCadastro.Style.Add("display", "none");
            busca.Style.Add("display", "flex");
            radiobtns.Style.Add("display", "flex");
            UpdCadastro.Update();
            UpdSelecionar.Update();


        }

        protected void btgrid_excluir_Click(object sender, EventArgs e)
        {

            Button xselecionar = sender as Button;
            GridViewRow row = (GridViewRow)xselecionar.NamingContainer;
            int xid = int.Parse(row.Cells[2].Text);

            testeDAO.ExcluirRegistro(xid);

            FillGrid();


        }

        protected void btgrid_selecionar_Click(object sender, EventArgs e)
        {
            FechaGrid();

            Button xselecionar = sender as Button;
            GridViewRow row = (GridViewRow)xselecionar.NamingContainer;

            txt_nome.Text = row.Cells[3].Text;
            lbl_id.Text =$"{row.Cells[2].Text}:";

            AbrirSelecionado();

        }


        protected void btn_salvar_Click(object sender, EventArgs e)
        {
            if (txt_nome.Text == "")
            {
                alertSelecionado.Style.Add("display", "flex");
                UpdSelecionar.Update();
            }
            else
            { 
                string labelFormatada = lbl_id.Text.Replace(":"," ");
                testeDAO.AtualizarRegistro(int.Parse(labelFormatada), txt_nome.Text);
                alertSelecionado.Style.Add("display", "none");
                FillGrid();
                AbreGrid();
            }

        }

        protected void btn_adicionar_Click(object sender, EventArgs e)
        {
            if (txt_nomeCadastro.Text == "")
            {
                alertCadastro.Style.Add("display", "flex");
                UpdCadastro.Update();
            }
            else
            {
                testeDAO.InserirNovo(txt_nomeCadastro.Text);
                txt_nomeCadastro.Text = "";
                alertCadastro.Style.Add("display", "none");
                FillGrid();
                AbreGrid();
            }

        }
        protected void btn_fechar_Click(object sender, EventArgs e)
        {
            alertSelecionado.Style.Add("display", "none");
            AbreGrid();
        }
        protected void btn_fecharCadastro_Click(object sender, EventArgs e)
        {
            alertCadastro.Style.Add("display", "none");
            AbreGrid();
        }

        protected void btn_abrirCadastro_Click(object sender, EventArgs e)
        {
            FechaGrid();
            AbrirCadastro();
        }

        protected void btn_buscar_Click(object sender, EventArgs e)
        {

            var check = chks.SelectedValue;
            List<Teste> testeList = new List<Teste>();

            if (check == "0")
            {
                testeList = testeDAO.GetAllData();
            }
            if (check == "1")
            {

                testeList = testeDAO.GetData("id", txt_busca.Text);
            }

            if (check == "2")

            {
                if (txt_busca.Text == "")
                {
                    txt_busca.Text = " ";
                }
                testeList = testeDAO.GetData("nome", txt_busca.Text);
            }

            txt_busca.Text = "";
            grid.DataSource = testeList;
            grid.DataBind();
            updgrid.Update();

        }




    }
}

