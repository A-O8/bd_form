using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bdForumBusinessLogic.BindingModels;
using bdForumBusinessLogic.BusinessLogic;
using Unity;

namespace bdForum
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly subjectLogic topiclogic;
        public FormMain(subjectLogic topiclogic)
        {
            InitializeComponent();
            this.topiclogic = topiclogic;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                Program.myTimer = DateTime.Now;
                var list = topiclogic.Read(null);
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                var answer = Program.myTimer - DateTime.Now;
                Console.WriteLine("Время выполнения: " + answer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormEditfaculties>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            var this_topic = topiclogic.Read(new subjectBindingModel
            {
                Name = Convert.ToString(dataGridView.SelectedRows[0].Cells[0].Value)
            })[0];
            topiclogic.CreateOrUpdate(new subjectBindingModel
            {
                Name = Convert.ToString(dataGridView.SelectedRows[0].Cells[0].Value),
                NumberOfMessages = this_topic.NumberOfMessages,
                NumberOfVisitors = this_topic.NumberOfVisitors + 1
            });
            var form = Container.Resolve<Formapplicantss>();
            form.nameTopic = Convert.ToString(dataGridView.SelectedRows[0].Cells[0].Value);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormEditfaculties>();
                form.Name = Convert.ToString(dataGridView.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string name = Convert.ToString(dataGridView.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        topiclogic.Delete(new subjectBindingModel { Name = name });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonReq1_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReq1>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonReq3_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReq3>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
    }
}
