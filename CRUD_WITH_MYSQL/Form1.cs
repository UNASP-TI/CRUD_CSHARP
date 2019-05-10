
using CRUD_WITH_MYSQL.Mysql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_WITH_MYSQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        private void btCadastrar_Click(object sender, EventArgs e)
        {
            using (var db = new CRUD_WITH_MYSQLContext())
            {
                Usuario usuario = new Usuario();

                usuario.NomeUsuario = txtNome.Text;
                usuario.IdadeUsuario = Convert.ToInt16(txtIdade.Text);

                db.Usuario.Add(usuario);

                db.SaveChanges();

            }

        }

        private void btAtualizar_Click(object sender, EventArgs e)
        {
            using (var db = new CRUD_WITH_MYSQLContext())
            {
                //Database query direto na DataSource


                dgUsuario.DataSource = db.Usuario.Select(x =>
                    new
                    {
                        Id = x.IdUsuario,
                        Nome = x.NomeUsuario,
                        Idade = x.IdadeUsuario,
                    }).OrderBy(x => x.Id).ToList();

                //Configuracoes de DataGridView
                dgUsuario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgUsuario.AutoGenerateColumns = false;
                dgUsuario.ReadOnly = true;


                //Customizando as colunas
                dgUsuario.Columns["Id"].Visible = false;
                dgUsuario.Columns["Nome"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dgvAluno.Columns["Idade"].HeaderText = "Idade do aluno";
                dgUsuario.Columns["Idade"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            }
        }
    }
}
